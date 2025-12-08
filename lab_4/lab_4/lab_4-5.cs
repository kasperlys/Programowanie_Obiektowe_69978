var dict = new Dictionary<string, ComplexNumber>()
{
    { "z1", new ComplexNumber(6,7) },
    { "z2", new ComplexNumber(1,2) },
    { "z3", new ComplexNumber(6,7) },
    { "z4", new ComplexNumber(1,-2) },
    { "z5", new ComplexNumber(-5,9) }
};

// a) Wypisz elementy
Console.WriteLine("\na) Słownik (klucz, wartość):");
foreach (var kvp in dict) Console.WriteLine($"{kvp.Key} = {kvp.Value}");

// b) Klucze i wartości
Console.WriteLine("\nb) Klucze:");
foreach (var k in dict.Keys) Console.WriteLine(k);

Console.WriteLine("\nWartości:");
foreach (var v in dict.Values) Console.WriteLine(v);

// c) Czy istnieje klucz z6?
Console.WriteLine("\nc) Czy istnieje z6? " + dict.ContainsKey("z6"));

// d) Min i Max wartości
var minD = dict.Values.Min();
var maxD = dict.Values.Max();
Console.WriteLine($"\nd) Min: {minD}\nMax: {maxD}");

// e) Usuń z3
dict.Remove("z3");

// f) Usuń drugi element słownika
var secondKey = dict.ElementAt(1).Key;
dict.Remove(secondKey);

// g) Wyczyść słownik
dict.Clear();
Console.WriteLine("\ng) Po wyczyszczeniu, Count = " + dict.Count);
