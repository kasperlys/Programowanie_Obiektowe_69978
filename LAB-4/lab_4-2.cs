ComplexNumber[] arr =
{
    new ComplexNumber(3, 4),     // |z|=5
    new ComplexNumber(1, -2),
    new ComplexNumber(0, 7),
    new ComplexNumber(-3, -4),
    new ComplexNumber(2, 1)
};

// a) Wypisanie foreach
Console.WriteLine("a) Tablica:");
foreach (var z in arr) Console.WriteLine(z);

// b) Sortowanie po module
Array.Sort(arr);
Console.WriteLine("\nb) Posortowana:");
foreach (var z in arr) Console.WriteLine(z);

// c) Minimum i maksimum
var min = arr.Min();
var max = arr.Max();
Console.WriteLine($"\nc) Min: {min}");
Console.WriteLine($"Max: {max}");

// d) Filtrowanie liczb z ujemną częścią urojoną
var filtered = arr.Where(z => z.Im < 0);
Console.WriteLine("\nd) Filtrowanie (Im < 0):");
foreach (var z in filtered) Console.WriteLine(z);
