using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuNo
{
    internal class ThemeService
    {
        private const string ThemeKey = "theme_mode";
        public event Action? ThemeChanged; //делегат
        public bool IsDarkMode { get; private set; } = true;
        public ThemeService()
        {
            IsDarkMode =
                Preferences.Default
                    .Get(ThemeKey, true);
        }

        public void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;

            Preferences.Default.Set(
                ThemeKey,
                IsDarkMode);

            ThemeChanged?.Invoke();
        }

        public void SetTheme(bool dark)
        {
            IsDarkMode = dark;

            ThemeChanged?.Invoke();
        }
    }
}
