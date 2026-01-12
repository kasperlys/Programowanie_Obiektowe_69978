using System;

namespace ComplexNumbersApp
{
    // Interfejs – wszystko co ma moduł
    public interface IModular
    {
        double Module();
    }

    // Liczba zespolona
    public class ComplexNumber : ICloneable, IEquatable<ComplexNumber>, IModular
    {
        private double re;
        private double im;

        public double Re
        {
            get => re;
            set => re = value;
        }

        public double Im
        {
            get => im;
            set => im = value;
        }

        public ComplexNumber(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public override string ToString()
        {
            string znak = im >= 0 ? "+" : "-";
            return $"{re} {znak} {Math.Abs(im)}i";
        }

        // Dodawanie
        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
            => new(a.re + b.re, a.im + b.im);

        // Odejmowanie
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
            => new(a.re - b.re, a.im - b.im);

        // Mnożenie
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
            => new(
                a.re * b.re - a.im * b.im,
                a.re * b.im + a.im * b.re
            );

        // Sprzężenie
        public static ComplexNumber operator -(ComplexNumber z)
            => new(z.re, -z.im);

        // Kopia obiektu
        public object Clone()
            => new ComplexNumber(re, im);

        // Porównanie wartości
        public bool Equals(ComplexNumber other)
        {
            if (other is null) return false;
            return re == other.re && im == other.im;
        }

        public override bool Equals(object obj)
            => obj is ComplexNumber z && Equals(z);

        public override int GetHashCode()
            => HashCode.Combine(re, im);

        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Equals(b);
        }

        public static bool operator !=(ComplexNumber a, ComplexNumber b)
            => !(a == b);

        // Moduł liczby zespolonej
        public double Module()
            => Math.Sqrt(re * re + im * im);
    }

    class Program
    {
        static void Main()
        {
            var z1 = new ComplexNumber(3, 4);
            var z2 = new ComplexNumber(1, -2);

            Console.WriteLine("Liczby:");
            Console.WriteLine($"z1 = {z1}");
            Console.WriteLine($"z2 = {z2}\n");

            Console.WriteLine("Operacje:");
            Console.WriteLine($"z1 + z2 = {z1 + z2}");
            Console.WriteLine($"z1 - z2 = {z1 - z2}");
            Console.WriteLine($"z1 * z2 = {z1 * z2}");
            Console.WriteLine($"Sprzężenie z1 = {-z1}\n");

            var kopia = (ComplexNumber)z1.Clone();
            Console.WriteLine("Porównania:");
            Console.WriteLine($"z1 == kopia ? {z1 == kopia}");
            Console.WriteLine($"z1 == z2 ? {z1 == z2}\n");

            Console.WriteLine("Moduły:");
            Console.WriteLine($"|z1| = {z1.Module():F2}");
            Console.WriteLine($"|z2| = {z2.Module():F2}");
        }
    }
}
