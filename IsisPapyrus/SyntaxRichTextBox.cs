using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsirisInterpreter
{
    //Klasa dziedzicząca po RichTextBox z dodatkowymi funkcjami
    public class SyntaxRichTextBox : System.Windows.Forms.RichTextBox
    {
        //Tutaj jest blok kodu z https://stackoverflow.com/questions/192413/how-do-you-prevent-a-richtextbox-from-refreshing-its-display
        //Dodaje metody do zatrzymywania odświeżania textBoxa podczas kolorowania, żeby tekst nie migał
        private const int WM_USER = 0x0400;
        private const int EM_SETEVENTMASK = (WM_USER + 69);
        private const int WM_SETREDRAW = 0x0b;
        private IntPtr OldEventMask;
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public void BeginUpdate()
        {
            SendMessage(this.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
            OldEventMask = (IntPtr)SendMessage(this.Handle, EM_SETEVENTMASK, IntPtr.Zero, IntPtr.Zero);
        }

        public void EndUpdate()
        {
            SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);
            SendMessage(this.Handle, EM_SETEVENTMASK, IntPtr.Zero, OldEventMask);
        }
        // jesli zmienione na 'true' to oznacza, że aktualnie trwa komentarz
        Boolean oneLineComment = false;
        Boolean multiLineComment = false;
        Boolean stringLine = false;

        //Tutaj już jest mój kod,
        //to jest lista słów kluczowych, czerwone
        String[] tokenPatternsToRed =
            {
                "for",
                "if",
                "return",
                "while",
                "do",
                "else",
                "break",
                "continue",
                "printf",
                "scanf",
                "#include"
            };
        //słowa kluczowe, zielone
        String[] tokenPatternsToGreen =
            {
                "int",
                "double",
                "char",
                "float",
                "byte"
            };
        //Tutaj jest lista znaków, które są separatorami (traktowane jak spacje)
        String[] specialChars =
        {
            ";",
            ":",
            "(",
            ")",
            "[",
            "]",
            "{",
            "}"
        };

        //Co się dzieje w Evencie jak ktoś zmieni tekst w okienku, czyli np jak użytkownik coś wpisze
        protected override void OnTextChanged(EventArgs e)
        {
            Highlight();
        }

            public void Highlight()
        {
            //zatrzymujemy odświeżanie
            BeginUpdate();
            //zapisujemy gdzie był kursor przed operacją
            int cursorLoc = SelectionStart;
            //te trzy linie kolorują cały tekst z okienka na czarno
            SelectAll();
            SelectionColor = Color.Black;
            SelectionLength = 0;
            //zmienna która przechowuje w którym aktualnie jesteśmy indeksie przetwarzanego tekstu z okienka
            int currentPos = 0;
            //lista wierszy z okienka
            String[] lines = Lines;
            //pętla leci po wierszach
            for (int lineCounter = 0; lineCounter < lines.Length; lineCounter++)
            {
                String line = lines[lineCounter];
                //z pojedynczego wiersza wyciągamy tokeny, wraz z ich indeksem (gdzie się zaczynają) i kolorem na jaki mają być pokolorowane
                List<(String, int, Color)> lineTokens = extractTokens(line);
                //jeżeli nie ma w wierszu tokenów to idziemy dalej (zmieniając pozycję na początek kolejnego wiersza)
                if (lineTokens.Count == 0)
                {
                    currentPos += line.Length + 1;
                    continue;
                }
                else
                {
                    foreach ((String, int, Color) token in lineTokens)
                    {
                        //zaznaczamy tekst od pozycji (początku wiersza + indeks początku tokenu) o długości jaką ma ten token i ustawiamy kolor
                        Select(currentPos + token.Item2, token.Item1.Length);
                        SelectionColor = token.Item3;
                        SelectionLength = 0;
                    }
                    currentPos += line.Length + 1;
                }

            }
            //przywracamy kursor na miejsce, w którym był i odznaczamy tekst
            Select(cursorLoc, 0);
            //włączamy odświeżanie
            EndUpdate();
        }

        //tokeny zwracamy jako listę potrójnych tupli (token, indeks początku tokenu w wierszu, kolor docelowy)
        public List<(String, int, Color)> extractTokens(String line)
        {
            List<(String, int, Color)> tokens = new List<(String, int, Color)>();
            //przetwarzane słowo
            StringBuilder token = new StringBuilder();
            //index początku aktualnie przetwarzanego słowa
            int startingIndex = 0;
            //iterujemy po znakach w wierszu
            for (int charIndex = 0; charIndex < line.Length; charIndex++)
            {
                //jeżeli nie jest to znak separujący, to dodajemy go do aktualnie przetwarzanego słowa, czyli tokenu
                if (!Char.IsWhiteSpace(line[charIndex]) && !this.specialChars.Contains(line[charIndex].ToString()))
                {
                    token.Append(line[charIndex]);
                    //jeżeli to nie jest ostatni znak, to pomijamy dalszą część i kontynuujemy
                    if (charIndex != line.Length - 1) continue;
                }

                //tutaj docieramy jak spotkamy spację (bądź inny znak separujący) lub dotrzemy do końca linii
                if (token.Length == 0)
                {
                    //jeżeli mamy puste słowo, to szukamy dalej zaczynając od następnego znaku
                    startingIndex = charIndex + 1;
                    continue;
                }
                else
                {
                    // jesli dotychczas zapisane slowo to // lub /* to zaczynamy komentarz
                    if (token.ToString() == "//")
                    {
                        tokens.Add((token.ToString(), startingIndex, Color.Gray));
                        this.oneLineComment = true;
                    }
                    else if (token.ToString() == "/*")
                    {
                        tokens.Add((token.ToString(), startingIndex, Color.Gray));
                        this.multiLineComment = true;
                    }
                    //koniec komentarza 'multi'
                    else if (token.ToString() == "*/")
                    {
                        tokens.Add((token.ToString(), startingIndex, Color.Gray));
                        this.multiLineComment = false;
                    }
                    // jezeli jest komentarz to wszystkie slowa sa
                    // tokenami o szarym kolorze (nwm czy tak moze byc)
                    else if (this.oneLineComment || this.multiLineComment)
                    {
                        tokens.Add((token.ToString(), startingIndex, Color.Gray));
                    }

                    //jeżeli zapisane słowo jest kluczowe(Violet)
                    else if (this.tokenPatternsToRed.Contains(token.ToString()))
                    {
                        tokens.Add((token.ToString(), startingIndex, Color.Red));
                    }
                    //jeżeli zapisane słowo jest kluczowe(Green)
                    else if (this.tokenPatternsToGreen.Contains(token.ToString()))
                    {
                        tokens.Add((token.ToString(), startingIndex, Color.MediumSeaGreen));
                    }
                    //jeżeli jest liczbą, to też dodajemy, z niebieskim kolorem
                    else if (Double.TryParse(token.ToString(), out _))
                    {
                        tokens.Add((token.ToString(), startingIndex, Color.Blue));
                    }
                    else if (token[0].ToString() == "<" && token[token.Length - 1].ToString() == ">")
                    {
                        tokens.Add((token.ToString(), startingIndex, Color.Orange));
                    }
                    
                    //czyścimy przetwarzane słowo
                    token.Clear();
                    //i szukamy dalej zaczynając od następnego znaku
                    startingIndex = charIndex + 1;
                }
            }
            this.oneLineComment = false;
            return tokens;
        }
    }
}
