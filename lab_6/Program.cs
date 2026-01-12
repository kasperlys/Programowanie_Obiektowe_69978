using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

public class Student
{
    public int StudentId { get; set; }
    public string Imie { get; set; } = "";
    public string Nazwisko { get; set; } = "";
    public List<Ocena> Oceny { get; set; } = new();
}

public class Ocena
{
    public int OcenaId { get; set; }
    public double Wartosc { get; set; }
    public string Przedmiot { get; set; } = "";
    public int StudentId { get; set; }
}

public class Program
{
    static string connectionString =
        "Data Source=10.200.2.28;" +
        "Initial Catalog=studenci_69978;" +
        "Integrated Security=True;" +
        "Encrypt=True;" +
        "TrustServerCertificate=True";

    public static void Main()
    {
        try
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
            Console.WriteLine("Połączono z bazą.\n");

            WyswietlStudentow(connection);
            Console.WriteLine();

            WyswietlStudentaPoId(connection, 1);
            Console.WriteLine();

            var studenci = PobierzStudentowZOcenami(connection);
            WyswietlStudentowZOcenami(studenci);

            DodajStudenta(connection, new Student
            {
                Imie = "Adam",
                Nazwisko = "Nowak"
            });

            DodajOcene(connection, new Ocena
            {
                StudentId = 1,
                Przedmiot = "Matematyka",
                Wartosc = 4.5
            });

            UsunOcenyZGeografii(connection);
            AktualizujOcene(connection, 1, 5.0);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
    }

    // Zadanie 4
    static void WyswietlStudentow(SqlConnection connection)
    {
        string sql = "SELECT student_id, imie, nazwisko FROM student";
        using SqlCommand cmd = new(sql, connection);
        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("Lista studentów:");
        while (reader.Read())
        {
            Console.WriteLine($"{reader["student_id"]} {reader["imie"]} {reader["nazwisko"]}");
        }
    }

    // Zadanie 5
    static void WyswietlStudentaPoId(SqlConnection connection, int id)
    {
        string sql = "SELECT imie, nazwisko FROM student WHERE student_id = @id";
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@id", id);

        using SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            Console.WriteLine($"Student ID {id}: {reader["imie"]} {reader["nazwisko"]}");
        }
    }

    // Zadanie 6
    static List<Student> PobierzStudentowZOcenami(SqlConnection connection)
    {
        var studenci = new Dictionary<int, Student>();

        string sql = @"
            SELECT s.student_id, s.imie, s.nazwisko,
                   o.ocena_id, o.wartosc, o.przedmiot
            FROM student s
            LEFT JOIN ocena o ON s.student_id = o.student_id";

        using SqlCommand cmd = new(sql, connection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int id = (int)reader["student_id"];

            if (!studenci.ContainsKey(id))
            {
                studenci[id] = new Student
                {
                    StudentId = id,
                    Imie = reader["imie"].ToString()!,
                    Nazwisko = reader["nazwisko"].ToString()!
                };
            }

            if (reader["ocena_id"] != DBNull.Value)
            {
                studenci[id].Oceny.Add(new Ocena
                {
                    OcenaId = (int)reader["ocena_id"],
                    Wartosc = (double)reader["wartosc"],
                    Przedmiot = reader["przedmiot"].ToString()!
                });
            }
        }

        return new List<Student>(studenci.Values);
    }

    static void WyswietlStudentowZOcenami(List<Student> studenci)
    {
        Console.WriteLine("\nStudenci z ocenami:");
        foreach (var s in studenci)
        {
            Console.WriteLine($"{s.Imie} {s.Nazwisko}");
            foreach (var o in s.Oceny)
                Console.WriteLine($"  {o.Przedmiot}: {o.Wartosc}");
        }
    }

    // Zadanie 7
    static void DodajStudenta(SqlConnection connection, Student student)
    {
        string sql = "INSERT INTO student(imie, nazwisko) VALUES (@imie, @nazwisko)";
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@imie", student.Imie);
        cmd.Parameters.AddWithValue("@nazwisko", student.Nazwisko);
        cmd.ExecuteNonQuery();
    }

    // Zadanie 8
    static bool CzyPoprawnaOcena(double ocena)
    {
        return ocena >= 2.0 &&
               ocena <= 5.0 &&
               (ocena * 2) % 1 == 0 &&
               ocena != 2.5;
    }

    static void DodajOcene(SqlConnection connection, Ocena ocena)
    {
        if (!CzyPoprawnaOcena(ocena.Wartosc))
            throw new ArgumentException("Niepoprawna wartość oceny");

        string sql = @"INSERT INTO ocena(wartosc, przedmiot, student_id)
                       VALUES (@wartosc, @przedmiot, @student_id)";

        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@wartosc", ocena.Wartosc);
        cmd.Parameters.AddWithValue("@przedmiot", ocena.Przedmiot);
        cmd.Parameters.AddWithValue("@student_id", ocena.StudentId);
        cmd.ExecuteNonQuery();
    }

    // Zadanie 9
    static void UsunOcenyZGeografii(SqlConnection connection)
    {
        string sql = "DELETE FROM ocena WHERE przedmiot = 'geografia'";
        using SqlCommand cmd = new(sql, connection);
        cmd.ExecuteNonQuery();
    }

    // Zadanie 10
    static void AktualizujOcene(SqlConnection connection, int ocenaId, double nowaWartosc)
    {
        if (!CzyPoprawnaOcena(nowaWartosc))
            throw new ArgumentException("Niepoprawna wartość oceny");

        string sql = "UPDATE ocena SET wartosc = @wartosc WHERE ocena_id = @id";
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@wartosc", nowaWartosc);
        cmd.Parameters.AddWithValue("@id", ocenaId);
        cmd.ExecuteNonQuery();
    }
}
