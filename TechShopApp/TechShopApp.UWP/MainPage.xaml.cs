namespace TechShopApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new TechShopApp.App());
        }
    }
}
