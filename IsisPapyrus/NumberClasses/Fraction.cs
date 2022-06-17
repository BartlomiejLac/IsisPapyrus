using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus
{
    public class Fraction
    {
        // licznik
        public int Numerator;
        // mianownik
        public int Denominator;

        public Fraction(int _n, int _d)
        {
            // w mianowniku nie może być 0
            if (_d == 0)
            {
                throw new ArgumentException("A denominator for a fraction cannot be 0.", nameof(_d));
            }
            Numerator = _n;
            Denominator = _d;
            Simplify();
        }

        // funkcja skracająca ułamek do formy nieskracalnej
        public void Simplify()
        {
            //tu jest algorytm euklidesa to wyznaczania największego wspólnego dzielnika https://pl.wikipedia.org/wiki/Algorytm_Euklidesa#Pseudokod
            int a = Math.Max(Numerator, Denominator);
            int b = Math.Min(Numerator, Denominator);
            while (b != 0)
            {
                int c = a % b;
                a = b;
                b = c;
            }
            // dzielimy licznik i mianownik przez NWD
            Numerator /= a;
            Denominator /= a;
        }

        /* tutaj są przeładowania operetorów, w większości dość oczywiste, więc komentował za bardzo nie będę,
         * ale zaznaczę, że te dwa pierwsze to operatory jednostronne, czyli
         * +ułamek = ułamek, a -ułamek to po prostu przeciwny znak przy liczniku*/
        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.Numerator, a.Denominator);

        public static Fraction operator +(Fraction a, Fraction b)
            => new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);

        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);

        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            if (a.Denominator == b.Denominator) return a.Numerator < b.Numerator;
            return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            if (a.Denominator == b.Denominator) return a.Numerator > b.Numerator;
            return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return (a.Numerator == b.Numerator && a.Denominator == b.Denominator); 
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        public static bool operator <=(Fraction a, Fraction b)
        {
            return !(a > b);
        }

        public static bool operator >=(Fraction a, Fraction b)
        {
            return !(a < b);
        }
    }
}
