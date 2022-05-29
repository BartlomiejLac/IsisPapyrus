using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsirisInterpreter
{
    // Klasa zawierająca metody do translacji liczb na egipski ciąg znaków
    public class EgyptianNumberParser
    {
        public static String ConvertToEgyptian(Number n)
        {
            // Jeżeli liczba to zero (bez ułamka) to wypisz symbol dla 0
            if (n.WholeNumber == 0 && n.ProperFraction.Numerator == 0)
            {
                return "𓄤";
            }
            StringBuilder sb = new StringBuilder();
            // Znak ujemności na początek jeżeli liczba jest ujemna
            if (n.IsNegative) sb.Append("𓂻");
            // Jeżeli liczba zawiera część całkowitą to dodaj translację tej liczby do ciągu.
            if (n.WholeNumber != 0)
            {
                sb.Append(IntToEgyptian(n.WholeNumber));
            }
            // Przerwa
            sb.Append(" ");
            // Dodaj translację każdego z ułamków z rozkładu jednostkowego do ciągu
            foreach (int i in n.FractionDecomposition)
            {
                // symbol ułamka
                sb.Append("𓂋");
                // translacja mianownika
                sb.Append(IntToEgyptian(i));
            }
            return sb.ToString();
        }
        // translacja inta na ciąg znaków egipskich
        public static String IntToEgyptian(int a)
        {
            // jeżeli poprzez działania wyjdzie część całkowita za duża to jesteśmy w dupie, ale ułamki mają przed tym zabezpieczenie (patrz: funkcja DecomposeFraction w Number, linia 86)
            if (a > 9999999)
            {
                throw new ArgumentException("Egyptian numbers don't go that high :(", nameof(a));
            }
            StringBuilder sb = new StringBuilder();
            // dodajemy znaki milionów (symbol boga)
            while (a > 999999)
            {
                sb.Append("𓁨");
                a -= 1000000;
            }
            // dodajemy znaki setek tysięcy (symbol żaby)
            while (a > 99999)
            {
                sb.Append("𓆐");
                a -= 100000;
            }
            // dodajemy znaki dziesiątek tysięcy (symbol palca)
            while (a > 9999)
            {
                sb.Append("𓂭");
                a -= 10000;
            }
            // dodajemy symbol tysięcy (symbol liny)
            if (a > 999)
            {
                // wykonujemy dzielenie całkowite przez 1000 (dowiadujemy się ile wynosi cyfra tysięcy)
                int idx = a / 1000;
                // odczytujemy odpowiedni z symboli z tablicy symboli liny
                sb.Append(Program.ThousandsCharacters[idx - 1]);
                a -= idx * 1000;
            }
            // dodajemy symbol setek (symbol lilii wodnej)
            if (a > 99)
            {
                // wykonujemy dzielenie całkowite przez 100 (dowiadujemy się ile wynosi cyfra setek)
                int idx = a / 100;
                // odczytujemy symbol z tablicy lilii wodnych
                sb.Append(Program.HundredsCharacters[idx - 1]);
                a -= idx * 100;
            }
            // dodajemy symbol dziesiątek, symbol takiego czegoś do wiązania krów podobno, nie znam się xD
            if (a > 9)
            {
                // wykonujemy dzielenie całkowite przez 10 (dowiadujemy się ile wynosi cyfra dziesiątek)
                int idx = a / 10;
                sb.Append(Program.TensCharacters[idx - 1]);
                a -= idx * 10;
            }
            // dodajemy symbol jedności, kreski
            if (a > 0)
            {
                // wartość 'a' która nam pozostała posłuży nam za indeks do tablicy
                sb.Append(Program.SinglesCharacters[a - 1]);
            }
            return sb.ToString();
        }
    }
}
