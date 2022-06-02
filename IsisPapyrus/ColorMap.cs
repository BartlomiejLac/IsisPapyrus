using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsisPapyrus
{
    public class ColorMap
    {
        public static Color getTokenColor(int type)
        {
            if (type == 1) return Color.LightGray;
            if (type <= 3) return Color.Peru;
            if (type <= 5) return Color.MediumSeaGreen;
            if (type == 6) return Color.Black;
            if (type <= 12) return Color.CornflowerBlue;
            if (type <= 20) return Color.MediumVioletRed;
            if (type == 21) return Color.DarkTurquoise;
            if (type == 22) return Color.CornflowerBlue;
            if (type <= 47) return Color.Black;
            if (type <= 50) return Color.CornflowerBlue;
            if (type <= 52) return Color.Black;
            if (type == 53) return Color.LightGreen;
            if (type == 56) return Color.Red;
            return Color.Black;
        }

    }
}
