using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuNo
{
    internal class AppTheme
    {
        public static MudTheme DarkTheme =>
       new()
       {
           PaletteDark = new PaletteDark
           {
               Background = "#0F1115",
               Surface = "#171A21",
               AppbarBackground = "#171A21",

               Primary = "#7C5CFF",
               Secondary = "#44D19E",

               TextPrimary = "#F5F7FA",
               TextSecondary = "#9AA3B2"
           }
       };

        public static MudTheme LightTheme =>
            new()
            {
                PaletteLight = new PaletteLight
                {
                    Background = "#F7F8FC",
                    Surface = "#FFFFFF",
                    AppbarBackground = "#FFFFFF",

                    Primary = "#7C5CFF",
                    Secondary = "#44D19E",

                    TextPrimary = "#171A21",
                    TextSecondary = "#667085"
                }
            };
    }
}
