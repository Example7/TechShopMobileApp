# 🛒 TechShopMobileApp

Mobilna aplikacja sklepu komputerowego stworzona w technologii **Xamarin.Forms** z backendem opartym o **ASP.NET Core Web API**. Projekt zrealizowany w ramach przedmiotu **Projektowanie mobilnych aplikacji biznesowych**.

## 📦 Struktura rozwiązania

- **📱 TechShopApp** – aplikacja mobilna (Xamarin.Forms)
  - Projekty platformowe: Android, iOS, UWP
- **🌐 RestApi** – backend (ASP.NET Core + Entity Framework Core)
- **🗄️ Baza danych** – Microsoft SQL Server (`LocalDB`)
  - Skrypt `script.sql` dostępny w folderze `database/`

---

## 🧰 Technologie

- Xamarin.Forms (Android, iOS, UWP)
- ASP.NET Core Web API
- Entity Framework Core
- MS SQL Server (LocalDB)
- C#
- REST
- MVVM
- Visual Studio 2022+

---

## ⚙️ Funkcje aplikacji

### 👤 Klient:
- Przeglądanie oferty sklepu (lista produktów)
- Szczegóły produktów
- Składanie zamówień

### 🧑‍💼 Pracownik/Admin (API):
- Zarządzanie produktami (CRUD)
- Obsługa zamówień
- Rejestracja użytkowników
- Autoryzacja z rolami

---

## ▶️ Jak uruchomić projekt lokalnie

### 1. Przygotowanie bazy danych

- Uruchom `script.sql` z folderu `database/` w SQL Server Management Studio
- Upewnij się, że baza nazywa się np. `SklepKomputerowy`

### 2. Skonfiguruj `RestApi`

- Otwórz plik: `RestApi/appsettings.json`
- Ustaw connection string, np.:

```json
"ConnectionStrings": {
  "CompanyContext": "Server=(localdb)\\MSSQLLocalDB;Database=SklepKomputerowy;Trusted_Connection=True;"
}
```

- Uruchom RestApi w Visual Studio (F5)

3. Uruchom aplikację mobilną

- Ustaw projekt TechShopApp.Android lub TechShopApp.UWP jako startowy

- Upewnij się, że aplikacja odwołuje się do adresu lokalnego API, np.:
```bash
http://10.0.2.2:5000/api/produkty
```
🔁 Jeśli testujesz na emulatorze Androida, użyj 10.0.2.2 zamiast localhost.

##  Folder database

Zawiera pełny skrypt SQL (script.sql) do odtworzenia struktury bazy danych:
- Produkty
- Kategorie
- Użytkownicy
- Role
- Zamówienia
- Szczegóły zamówień

## 👨‍💻 Autor
**Kacper Kałużny** ([Example7](https://github.com/Example7))
