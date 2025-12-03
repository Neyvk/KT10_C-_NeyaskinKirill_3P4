using System;
interface IComparable<T>
{
    int CompareTo(T other);
}
struct ComplexNumber : IComparable<ComplexNumber>
{
    public double Real { get; }
    public double Imag { get; }

    public ComplexNumber(double real, double imag)
    {
        Real = real;
        Imag = imag;
    }

    public int CompareTo(ComplexNumber other)
    {
        double modulus1 = Math.Sqrt(Real * Real + Imag * Imag);
        double modulus2 = Math.Sqrt(other.Real * other.Real + other.Imag * other.Imag);

        if (modulus1 > modulus2) return 1;
        if (modulus1 < modulus2) return -1;
        return 0;
    }

    public override string ToString() => $"{Real} + {Imag}i";
}

struct RationalNumber : IComparable<RationalNumber>
{
    public int Numerator { get; }
    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator == 0 ? 1 : denominator;
    }

    public int CompareTo(RationalNumber other)
    {
        double value1 = (double)Numerator / Denominator;
        double value2 = (double)other.Numerator / other.Denominator;

        if (value1 > value2) return 1;
        if (value1 < value2) return -1;
        return 0;
    }

    public override string ToString() => $"{Numerator}/{Denominator}";
}


class Program
{
    static void Main()
    {
        ComplexNumber c1 = new ComplexNumber(3, 4);
        ComplexNumber c2 = new ComplexNumber(1, 2);

        Console.WriteLine($"Комплексные: {c1} ? {c2} -> {c1.CompareTo(c2)}");

        RationalNumber r1 = new RationalNumber(3, 4);
        RationalNumber r2 = new RationalNumber(2, 3);

        Console.WriteLine($"Рациональные: {r1} ? {r2} -> {r1.CompareTo(r2)}");

        Console.ReadLine();
    }
}
