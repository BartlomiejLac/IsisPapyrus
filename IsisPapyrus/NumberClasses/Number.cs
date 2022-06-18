using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus
{
    public class Number
    {
        // część całkowita
        public int WholeNumber;
        // tutaj zaznaczam czy liczba jest ujemna
        public bool IsNegative = false;
        // tutaj jest ułamek właściwy, który stanowi część ułamkową liczby
        public Fraction ProperFraction;
        // lista mianowników ułamków jednostkowych (o liczniku 1) stanowiąca rozkład powyższego ułamka
        public List<int> FractionDecomposition;
        // ciąg znaków symbolizujący egipski zapis liczby
        public String EgyptianRepresentation;

        public Number(int _w, int _n, int _d)
        {
            WholeNumber = _w;
            // jeżeli ktoś podał ujemną wartość całkowitą to oznaczam że liczba ujemna, ale do WholeNumber zapisuję dodatnią
            if (_w < 0)
            {
                WholeNumber *= -1;
                IsNegative = !IsNegative;
            }
            // jeżeli ktoś zaznaczył licznik jako ujemny, to "odwracam" ujemność liczby, a licznik zapisuję jako dodatni
            if (_n < 0)
            {
                _n *= -1;
                IsNegative = !IsNegative;
            }
            // jeżeli ktoś zaznaczył mianownik jako ujemny, to "odwracam" ujemność liczby, a mianownik zapisuję jako dodatni
            if (_d < 0)
            {
                _d *= -1;
                IsNegative = !IsNegative;
            }
            // jeżeli ułamek jest niewłaściwy, to odejmuję od licznika aż będzie ułamkiem właściwym
            while (_d <= _n)
            {
                _n -= _d;
                WholeNumber++;
            }
            ProperFraction = new Fraction(_n, _d);
            FractionDecomposition = DecomposeFraction(ProperFraction);
            EgyptianRepresentation = EgyptianNumberParser.ConvertToEgyptian(this);
        }

        public Number(int _w, List<int> _d)
        {
            WholeNumber = _w;
            if (_w < 0)
            {
                WholeNumber *= -1;
                IsNegative = !IsNegative;
            }
            FractionDecomposition = _d;
            Fraction current = new Fraction(0, 1);
            foreach(int _i in _d)
            {
                current = current + new Fraction(1, _i);
            }
            ProperFraction = current;
            EgyptianRepresentation = EgyptianNumberParser.ConvertToEgyptian(this);
        }

        //zachłanny algorytm fibbonacciego do rozkładu na ułamki jednostkowe https://en.wikipedia.org/wiki/Egyptian_fraction#Later_usage tu o tym dużo jest
        public List<int> DecomposeFraction(Fraction f)
        {
            var list = new List<int>();
            // jeżeli liczba jest całkowita, to nie ma czego rozkładać, wychodzimy
            if (f.Numerator == 0)
            {
                return list;
            }
            int currentNum = f.Numerator;
            int currentDen = f.Denominator;
            try
            {
                while (currentNum != 1)
                {
                    // https://wikimedia.org/api/rest_v1/media/math/render/svg/e0a11c8eb8638644da384cc479d2a616501014ac
                    // to tutaj próbuję osiągnąć w kolejnych iteracjach...dopóki ostatni element nie będzie miał jednostkowego licznika
                    // ten ceil poniżej, to ceil(y/x) ze zdjęcia
                    double ceil = Math.Ceiling(Convert.ToDouble((double)currentDen / currentNum));
                    int unaryDen = Convert.ToInt32(ceil);
                    list.Add(unaryDen);
                    // nextNum -> (-y) mod x
                    int nextNum = (-1 * currentDen) % currentNum;
                    // niestety mod w C# nie do końca działa z liczbami ujemnymi tak jak bym chciał, więc jeśli daje ujemną resztę to muszę to poprawić
                    if (nextNum < 0)
                    {
                        nextNum += currentNum;
                    }
                    // jeżeli reszta jest zerowa to koniec rozkładu
                    if (nextNum == 0) break;
                    // nextDen -> y * ceil(y/x) ze zdjęcia...tutaj bardzo często jest Integer Overflow, bo się robią kosmiczne liczby, więc jest try-catch oraz instrukcja checked
                    int nextDen = checked(currentDen * unaryDen);
                    // jeżeli mianownik miałby być powyżej 9999999 to i tak go nie zapiszemy, więc kończymy tutaj, dlatego nigdy nie będziemy mieli tak dużych mianowników
                    if (nextDen > 9999999) return list;
                    currentNum = nextNum;
                    currentDen = nextDen;
                }
                // jeżeli pętla się skończyła ale została jakaś reszta to też dopisujemy
                if (currentNum == 1)
                {
                    list.Add(currentDen);
                }
            }
            catch (OverflowException) { Console.WriteLine("Overflow Detected!");  }

            return list;
        }


        // zamiana na "ludzki" string dla czytelności i testów
        // zapis 25 (2/3) 1/2 1/6 oznacza liczbę 25 i dwie trzecie, następnie podany jest rozkład części ułamkowej na jednostkowe
        public override string ToString()
        {
            /*StringBuilder sb = new StringBuilder();
            if (IsNegative) sb.Append('-');
            sb.Append(WholeNumber.ToString());
            sb.Append(" (" + ProperFraction.Numerator.ToString() + "/" + ProperFraction.Denominator.ToString() + ")");
            foreach (int i in FractionDecomposition)
            {
                sb.Append(" 1/");
                sb.Append(i.ToString());
            }
            return sb.ToString();*/
            return EgyptianRepresentation;
        }

        // tutaj jest zamiana liczby na ułamek (niewłaściwy), np. 2 i 2/3 na 8/3
        public Fraction ToFraction()
        {
            int newNumerator = this.ProperFraction.Denominator * this.WholeNumber + this.ProperFraction.Numerator;
            if (IsNegative) newNumerator *= -1;
            return new Fraction(newNumerator, this.ProperFraction.Denominator); ;
        }

        // przeciążenia operatorów, podobnie jak w ułamkach, zazwyczaj zresztą zamieniam na ułamki niewłaściwe i na nich wykonuję działania, bo to zdecydowanie prostsze
        public static Number operator +(Number a) => a;
        public static Number operator -(Number a) => new Number(-1 * a.WholeNumber, a.ProperFraction.Numerator, a.ProperFraction.Denominator);
        public static Number operator +(Number a, Number b)
        {
            var resultFraction = a.ToFraction() + b.ToFraction();
            return new Number(0, resultFraction.Numerator, resultFraction.Denominator);
        }

        public static Number operator -(Number a, Number b)
        {
            var resultFraction = a.ToFraction() - b.ToFraction();
            return new Number(0, resultFraction.Numerator, resultFraction.Denominator);
        }

        public static Number operator *(Number a, Number b)
        {
            var resultFraction = a.ToFraction() * b.ToFraction();
            return new Number(0, resultFraction.Numerator, resultFraction.Denominator);
        }

        public static Number operator /(Number a, Number b)
        {
            var resultFraction = a.ToFraction() / b.ToFraction();
            return new Number(0, resultFraction.Numerator, resultFraction.Denominator);
        }

        public static bool operator <(Number a, Number b)
        {
            return a.ToFraction() < b.ToFraction();
        }

        public static bool operator >(Number a, Number b)
        {
            return a.ToFraction() > b.ToFraction();
        }

        public static bool operator ==(Number a, Number b)
        {
            return a.ToFraction() == b.ToFraction();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Number)) return false;
            Number o = obj as Number;
            return this == o;
        }

        public override int GetHashCode()
        {
            return WholeNumber;
        }

        public static bool operator !=(Number a, Number b)
        {
            return !(a == b);
        }

        public static bool operator <=(Number a, Number b)
        {
            return !(a > b);
        }

        public static bool operator >=(Number a, Number b)
        {
            return !(a < b);
        }
    }
}
