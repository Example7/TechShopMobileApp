using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TechShopApp.Helpers
{
    public static class PropertyUtil
    {
        /// <summary>
        /// Extension method for copying property values from one object to another. 
        /// Property must have the same type and name in order to be copied.
        /// </summary>
        /// <typeparam name="TargetType">Target type to which values will be copied.</typeparam>
        /// <typeparam name="SourceType">Source type from which values will be copied.</typeparam>
        /// <param name="targetObject">Target object to which values will be copied.</param>
        /// <param name="sourceObject">Source object from which values will be copied.</param>
        /// <returns>Target object.</returns>
        public static T CopyProperties<T, T2>(this T targetObject, T2 sourceObject)
        {
            var targetProperties = targetObject.GetType().GetProperties().Where(p => p.CanWrite);
            foreach (var targetProperty in targetProperties)
            {
                FindAndReplaceProperty(targetObject, sourceObject, targetProperty);
            }
            return targetObject;
        }

        private static void FindAndReplaceProperty<T, T2>(T targetObject, T2 sourceObject, PropertyInfo targetProperty)
        {
            var sourceProperty = sourceObject.GetType()
                                            .GetProperties()
                                            .FirstOrDefault(p => string.Equals(p.Name, targetProperty.Name, StringComparison.InvariantCultureIgnoreCase));

            if (sourceProperty == null || !targetProperty.CanWrite)
                return;

            var sourceValue = sourceProperty.GetValue(sourceObject);

            Console.WriteLine($"Copying {targetProperty.Name}: {sourceValue} ({sourceProperty.PropertyType.Name} => {targetProperty.PropertyType.Name})");

            if (targetProperty.PropertyType == sourceProperty.PropertyType)
            {
                targetProperty.SetValue(targetObject, sourceValue);
                return;
            }

            var targetType = Nullable.GetUnderlyingType(targetProperty.PropertyType) ?? targetProperty.PropertyType;
            var sourceType = Nullable.GetUnderlyingType(sourceProperty.PropertyType) ?? sourceProperty.PropertyType;

            if (targetType == sourceType)
            {
                try
                {
                    var convertedValue = sourceValue == null ? null : Convert.ChangeType(sourceValue, targetType);
                    targetProperty.SetValue(targetObject, convertedValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to convert property {targetProperty.Name}: {ex.Message}");
                }
            }
        }

        private static IEnumerable<PropertyInfo> GetTypeProperties<T2>(this T2 sourceObject)
            => sourceObject.GetType().GetProperties();
        private static bool CheckIfPropertyExistInSource(PropertyInfo prop, PropertyInfo property)
            => string.Equals(property.Name, prop.Name, StringComparison.InvariantCultureIgnoreCase)
                    && prop.PropertyType.Equals(property.PropertyType);
        private static object GetPropertyValue<T>(this T source, string propertyName)
            => source.GetType().GetProperty(propertyName).GetValue(source, null);
    }
}
