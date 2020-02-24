using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiColoredModernUI
{
    public static class ThemeColor
    {
        public static Color PrimaryColor { get; set; }

        public static Color SecondaryColor { get; set; }

        public static List<string> ColorList = new List<string>() { "#3F51B5", "#3F51B5", "#009688", "#FF5722", "#607D88", "#FF9800", "#9C2780", "#2196F3", "#EA676C", "#E41A4A", "#597888", "#018790", "#0E3441", "#00BBAD", "#721D47", "#EA4833", "#EF937E", "#F37521", "#A12059", "#126881", "#88C240", "#364D58", "#C7DC58", "#0094BC", "#E41268", "#43B76E", "#78CFE9", "#B71C46" };
    
        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.G;

            // if correction factor is less than 0, darken color.
            if(correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else // if correction factor is greater than zero, lighten color.
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}
