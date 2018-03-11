using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class sets the layout of the game screen
    /// </summary>
    public static class ConsoleLayout
    {
        //
        // console window configuration
        //
        public static int WindowWidth = 160;
        public static int WindowHeight = 39;
        public static int WindowPositionLeft = 0;
        public static int WindowPositionTop = 0;

        //
        // header configuration
        //
        // Note: The header height is the sum of lines of text and 2 blank lines.
        //       The top positions of other elements should be adjusted accordingly and
        //       the number of lines of text displayed by the header should not change.
        public static int HeaderWidth = 160;
        public static int HeaderPositionLeft = 0;
        public static int HeaderPositionTop = 0;

        //
        // footer configuration
        //
        // Note: The footer height is the sum of lines of text and 2 blank lines.
        //       The heights of other elements should be adjusted accordingly and
        //       the number of lines of text displayed by the footer should not change.
        public static int FooterWidth = 160;
        public static int FooterPositionLeft = 0;
        public static int FooterPositionTop = 36;

        //
        // menu box configuration
        //
        public static int MenuBoxWidth = 37;
        public static int MenuBoxHeight = 21;
        public static int MenuBoxPositionLeft = 1;
        public static int MenuBoxPositionTop = 11;

        //
        // message box configuration
        //
        public static int MessageBoxWidth = 79;
        public static int MessageBoxHeight = 29;
        public static int MessageBoxPositionLeft = 40;
        public static int MessageBoxPositionTop = 3;

        //
        // input box configuration
        //
        public static int InputBoxWidth = 118;
        public static int InputBoxHeight = 4;
        public static int InputBoxPositionLeft = 1;
        public static int InputBoxPositionTop = 32;

        //
        // health and status box configuration
        //
        public static int HealthBoxWidth = 37;
        public static int HealthBoxHeight = 8;
        public static int HealthBoxPositionLeft = 1;
        public static int HealthBoxPositionTop = 3;

        //
        // map box configuration
        //
        public static int MapBoxWidth = 37;
        public static int MapBoxHeight = 15;
        public static int MapBoxPositionLeft = 121;
        public static int MapBoxPositionTop = 3;

        //
        // inventory box configuration
        //
        public static int InventoryBoxWidth = 37;
        public static int InventoryBoxHeight = 18;
        public static int InventoryBoxPositionLeft = 121;
        public static int InventoryBoxPositionTop = 18;
    }
}
