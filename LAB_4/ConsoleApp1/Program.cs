using System;
using System.Collections.Generic;
using System.Linq;

// Interfejs – coś co ma moduł
public interface IModular
{
    double Module();
}

// Liczba zespolona
public class ComplexNumber :
    ICloneable,
    IEquatable<ComplexNumber>,
    IComparable<ComplexNumber>,
    IModular
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
        string znak = Im >= 0 ? "+" : "-";
        return Re + " " + znak + " " + Math.Abs(Im) + "i";
    }

    public double Module()
    {
        return Math.Sqrt(Re * Re + Im * Im);
    }

    // Porównanie po module
    public int CompareTo(ComplexNumber other)
    {
        if (other == null) return 1;
        return Module().CompareTo(other.Module());
    }

    public object Clone()
    {
        return new ComplexNumber(Re, Im);
    }

    public bool Equals(ComplexNumber other)
    {
        return other != null && Re == other.Re && Im == other.Im;
    }

    public override bool Equals(object obj)
    {
        if (obj is ComplexNumber)
            return Equals((ComplexNumber)obj);
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Re, Im);
    }

    public static bool operator ==(ComplexNumber a, ComplexNumber b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(ComplexNumber a, ComplexNumber b)
    {
        return !(a == b);
    }
}

class Program
{
    static void Main()
    {
        Tablica();
        Lista();
        HashSetTest();
        Slownik();
    }

    // ===== TABLICA =====
    static void Tablica()
    {
        ComplexNumber[] arr =
        {
            new ComplexNumber(3, 4),
            new ComplexNumber(1, -2),
            new ComplexNumber(6, 7),
            new ComplexNumber(-3, 1),
            new ComplexNumber(0, -5)
        };

        Console.WriteLine("Tablica:");
        foreach (var z in arr)
            Console.WriteLine(z);

        Array.Sort(arr);
        Console.WriteLine("\nPosortowane:");
        foreach (var z in arr)
            Console.WriteLine(z);

        Console.WriteLine("\nMin: " + arr.Min());
        Console.WriteLine("Max: " + arr.Max());

        Console.WriteLine("\nIm < 0:");
        foreach (var z in arr.Where(x => x.Im < 0))
            Console.WriteLine(z);

        Console.WriteLine();
    }

    // ===== LISTA =====
    static void Lista()
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

        list.RemoveAt(1);
        Console.WriteLine("\nPo usunięciu drugiego:");
        list.ForEach(x => Console.WriteLine(x));

        list.Remove(list.Min());
        Console.WriteLine("\nPo usunięciu najmniejszego:");
        list.ForEach(x => Console.WriteLine(x));

        list.Clear();
        Console.WriteLine("\nLista wyczyszczona\n");
    }

    // ===== HASHSET =====
    static void HashSetTest()
    {
        HashSet<ComplexNumber> set = new()
        {
            new ComplexNumber(6, 7),
            new ComplexNumber(1, 2),
            new ComplexNumber(6, 7),
            new ComplexNumber(1, -2),
            new ComplexNumber(-5, 9)
        };

        Console.WriteLine("HashSet:");
        foreach (var z in set)
            Console.WriteLine(z);

        Console.WriteLine("\nMin: " + set.Min());
        Console.WriteLine("Max: " + set.Max());

        Console.WriteLine("\nPosortowane:");
        foreach (var z in set.OrderBy(x => x))
            Console.WriteLine(z);

        Console.WriteLine("\nIm < 0:");
        foreach (var z in set.Where(x => x.Im < 0))
            Console.WriteLine(z);

        Console.WriteLine();
    }

    // ===== SŁOWNIK =====
    static void Slownik()
    {
        Dictionary<string, ComplexNumber> dict = new()
        {
            { "z1", new ComplexNumber(6, 7) },
            { "z2", new ComplexNumber(1, 2) },
            { "z3", new ComplexNumber(6, 7) },
            { "z4", new ComplexNumber(1, -2) },
            { "z5", new ComplexNumber(-5, 9) }
        };

        Console.WriteLine("Słownik:");
        foreach (var pair in dict)
            Console.WriteLine(pair.Key + " = " + pair.Value);

        Console.WriteLine("\nKlucze:");
        foreach (var k in dict.Keys)
            Console.WriteLine(k);

        Console.WriteLine("\nWartości:");
        foreach (var v in dict.Values)
            Console.WriteLine(v);

        Console.WriteLine("\nCzy istnieje z6? " + dict.ContainsKey("z6"));

        Console.WriteLine("\nMin: " + dict.Values.Min());
        Console.WriteLine("Max: " + dict.Values.Max());

        dict.Remove("z3");

        if (dict.Count > 1)
        {
            string key = dict.ElementAt(1).Key;
            dict.Remove(key);
        }

        dict.Clear();
        Console.WriteLine("\nSłownik wyczyszczony\n");
    }
}
