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
            if (type == 2) return Color.Peru;
            if (type <= 4) return Color.MediumSeaGreen;
            if (type == 5) return Color.Black;
            if (type <= 8) return Color.CornflowerBlue;
            if (type <= 17) return Color.MediumVioletRed;
            if (type == 18) return Color.DarkTurquoise;
            if (type == 19) return Color.CornflowerBlue;
            if (type <= 41) return Color.Black;
            if (type <= 44) return Color.CornflowerBlue;
            if (type <= 46) return Color.Black;
            if (type == 47) return Color.LightGreen;
            if (type == 50) return Color.Red;
            return Color.Black;
        }

    }
}
