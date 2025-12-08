var set = new HashSet<ComplexNumber>()
{
    new ComplexNumber(6,7),   // z1
    new ComplexNumber(1,2),   // z2
    new ComplexNumber(6,7),   // z3 — duplikat
    new ComplexNumber(1,-2),  // z4
    new ComplexNumber(-5,9)   // z5
};

Console.WriteLine("\na) Zawartość HashSet:");
foreach (var z in set) Console.WriteLine(z);

// b) Operacje (minimum, maksimum, sortowanie, filtrowanie)
Console.WriteLine("\nb) Min: " + set.Min());
Console.WriteLine("Max: " + set.Max());

Console.WriteLine("\nSortowanie HashSet (używając LINQ):");
foreach (var z in set.OrderBy(z => z.Module())) Console.WriteLine(z);

Console.WriteLine("\nFiltrowanie (Im<0):");
foreach (var z in set.Where(z => z.Im < 0)) Console.WriteLine(z);
