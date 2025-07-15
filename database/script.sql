IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'SklepKomputerowy')
BEGIN
    CREATE DATABASE [SklepKomputerowy];
END
GO

USE [SklepKomputerowy]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 07.06.2025 07:22:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dostawcy]    Script Date: 07.06.2025 07:22:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dostawcy](
	[DostawcaID] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [varchar](200) NOT NULL,
	[Telefon] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[Adres] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[DostawcaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dostawy]    Script Date: 07.06.2025 07:22:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dostawy](
	[DostawaID] [int] IDENTITY(1,1) NOT NULL,
	[DostawcaID] [int] NULL,
	[DataDostawy] [datetime] NOT NULL,
	[StatusDostawy] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[DostawaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategorie]    Script Date: 07.06.2025 07:22:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategorie](
	[KategoriaID] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [varchar](100) NOT NULL,
	[Opis] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[KategoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Klienci]    Script Date: 07.06.2025 07:22:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klienci](
	[KlientID] [int] IDENTITY(1,1) NOT NULL,
	[Imie] [varchar](100) NOT NULL,
	[Nazwisko] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Telefon] [varchar](20) NULL,
	[Adres] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[KlientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProduktDostawy]    Script Date: 07.06.2025 07:22:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProduktDostawy](
	[DostawaID] [int] NOT NULL,
	[ProduktID] [int] NOT NULL,
	[Ilosc] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DostawaID] ASC,
	[ProduktID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produkty]    Script Date: 07.06.2025 07:22:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produkty](
	[ProduktID] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [varchar](200) NOT NULL,
	[Opis] [text] NULL,
	[Cena] [decimal](10, 2) NOT NULL,
	[StanMagazynowy] [int] NOT NULL,
	[KategoriaID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProduktID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uzytkownicy]    Script Date: 07.06.2025 07:22:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uzytkownicy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[HasloHash] [nvarchar](255) NOT NULL,
	[Rola] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zamowienia]    Script Date: 07.06.2025 07:22:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zamowienia](
	[ZamowienieID] [int] IDENTITY(1,1) NOT NULL,
	[KlientID] [int] NULL,
	[DataZamowienia] [datetime] NOT NULL,
	[Status] [varchar](50) NULL,
	[Kwota] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ZamowienieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZamowioneProdukty]    Script Date: 07.06.2025 07:22:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZamowioneProdukty](
	[ZamowienieID] [int] NOT NULL,
	[ProduktID] [int] NOT NULL,
	[Ilosc] [int] NOT NULL,
	[CenaJednostkowa] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ZamowienieID] ASC,
	[ProduktID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Dostawcy] ON 

INSERT [dbo].[Dostawcy] ([DostawcaID], [Nazwa], [Telefon], [Email], [Adres]) VALUES (1, N'Dostawca A', N'123123123', N'kontakt@dostawcaA.pl', N'ul. Dostawców 10, 00-003 Warszawa')
INSERT [dbo].[Dostawcy] ([DostawcaID], [Nazwa], [Telefon], [Email], [Adres]) VALUES (2, N'Dostawca C', N'555555555', N'kontakt@dostawcaC.pl', N'ul. Dostawców 30, 00-005 Warszawa')
INSERT [dbo].[Dostawcy] ([DostawcaID], [Nazwa], [Telefon], [Email], [Adres]) VALUES (3, N'Dostawca B', N'321321321', N'kontakt@dostawcaB.pl', N'ul. Dostawców 20, 00-004 Warszawa')
INSERT [dbo].[Dostawcy] ([DostawcaID], [Nazwa], [Telefon], [Email], [Adres]) VALUES (4, N'Dostawca D', N'666666666', N'kontakt@dostawcaD.pl', N'ul. Dostawców 40, 00-006 Warszawa')
SET IDENTITY_INSERT [dbo].[Dostawcy] OFF
GO
SET IDENTITY_INSERT [dbo].[Dostawy] ON 

INSERT [dbo].[Dostawy] ([DostawaID], [DostawcaID], [DataDostawy], [StatusDostawy]) VALUES (1, 2, CAST(N'2025-05-03T00:00:00.000' AS DateTime), N'Dostarczono 123')
INSERT [dbo].[Dostawy] ([DostawaID], [DostawcaID], [DataDostawy], [StatusDostawy]) VALUES (2, 2, CAST(N'2025-05-20T10:00:00.000' AS DateTime), N'Zrealizowano')
INSERT [dbo].[Dostawy] ([DostawaID], [DostawcaID], [DataDostawy], [StatusDostawy]) VALUES (3, 1, CAST(N'2025-05-19T01:50:20.217' AS DateTime), N'W realizacji')
INSERT [dbo].[Dostawy] ([DostawaID], [DostawcaID], [DataDostawy], [StatusDostawy]) VALUES (4, 3, CAST(N'2025-05-16T04:11:56.727' AS DateTime), N'W realizacji')
INSERT [dbo].[Dostawy] ([DostawaID], [DostawcaID], [DataDostawy], [StatusDostawy]) VALUES (5, 4, CAST(N'2025-05-21T14:30:00.000' AS DateTime), N'Oczekuje')
INSERT [dbo].[Dostawy] ([DostawaID], [DostawcaID], [DataDostawy], [StatusDostawy]) VALUES (6, 1, CAST(N'2025-05-16T04:48:55.783' AS DateTime), N'qwerty')
INSERT [dbo].[Dostawy] ([DostawaID], [DostawcaID], [DataDostawy], [StatusDostawy]) VALUES (7, 3, CAST(N'2026-05-17T00:00:00.000' AS DateTime), N'W realizacji')
INSERT [dbo].[Dostawy] ([DostawaID], [DostawcaID], [DataDostawy], [StatusDostawy]) VALUES (8, 1, CAST(N'2028-08-19T00:00:00.000' AS DateTime), N'W realizacji')
INSERT [dbo].[Dostawy] ([DostawaID], [DostawcaID], [DataDostawy], [StatusDostawy]) VALUES (9, 1, CAST(N'2027-06-17T00:00:00.000' AS DateTime), N'W realizacji')
INSERT [dbo].[Dostawy] ([DostawaID], [DostawcaID], [DataDostawy], [StatusDostawy]) VALUES (10, 3, CAST(N'2028-09-16T00:00:00.000' AS DateTime), N'W realizacji')
INSERT [dbo].[Dostawy] ([DostawaID], [DostawcaID], [DataDostawy], [StatusDostawy]) VALUES (13, 1, CAST(N'2025-07-06T00:00:00.000' AS DateTime), N'W realizacji')
SET IDENTITY_INSERT [dbo].[Dostawy] OFF
GO
SET IDENTITY_INSERT [dbo].[Kategorie] ON 

INSERT [dbo].[Kategorie] ([KategoriaID], [Nazwa], [Opis]) VALUES (1, N'Laptopy', N'Laptopy różnych marek i modeli')
INSERT [dbo].[Kategorie] ([KategoriaID], [Nazwa], [Opis]) VALUES (2, N'Akcesoria', N'Akcesoria komputerowe, takie jak myszki, klawiatury, słuchawki')
INSERT [dbo].[Kategorie] ([KategoriaID], [Nazwa], [Opis]) VALUES (3, N'Komputery', N'Komputery stacjonarne, PC')
INSERT [dbo].[Kategorie] ([KategoriaID], [Nazwa], [Opis]) VALUES (4, N'Monitory', N'Różne modele monitorów')
INSERT [dbo].[Kategorie] ([KategoriaID], [Nazwa], [Opis]) VALUES (5, N'Podzespoły', N'Podzespoły komputerowe jak procesory, RAM, dyski')
SET IDENTITY_INSERT [dbo].[Kategorie] OFF
GO
SET IDENTITY_INSERT [dbo].[Klienci] ON 

INSERT [dbo].[Klienci] ([KlientID], [Imie], [Nazwisko], [Email], [Telefon], [Adres]) VALUES (1, N'Jan123', N'Kowalski', N'jan.kowalski@mail.com', N'1111111111', N'ul. Przykładowa 1, 00-001 Warszawa')
INSERT [dbo].[Klienci] ([KlientID], [Imie], [Nazwisko], [Email], [Telefon], [Adres]) VALUES (2, N'Anna', N'Nowak', N'anna.nowak@example.com', N'987654321', N'ul. Testowa 2, 00-002 Warszawa')
INSERT [dbo].[Klienci] ([KlientID], [Imie], [Nazwisko], [Email], [Telefon], [Adres]) VALUES (3, N'Marek', N'Zieliński', N'marek.zielinski@mail.com', N'222333444', N'ul. Zielona 5, 00-007 Warszawa')
INSERT [dbo].[Klienci] ([KlientID], [Imie], [Nazwisko], [Email], [Telefon], [Adres]) VALUES (4, N'Adam', N'Małysz', N'adam.malysz@gmail.com', N'123456789', N'Niebieska 12')
INSERT [dbo].[Klienci] ([KlientID], [Imie], [Nazwisko], [Email], [Telefon], [Adres]) VALUES (5, N'Kasia', N'Wiśniewska', N'kasia.wisniewska@mail.com', N'333444555', N'ul. Czerwona 7, 00-008 Warszawa')
INSERT [dbo].[Klienci] ([KlientID], [Imie], [Nazwisko], [Email], [Telefon], [Adres]) VALUES (6, N'Tomek', N'Lewandowski', N'tomek.lewandowski@mail.com', N'444555666', N'ul. Żółta 9, 00-009 Warszawa')
INSERT [dbo].[Klienci] ([KlientID], [Imie], [Nazwisko], [Email], [Telefon], [Adres]) VALUES (9, N'Klient123', N'Klient123', N'klien123@email.com', N'123456789', N'klient123')
SET IDENTITY_INSERT [dbo].[Klienci] OFF
GO
INSERT [dbo].[ProduktDostawy] ([DostawaID], [ProduktID], [Ilosc]) VALUES (1, 1, 5)
INSERT [dbo].[ProduktDostawy] ([DostawaID], [ProduktID], [Ilosc]) VALUES (1, 2, 20)
INSERT [dbo].[ProduktDostawy] ([DostawaID], [ProduktID], [Ilosc]) VALUES (2, 3, 10)
INSERT [dbo].[ProduktDostawy] ([DostawaID], [ProduktID], [Ilosc]) VALUES (5, 4, 5)
GO
SET IDENTITY_INSERT [dbo].[Produkty] ON 

INSERT [dbo].[Produkty] ([ProduktID], [Nazwa], [Opis], [Cena], [StanMagazynowy], [KategoriaID]) VALUES (1, N'Laptop Dell XPS 13', N'Laptop z procesorem Intel i 16GB RAM', CAST(4499.99 AS Decimal(10, 2)), 123, 1)
INSERT [dbo].[Produkty] ([ProduktID], [Nazwa], [Opis], [Cena], [StanMagazynowy], [KategoriaID]) VALUES (2, N'Klawiatura Logitech G Pro', N'Profesjonalna klawiatura mechaniczna', CAST(299.99 AS Decimal(10, 2)), 50, 2)
INSERT [dbo].[Produkty] ([ProduktID], [Nazwa], [Opis], [Cena], [StanMagazynowy], [KategoriaID]) VALUES (3, N'PC Gamingowy Ryzen 5', N'Komputer stacjonarny z procesorem Ryzen 5 i kartą GTX 1660', CAST(2999.99 AS Decimal(10, 2)), 5, 3)
INSERT [dbo].[Produkty] ([ProduktID], [Nazwa], [Opis], [Cena], [StanMagazynowy], [KategoriaID]) VALUES (4, N'Produkt test', N'Opis test', CAST(1000.00 AS Decimal(10, 2)), 100, NULL)
INSERT [dbo].[Produkty] ([ProduktID], [Nazwa], [Opis], [Cena], [StanMagazynowy], [KategoriaID]) VALUES (100, N'Myszka bezprzewodowa', N'Ergonomiczna myszka bezprzewodowa', CAST(79.99 AS Decimal(10, 2)), 150, 2)
INSERT [dbo].[Produkty] ([ProduktID], [Nazwa], [Opis], [Cena], [StanMagazynowy], [KategoriaID]) VALUES (101, N'Laptop Lenovo', N'Laptop Lenovo ThinkPad, 16GB RAM, SSD 512GB', CAST(4500.00 AS Decimal(10, 2)), 20, 1)
INSERT [dbo].[Produkty] ([ProduktID], [Nazwa], [Opis], [Cena], [StanMagazynowy], [KategoriaID]) VALUES (102, N'Procesor Intel i7', N'Intel Core i7 12 gen', CAST(1200.00 AS Decimal(10, 2)), 50, 5)
SET IDENTITY_INSERT [dbo].[Produkty] OFF
GO
SET IDENTITY_INSERT [dbo].[Uzytkownicy] ON 

INSERT [dbo].[Uzytkownicy] ([Id], [Email], [HasloHash], [Rola]) VALUES (1, N'kacper@email.com', N'$2a$11$WUe1O/0vUQB36iqizzLsBOqnM/CDip7dISbmZN8HKhPiAznQdIzhe', N'User')
INSERT [dbo].[Uzytkownicy] ([Id], [Email], [HasloHash], [Rola]) VALUES (2, N'kacper1@email.com', N'$2a$11$zcF4EH9TIwiu7D5UMmMD5.Nu.HVUmhJ48WASnaragoo9YhPupLMH.', N'User')
INSERT [dbo].[Uzytkownicy] ([Id], [Email], [HasloHash], [Rola]) VALUES (3, N'kacper2@email.com', N'$2a$11$Usrf9ZpXmZ9qQzkeHfT8Gu4eYL4lUxp6x8n4vdfAEj6vzFMNwQWuu', N'User')
SET IDENTITY_INSERT [dbo].[Uzytkownicy] OFF
GO
SET IDENTITY_INSERT [dbo].[Zamowienia] ON 

INSERT [dbo].[Zamowienia] ([ZamowienieID], [KlientID], [DataZamowienia], [Status], [Kwota]) VALUES (1, 3, CAST(N'2025-05-04T00:00:00.000' AS DateTime), N'Zrealizowane', CAST(5159.97 AS Decimal(10, 2)))
INSERT [dbo].[Zamowienia] ([ZamowienieID], [KlientID], [DataZamowienia], [Status], [Kwota]) VALUES (2, 2, CAST(N'2025-05-03T00:00:00.000' AS DateTime), N'Zrealizowane', CAST(4199.95 AS Decimal(10, 2)))
INSERT [dbo].[Zamowienia] ([ZamowienieID], [KlientID], [DataZamowienia], [Status], [Kwota]) VALUES (100, 3, CAST(N'2025-05-15T13:00:00.000' AS DateTime), N'Zrealizowane', CAST(159.98 AS Decimal(10, 2)))
INSERT [dbo].[Zamowienia] ([ZamowienieID], [KlientID], [DataZamowienia], [Status], [Kwota]) VALUES (101, 5, CAST(N'2025-05-16T00:00:00.000' AS DateTime), N'Zrealizowane', CAST(4500.00 AS Decimal(10, 2)))
INSERT [dbo].[Zamowienia] ([ZamowienieID], [KlientID], [DataZamowienia], [Status], [Kwota]) VALUES (102, 6, CAST(N'2025-05-17T18:45:00.000' AS DateTime), N'Anulowane', CAST(1200.00 AS Decimal(10, 2)))
INSERT [dbo].[Zamowienia] ([ZamowienieID], [KlientID], [DataZamowienia], [Status], [Kwota]) VALUES (1004, 4, CAST(N'2025-06-05T00:00:00.000' AS DateTime), N'W realizacji', CAST(2999.00 AS Decimal(10, 2)))
INSERT [dbo].[Zamowienia] ([ZamowienieID], [KlientID], [DataZamowienia], [Status], [Kwota]) VALUES (1005, 6, CAST(N'2025-05-06T00:00:00.000' AS DateTime), N'Zrealizowane', CAST(1519.36 AS Decimal(10, 2)))
INSERT [dbo].[Zamowienia] ([ZamowienieID], [KlientID], [DataZamowienia], [Status], [Kwota]) VALUES (1008, 1, CAST(N'2025-06-07T00:00:00.000' AS DateTime), N'W realizacji', CAST(4500.00 AS Decimal(10, 2)))
INSERT [dbo].[Zamowienia] ([ZamowienieID], [KlientID], [DataZamowienia], [Status], [Kwota]) VALUES (1009, 1, CAST(N'2024-06-07T00:00:00.000' AS DateTime), N'Zrealizowane', CAST(36000.00 AS Decimal(10, 2)))
INSERT [dbo].[Zamowienia] ([ZamowienieID], [KlientID], [DataZamowienia], [Status], [Kwota]) VALUES (1010, 4, CAST(N'2024-05-07T00:00:00.000' AS DateTime), N'Zrealizowane', CAST(29699.97 AS Decimal(10, 2)))
INSERT [dbo].[Zamowienia] ([ZamowienieID], [KlientID], [DataZamowienia], [Status], [Kwota]) VALUES (1011, 2, CAST(N'2020-02-06T00:00:00.000' AS DateTime), N'Zrealizowane', CAST(2999.99 AS Decimal(10, 2)))
INSERT [dbo].[Zamowienia] ([ZamowienieID], [KlientID], [DataZamowienia], [Status], [Kwota]) VALUES (1012, 2, CAST(N'2023-05-05T00:00:00.000' AS DateTime), N'Zrealizowane', CAST(10200.00 AS Decimal(10, 2)))
INSERT [dbo].[Zamowienia] ([ZamowienieID], [KlientID], [DataZamowienia], [Status], [Kwota]) VALUES (1013, 9, CAST(N'2025-02-04T00:00:00.000' AS DateTime), N'Zrealizowane', CAST(4500.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Zamowienia] OFF
GO
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (1, 1, 1, CAST(4999.99 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (1, 100, 2, CAST(79.99 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (2, 2, 4, CAST(299.99 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (2, 3, 1, CAST(2999.99 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (100, 100, 2, CAST(79.99 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (101, 101, 1, CAST(4500.00 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (101, 102, 1, CAST(1200.00 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (102, 102, 1, CAST(1200.00 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (1004, 3, 1, CAST(2999.99 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (1005, 100, 4, CAST(79.99 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (1005, 102, 1, CAST(1200.00 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (1008, 101, 1, CAST(4500.00 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (1009, 101, 8, CAST(4500.00 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (1010, 1, 3, CAST(4499.99 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (1010, 101, 2, CAST(4500.00 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (1010, 102, 6, CAST(1200.00 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (1011, 3, 1, CAST(2999.99 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (1012, 101, 2, CAST(4500.00 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (1012, 102, 1, CAST(1200.00 AS Decimal(10, 2)))
INSERT [dbo].[ZamowioneProdukty] ([ZamowienieID], [ProduktID], [Ilosc], [CenaJednostkowa]) VALUES (1013, 101, 1, CAST(4500.00 AS Decimal(10, 2)))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Klienci__A9D10534687AB9C2]    Script Date: 07.06.2025 07:22:46 ******/
ALTER TABLE [dbo].[Klienci] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Dostawy] ADD  DEFAULT (getdate()) FOR [DataDostawy]
GO
ALTER TABLE [dbo].[Uzytkownicy] ADD  DEFAULT ('User') FOR [Rola]
GO
ALTER TABLE [dbo].[Zamowienia] ADD  DEFAULT (getdate()) FOR [DataZamowienia]
GO
ALTER TABLE [dbo].[Dostawy]  WITH CHECK ADD FOREIGN KEY([DostawcaID])
REFERENCES [dbo].[Dostawcy] ([DostawcaID])
GO
ALTER TABLE [dbo].[ProduktDostawy]  WITH CHECK ADD FOREIGN KEY([DostawaID])
REFERENCES [dbo].[Dostawy] ([DostawaID])
GO
ALTER TABLE [dbo].[ProduktDostawy]  WITH CHECK ADD FOREIGN KEY([ProduktID])
REFERENCES [dbo].[Produkty] ([ProduktID])
GO
ALTER TABLE [dbo].[Produkty]  WITH CHECK ADD FOREIGN KEY([KategoriaID])
REFERENCES [dbo].[Kategorie] ([KategoriaID])
GO
ALTER TABLE [dbo].[Zamowienia]  WITH CHECK ADD FOREIGN KEY([KlientID])
REFERENCES [dbo].[Klienci] ([KlientID])
GO
ALTER TABLE [dbo].[ZamowioneProdukty]  WITH CHECK ADD FOREIGN KEY([ProduktID])
REFERENCES [dbo].[Produkty] ([ProduktID])
GO
ALTER TABLE [dbo].[ZamowioneProdukty]  WITH CHECK ADD FOREIGN KEY([ZamowienieID])
REFERENCES [dbo].[Zamowienia] ([ZamowienieID])
GO
