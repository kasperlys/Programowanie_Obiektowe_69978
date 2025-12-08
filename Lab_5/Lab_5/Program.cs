using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Linq;

public class Student
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public List<int> Oceny { get; set; }
}

class Program
{
    static void Main()
    {
        //Wywołuj tu te funkcje, które chcesz testować:
        //WriteToFile();
        //ReadFromFile();
        //AppendToFile();
        //SerializeStudentsToJson();
        //DeserializeStudentsFromJson();
        //SerializeStudentsToXml();
        //DeserializeStudentsFromXml();
        //ReadCsvFile();
        //ReadCsvAndCalculateAverages();
        //FilterIrisCsv();
    }

    // ----------------------------- 2 -----------------------------
    // Funkcja zapisująca wiele linii do pliku
    static void WriteToFile()
    {
        List<string> lines = new List<string>();
        Console.WriteLine("Podaj tekst (wpisz 'stop', aby zakończyć):");

        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "stop") break;
            lines.Add(input);
        }

        File.WriteAllLines("output.txt", lines);
        Console.WriteLine("Zapisano do pliku output.txt");
    }

    // ----------------------------- 3 -----------------------------
    // Funkcja odczytująca plik linia po linii
    static void ReadFromFile()
    {
        if (!File.Exists("output.txt"))
        {
            Console.WriteLine("Plik output.txt nie istnieje!");
            return;
        }

        foreach (string line in File.ReadLines("output.txt"))
        {
            Console.WriteLine(line);
        }
    }

    // ----------------------------- 4 -----------------------------
    // Dopisywanie nowych linii do pliku
    static void AppendToFile()
    {
        Console.WriteLine("Podaj tekst do dopisania (stop kończy):");

        using StreamWriter sw = new StreamWriter("output.txt", append: true);

        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "stop") break;
            sw.WriteLine(input);
        }

        Console.WriteLine("Dopisano dane do pliku output.txt");
    }

    // ----------------------------- 6 -----------------------------
    // Serializacja listy studentów do JSON
    static void SerializeStudentsToJson()
    {
        List<Student> students = new()
        {
            new Student { Imie = "Jan", Nazwisko = "Kowalski", Oceny = new List<int>{5,4,3}},
            new Student { Imie = "Anna", Nazwisko = "Nowak", Oceny = new List<int>{5,5,4}}
        };

        string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("students.json", json);

        Console.WriteLine("Zapisano students.json");
    }

    // ----------------------------- 7 -----------------------------
    // Deserializacja studentów z JSON
    static void DeserializeStudentsFromJson()
    {
        if (!File.Exists("students.json"))
        {
            Console.WriteLine("Brak pliku students.json!");
            return;
        }

        string json = File.ReadAllText("students.json");
        var students = JsonSerializer.Deserialize<List<Student>>(json);

        foreach (var s in students)
        {
            Console.WriteLine($"{s.Imie} {s.Nazwisko}: {string.Join(", ", s.Oceny)}");
        }
    }

    // ----------------------------- 8 -----------------------------
    // Serializacja listy studentów do XML
    static void SerializeStudentsToXml()
    {
        List<Student> students = new()
        {
            new Student { Imie = "Adam", Nazwisko = "Zieliński", Oceny = new List<int>{3,4,5}},
            new Student { Imie = "Kasia", Nazwisko = "Wiśniewska", Oceny = new List<int>{5,5,5}}
        };

        XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
        using FileStream fs = new FileStream("students.xml", FileMode.Create);
        serializer.Serialize(fs, students);

        Console.WriteLine("Zapisano students.xml");
    }

    // ----------------------------- 9 -----------------------------
    // Deserializacja studentów z XML
    static void DeserializeStudentsFromXml()
    {
        if (!File.Exists("students.xml"))
        {
            Console.WriteLine("Brak pliku students.xml!");
            return;
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
        using FileStream fs = new FileStream("students.xml", FileMode.Open);
        var students = (List<Student>)serializer.Deserialize(fs);

        foreach (var s in students)
        {
            Console.WriteLine($"{s.Imie} {s.Nazwisko}: {string.Join(", ", s.Oceny)}");
        }
    }

    // ----------------------------- 10 -----------------------------
    // Odczyt pliku CSV linia po linii
    static void ReadCsvFile()
    {
        string path = "iris.csv";
        if (!File.Exists(path))
        {
            Console.WriteLine("Brak pliku iris.csv!");
            return;
        }

        foreach (string line in File.ReadLines(path))
        {
            Console.WriteLine(line);
        }
    }

    // ----------------------------- 11 -----------------------------
    // Odczyt CSV i obliczenie średnich wartości numerycznych kolumn
    static void ReadCsvAndCalculateAverages()
    {
        string path = "iris.csv";
        if (!File.Exists(path))
        {
            Console.WriteLine("Brak pliku iris.csv!");
            return;
        }

        var lines = File.ReadAllLines(path).ToList();
        var header = lines[0].Split(',');

        // Kolumny numeryczne: 4 pierwsze
        double[] sums = new double[4];
        int count = 0;

        foreach (var line in lines.Skip(1))
        {
            var parts = line.Split(',');
            for (int i = 0; i < 4; i++)
                sums[i] += double.Parse(parts[i]);
            count++;
        }

        Console.WriteLine("Średnie wartości kolumn:");
        for (int i = 0; i < 4; i++)
            Console.WriteLine($"{header[i]}: {sums[i] / count:F3}");
    }

    // ----------------------------- 12 -----------------------------
    // Filtrowanie pliku iris.csv i zapis do iris_filtered.csv
    static void FilterIrisCsv()
    {
        string path = "iris.csv";
        if (!File.Exists(path))
        {
            Console.WriteLine("Brak pliku iris.csv!");
            return;
        }

        var lines = File.ReadAllLines(path);
        var header = lines[0].Split(',');
        int idxLength = Array.IndexOf(header, "sepal length");
        int idxWidth = Array.IndexOf(header, "sepal width");
        int idxClass = Array.IndexOf(header, "class");

        List<string> filtered = new();
        filtered.Add("sepal length,sepal width,class");

        foreach (var line in lines.Skip(1))
        {
            var p = line.Split(',');
            double sepalLength = double.Parse(p[idxLength]);

            if (sepalLength < 5)
            {
                filtered.Add($"{p[idxLength]},{p[idxWidth]},{p[idxClass]}");
            }
        }

        File.WriteAllLines("iris_filtered.csv", filtered);
        Console.WriteLine("Zapisano iris_filtered.csv");
    }
}
