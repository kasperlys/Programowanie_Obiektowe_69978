using System;
using System.Collections.Generic;
using System.Linq;

//
// ZADANIE 1 – Klasa ComplexNumber z IComparable
//

public interface IModular
{
    double Module();
}

public class ComplexNumber : ICloneable, IEquatable<ComplexNumber>, IModular, IComparable<ComplexNumber>
{
    public double Re { get; set; }
    public double Im { get; set; }

    public ComplexNumber(double re, double im)
    {
        Re = re;
        Im = im;
    }

    public override string ToString()
    {
        string sign = Im >= 0 ? "+" : "-";
        return $"{Re} {sign} {Math.Abs(Im)}i";
    }

    public double Module() => Math.Sqrt(Re * Re + Im * Im);

    public int CompareTo(ComplexNumber other)
        => Module().CompareTo(other.Module());

    public object Clone() => new ComplexNumber(Re, Im);

    public bool Equals(ComplexNumber other)
        => other is not null && Re == other.Re && Im == other.Im;

    public override bool Equals(object obj)
        => obj is ComplexNumber c && Equals(c);

    public override int GetHashCode()
        => HashCode.Combine(Re, Im);

    public static bool operator ==(ComplexNumber a, ComplexNumber b)
        => a?.Equals(b) ?? b is null;

    public static bool operator !=(ComplexNumber a, ComplexNumber b)
        => !(a == b);
}

class Program
{
    static void Main()
    {
        Zadanie2();
        Zadanie3();
        Zadanie4();
        Zadanie5();
    }

    //
    // ZADANIE 2 – Operacje na tablicy
    //

    static void Zadanie2()
    {
        ComplexNumber[] arr =
        {
            new ComplexNumber(3, 4),
            new ComplexNumber(1, -2),
            new ComplexNumber(6, 7),
            new ComplexNumber(-3, 1),
            new ComplexNumber(0, -5)
        };

        // a) wypisanie
        Console.WriteLine("Tablica:");
        foreach (var n in arr) Console.WriteLine(n);

        // b) sortowanie
        Array.Sort(arr);
        Console.WriteLine("\nPosortowane:");
        foreach (var n in arr) Console.WriteLine(n);

        // c) min i max
        Console.WriteLine($"\nMin: {arr.Min()}");
        Console.WriteLine($"Max: {arr.Max()}");

        // d) filtracja
        Console.WriteLine("\nIm < 0:");
        foreach (var n in arr.Where(x => x.Im < 0))
            Console.WriteLine(n);

        Console.WriteLine();
    }

    //
    // ZADANIE 3 – Lista
    //

    static void Zadanie3()
    {
        List<ComplexNumber> list = new()
        {
            new ComplexNumber(3, 4),
            new ComplexNumber(1, -2),
            new ComplexNumber(6, 7),
            new ComplexNumber(-3, 1),
            new ComplexNumber(0, -5)
        };

        Console.WriteLine("Lista:");
        list.ForEach(x => Console.WriteLine(x));

        // a) usuń drugi element
        list.RemoveAt(1);
        Console.WriteLine("\nPo usunięciu drugiego:");
        list.ForEach(x => Console.WriteLine(x));

        // b) usuń najmniejszy
        list.Remove(list.Min());
        Console.WriteLine("\nPo usunięciu najmniejszego:");
        list.ForEach(x => Console.WriteLine(x));

        // c) usuń wszystkie
        list.Clear();
        Console.WriteLine("\nLista po wyczyszczeniu — pusta\n");
    }

    //
    // ZADANIE 4 – HashSet
    //

    static void Zadanie4()
    {
        var z1 = new ComplexNumber(6, 7);
        var z2 = new ComplexNumber(1, 2);
        var z3 = new ComplexNumber(6, 7);
        var z4 = new ComplexNumber(1, -2);
        var z5 = new ComplexNumber(-5, 9);

        HashSet<ComplexNumber> set = new() { z1, z2, z3, z4, z5 };

        Console.WriteLine("HashSet:");
        foreach (var z in set) Console.WriteLine(z);

        Console.WriteLine("\nMin:");
        Console.WriteLine(set.Min());

        Console.WriteLine("\nMax:");
        Console.WriteLine(set.Max());

        Console.WriteLine("\nSortowanie:");
        foreach (var z in set.OrderBy(x => x))
            Console.WriteLine(z);

        Console.WriteLine("\nFiltrowanie (Im < 0):");
        foreach (var z in set.Where(x => x.Im < 0))
            Console.WriteLine(z);

        Console.WriteLine();
    }

    //
    // ZADANIE 5 – Słownik
    //

    static void Zadanie5()
    {
        Dictionary<string, ComplexNumber> dict = new()
        {
            { "z1", new ComplexNumber(6, 7) },
            { "z2", new ComplexNumber(1, 2) },
            { "z3", new ComplexNumber(6, 7) },
            { "z4", new ComplexNumber(1, -2) },
            { "z5", new ComplexNumber(-5, 9) }
        };

        // a) wypisanie klucz–wartość
        Console.WriteLine("Słownik:");
        foreach (var pair in dict)
            Console.WriteLine($"{pair.Key} = {pair.Value}");

        // b) klucze i wartości
        Console.WriteLine("\nKlucze:");
        foreach (var k in dict.Keys) Console.WriteLine(k);

        Console.WriteLine("\nWartości:");
        foreach (var v in dict.Values) Console.WriteLine(v);

        // c) sprawdzenie klucza z6
        Console.WriteLine($"\nCzy istnieje z6? {dict.ContainsKey("z6")}");

        // d) min i max
        Console.WriteLine($"\nMin: {dict.Values.Min()}");
        Console.WriteLine($"Max: {dict.Values.Max()}");

        // e) usuń z3
        dict.Remove("z3");

        // f) usuń drugi element
        if (dict.Count > 1)
        {
            string key = dict.ElementAt(1).Key;
            dict.Remove(key);
        }

        // g) wyczyść
        dict.Clear();
        Console.WriteLine("\nSłownik wyczyszczony.\n");
    }
}
