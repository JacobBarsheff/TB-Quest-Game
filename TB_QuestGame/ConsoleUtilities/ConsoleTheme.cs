using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to manage the console game theme
    /// </summary>
    public static class ConsoleTheme
    {
        //
        // splash screen colors
        //
        public static ConsoleColor SplashScreenBackgroundColor = ConsoleColor.DarkBlue;
        public static ConsoleColor SplashScreenForegroundColor = ConsoleColor.Yellow;

        //
        // main console window colors
        //
        public static ConsoleColor WindowBackgroundColor = ConsoleColor.DarkBlue;
        public static ConsoleColor WindowForegroundColor = ConsoleColor.Yellow;

        //
        // console window header colors
        //
        public static ConsoleColor HeaderBackgroundColor = ConsoleColor.DarkGray;
        public static ConsoleColor HeaderForegroundColor = ConsoleColor.Yellow;

        //
        // console window footer colors
        //
        public static ConsoleColor FooterBackgroundColor = ConsoleColor.DarkGray;
        public static ConsoleColor FooterForegroundColor = ConsoleColor.Yellow;

        //
        // menu box colors
        //
        public static ConsoleColor MenuBackgroundColor = ConsoleColor.DarkBlue;
        public static ConsoleColor MenuForegroundColor = ConsoleColor.White;
        public static ConsoleColor MenuBorderColor = ConsoleColor.DarkYellow;

        //
        // message box colors
        //
        public static ConsoleColor MessageBoxBackgroundColor = ConsoleColor.DarkBlue;
        public static ConsoleColor MessageBoxForegroundColor = ConsoleColor.White;
        public static ConsoleColor MessageBoxBorderColor = ConsoleColor.DarkYellow;
        public static ConsoleColor MessageBoxHeaderBackgroundColor = ConsoleColor.DarkBlue;
        public static ConsoleColor MessageBoxHeaderForegroundColor = ConsoleColor.DarkYellow;
        
        //
        // input box colors
        //
        public static ConsoleColor InputBoxBackgroundColor = ConsoleColor.DarkBlue;
        public static ConsoleColor InputBoxForegroundColor = ConsoleColor.Gray;
        public static ConsoleColor InputBoxErrorMessageForegroundColor = ConsoleColor.Red;
        public static ConsoleColor InputBoxBorderColor = ConsoleColor.DarkYellow;
        public static ConsoleColor InputBoxHeaderBackgroundColor = ConsoleColor.DarkBlue;
        public static ConsoleColor InputBoxHeaderForegroundColor = ConsoleColor.White;

        //
        // health box colors
        //
        public static ConsoleColor HealthBackgroundColor = ConsoleColor.Green;
        public static ConsoleColor HealthBoxForegroundColor = ConsoleColor.Red;
        public static ConsoleColor HealthBoxBorderColor = ConsoleColor.DarkYellow;
        public static ConsoleColor HealthBoxHeaderBackgroundColor = ConsoleColor.DarkBlue;
        public static ConsoleColor HealthBoxHeaderForegroundColor = ConsoleColor.DarkYellow;
    }
}
