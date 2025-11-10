using System;

namespace ComplexNumbersApp
{
    // 2. Interfejs IModular
    public interface IModular
    {
        double Module();
    }

    // 1. Klasa ComplexNumber
    public class ComplexNumber : ICloneable, IEquatable<ComplexNumber>, IModular
    {
        // Prywatne pola
        private double re;
        private double im;

        // Publiczne właściwości
        public double Re
        {
            get { return re; }
            set { re = value; }
        }

        public double Im
        {
            get { return im; }
            set { im = value; }
        }

        // Konstruktor
        public ComplexNumber(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        // Przeciążenie ToString()
        public override string ToString()
        {
            string sign = im >= 0 ? "+" : "-";
            return $"{re} {sign} {Math.Abs(im)}i";
        }

        // Operator +
        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.re + b.re, a.im + b.im);
        }

        // Operator -
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.re - b.re, a.im - b.im);
        }

        // Operator *
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            double realPart = a.re * b.re - a.im * b.im;
            double imagPart = a.re * b.im + a.im * b.re;
            return new ComplexNumber(realPart, imagPart);
        }

        // Operator sprzężenia (unarne -)
        public static ComplexNumber operator -(ComplexNumber a)
        {
            return new ComplexNumber(a.re, -a.im);
        }

        // Implementacja interfejsu ICloneable
        public object Clone()
        {
            return new ComplexNumber(this.re, this.im);
        }

        // Implementacja interfejsu IEquatable
        public bool Equals(ComplexNumber other)
        {
            if (other is null)
                return false;
            return this.re == other.re && this.im == other.im;
        }

        // Przeciążenie Equals(object)
        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber)
                return Equals((ComplexNumber)obj);
            return false;
        }

        // GetHashCode() – dobra praktyka przy porównywaniu obiektów
        public override int GetHashCode()
        {
            return re.GetHashCode() ^ im.GetHashCode();
        }

        // Operatory == oraz !=
        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (a is null || b is null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(ComplexNumber a, ComplexNumber b)
        {
            return !(a == b);
        }

        // 3. Implementacja IModular
        public double Module()
        {
            return Math.Sqrt(re * re + im * im);
        }
    }

    // 4. Klasa Program z metodą Main()
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber z1 = new ComplexNumber(3, 4);
            ComplexNumber z2 = new ComplexNumber(1, -2);

            Console.WriteLine($"z1 = {z1}");
            Console.WriteLine($"z2 = {z2}");
            Console.WriteLine();

            // Test operatorów
            Console.WriteLine($"z1 + z2 = {z1 + z2}");
            Console.WriteLine($"z1 - z2 = {z1 - z2}");
            Console.WriteLine($"z1 * z2 = {z1 * z2}");
            Console.WriteLine($"Sprzężenie z1 = {-z1}");
            Console.WriteLine();

            // Test ICloneable
            ComplexNumber z3 = (ComplexNumber)z1.Clone();
            Console.WriteLine($"Kopia z1: {z3}");

            // Test porównania
            Console.WriteLine($"z1 == z3 ? {z1 == z3}");
            Console.WriteLine($"z1 == z2 ? {z1 == z2}");
            Console.WriteLine();

            // Test modułu
            Console.WriteLine($"|z1| = {z1.Module():F2}");
            Console.WriteLine($"|z2| = {z2.Module():F2}");
        }
    }
}
