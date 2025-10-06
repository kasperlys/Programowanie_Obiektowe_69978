using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("To jest cwiczenie 1");

        // Tablica na 4 zwierzęta
        Zwierze[] zwierzeta = new Zwierze[4];

        // Pobieranie informacji o 3 zwierzętach od użytkownika
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"\n--- Zwierzę {i + 1} ---");

            Console.Write("Podaj nazwę zwierzęcia: ");
            string nazwa = Console.ReadLine();

            Console.Write("Podaj gatunek zwierzęcia: ");
            string gatunek = Console.ReadLine();

            Console.Write("Podaj liczbę nóg: ");
            int liczbaNog = int.Parse(Console.ReadLine());

            zwierzeta[i] = new Zwierze(nazwa, gatunek, liczbaNog);
        }

        // Tworzenie czwartego zwierzęcia poprzez klonowanie
        zwierzeta[3] = new Zwierze(zwierzeta[0]);
        zwierzeta[3].Nazwa = "Klonowany_" + zwierzeta[0].Nazwa;

        // Wyświetlanie informacji o wszystkich zwierzętach
        Console.WriteLine("\n=== INFORMACJE O WSZYSTKICH ZWIERZĘTACH ===");
        for (int i = 0; i < zwierzeta.Length; i++)
        {
            Console.WriteLine($"\nZwierzę {i + 1}:");
            zwierzeta[i].WyswietlInformacje();
            Console.Write("Głos: ");
            zwierzeta[i].DajGlos();
        }

        // Wyświetlanie liczby zwierząt
        Console.WriteLine($"\nŁączna liczba utworzonych zwierząt: {Zwierze.PobierzLiczbeZwierzat()}");
    }
}

public class Zwierze
{
    // Pola składowe
    private string nazwa;
    private string gatunek;
    private int liczbaNog;
    private static int liczbaZwierzat = 0;

    // Właściwości (zamiast getterów/setterów)
    public string Nazwa
    {
        get { return nazwa; }
        set { nazwa = value; }
    }

    public string Gatunek
    {
        get { return gatunek; }
    }

    public int LiczbaNog
    {
        get { return liczbaNog; }
    }

    // Konstruktor bezparametrowy
    public Zwierze()
    {
        this.nazwa = "Rex";
        this.gatunek = "Pies";
        this.liczbaNog = 4;
        liczbaZwierzat++;
    }

    // Konstruktor z parametrami
    public Zwierze(string nazwa, string gatunek, int liczbaNog)
    {
        this.nazwa = nazwa;
        this.gatunek = gatunek;
        this.liczbaNog = liczbaNog;
        liczbaZwierzat++;
    }

    // Konstruktor kopiujący
    public Zwierze(Zwierze inneZwierze)
    {
        this.nazwa = inneZwierze.nazwa;
        this.gatunek = inneZwierze.gatunek;
        this.liczbaNog = inneZwierze.liczbaNog;
        liczbaZwierzat++;
    }

    // Metoda dająca głos
    public void DajGlos()
    {
        switch (gatunek.ToLower())
        {
            case "pies":
                Console.WriteLine("Hau Hau!");
                break;
            case "kot":
                Console.WriteLine("Miau!");
                break;
            case "krowa":
                Console.WriteLine("Muuu!");
                break;
            case "koń":
                Console.WriteLine("Ihaaha!");
                break;
            case "owca":
                Console.WriteLine("Beee!");
                break;
            case "kura":
                Console.WriteLine("Ko ko ko!");
                break;
            case "kaczka":
                Console.WriteLine("Kwa kwa!");
                break;
            case "ptak":
                Console.WriteLine("Ćwir ćwir!");
                break;
            default:
                Console.WriteLine("... (nieznany gatunek)");
                break;
        }
    }

    // Statyczna metoda zwracająca liczbę zwierząt
    public static int PobierzLiczbeZwierzat()
    {
        return liczbaZwierzat;
    }

    // Metoda do wyświetlania informacji
    public void WyswietlInformacje()
    {
        Console.WriteLine($"Nazwa: {nazwa}, Gatunek: {gatunek}, Liczba nóg: {liczbaNog}");
    }

    // Destruktor
    ~Zwierze()
    {
        Console.WriteLine($"Destruktor: Zwierzę {nazwa} jest usuwane z pamięci");
        // W platformie .NET destruktor jest rzadko używany ze względu na garbage collector
    }
}