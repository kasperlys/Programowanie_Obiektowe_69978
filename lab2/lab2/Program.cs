using System;

namespace DziedziczeniePolimorfizm
{
    // 1. Klasa bazowa Zwierze
    public class Zwierze
    {
        protected string nazwa;

        public Zwierze(string nazwa)
        {
            this.nazwa = nazwa;
        }

        public virtual void daj_glos()
        {
            Console.WriteLine("...");
        }
    }

    // 2. Klasa Pies
    public class Pies : Zwierze
    {
        public Pies(string nazwa) : base(nazwa) { }

        public override void daj_glos()
        {
            Console.WriteLine($"{nazwa} robi woof woof!");
        }
    }

    // 3. Klasa Kot
    public class Kot : Zwierze
    {
        public Kot(string nazwa) : base(nazwa) { }

        public override void daj_glos()
        {
            Console.WriteLine($"{nazwa} robi miau miau!");
        }
    }

    // 4. Klasa Waz
    public class Waz : Zwierze
    {
        public Waz(string nazwa) : base(nazwa) { }

        public override void daj_glos()
        {
            Console.WriteLine($"{nazwa} robi ssssssss!");
        }
    }

    // 6. Globalna metoda przyjmująca obiekt klasy Zwierze
    public static class ZwierzetaHelper
    {
        public static void powiedz_cos(Zwierze z)
        {
            z.daj_glos();
            Console.WriteLine($"Typ obiektu: {z.GetType().Name}");
            Console.WriteLine();
        }
    }

    // 8. Klasa abstrakcyjna Pracownik
    public abstract class Pracownik
    {
        public abstract void Pracuj();
    }

    // 9. Klasa Piekarz dziedzicząca po Pracownik
    public class Piekarz : Pracownik
    {
        public override void Pracuj()
        {
            Console.WriteLine("Trwa pieczenie...");
        }
    }

    // 12–14. Klasy A, B, C pokazujące kolejność konstruktorów
    public class A
    {
        public A()
        {
            Console.WriteLine("To jest konstruktor A");
        }
    }

    public class B : A
    {
        public B() : base()
        {
            Console.WriteLine("To jest konstruktor B");
        }
    }

    public class C : B
    {
        public C() : base()
        {
            Console.WriteLine("To jest konstruktor C");
        }
    }

    // 7. & 10. & 15. - Funkcja main()
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== POLIMORFIZM ZWIERZĄT ===");
            Zwierze z = new Zwierze("Nieznane");
            Pies p = new Pies("Reksio");
            Kot k = new Kot("Filemon");
            Waz w = new Waz("Kaa");

            ZwierzetaHelper.powiedz_cos(z);
            ZwierzetaHelper.powiedz_cos(p);
            ZwierzetaHelper.powiedz_cos(k);
            ZwierzetaHelper.powiedz_cos(w);

            Console.WriteLine("=== PRACOWNICY ===");
            Piekarz piekarz = new Piekarz();
            piekarz.Pracuj();

            // 11. Próba utworzenia obiektu klasy abstrakcyjnej
            // Pracownik pracownik = new Pracownik(); //Błąd kompilacji: nie można tworzyć instancji klasy abstrakcyjnej

            Console.WriteLine("\n=== KOLEJNOŚĆ KONSTRUKTORÓW ===");
            A a = new A();
            Console.WriteLine();
            B b = new B();
            Console.WriteLine();
            C c = new C();

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }
}
