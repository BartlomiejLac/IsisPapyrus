using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsisPapyrus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentUICulture;

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            System.Threading.Thread.CurrentThread.CurrentUICulture = CurrentUICulture;
        }

        static void Test()
        {
            string n1 = "𓎈";
            string n2 = "𓍢𓎍𓐀";
            string n3 = "𓏼 𓂋𓏻 𓂋𓎆";

            MessageBox.Show(EgyptianNumberParser.fromEgyptian(n1).ToString());
            MessageBox.Show(EgyptianNumberParser.fromEgyptian(n2).ToString());
            MessageBox.Show(EgyptianNumberParser.fromEgyptian(n3).ToString());
        }

    }
}