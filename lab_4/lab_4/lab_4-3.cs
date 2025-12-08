var list = new List<ComplexNumber>()
{
    new ComplexNumber(3,4),
    new ComplexNumber(1,-2),
    new ComplexNumber(0,7),
    new ComplexNumber(-3,-4),
    new ComplexNumber(2,1)
};

// Te same operacje co wcześniej:
list.Sort();
Console.WriteLine("\nLista po sortowaniu:");
list.ForEach(Console.WriteLine);

// a) Usuń drugi element
list.RemoveAt(1);
Console.WriteLine("\na) Po usunięciu drugiego elementu:");
list.ForEach(Console.WriteLine);

// b) Usuń najmniejszy
var smallest = list.Min();
list.Remove(smallest);
Console.WriteLine("\nb) Po usunięciu najmniejszego:");
list.ForEach(Console.WriteLine);

// c) Wyczyść listę
list.Clear();
Console.WriteLine("\nc) Lista po wyczyszczeniu, Count = " + list.Count);
