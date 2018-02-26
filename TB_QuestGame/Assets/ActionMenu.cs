using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActionMenu
    {
        public static Menu GameIntro = new Menu()
        {
            MenuName = "GameIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, ProspectorAction>()
                    {
                        { ' ', ProspectorAction.None }
                    }
        };

        public static Menu InitializeMission = new Menu()
        {
            MenuName = "InitializeAdventure",
            MenuTitle = "Initialize Mission",
            MenuChoices = new Dictionary<char, ProspectorAction>()
                {
                    { '1', ProspectorAction.Exit }
                }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, ProspectorAction>()
                {
                    { '1', ProspectorAction.ProspectorInfo },
                    { '2', ProspectorAction.EditAccount},
                    { '3', ProspectorAction.Exit }
                }
        };

        //public static Menu ManageTraveler = new Menu()
        //{
        //    MenuName = "ManageTraveler",
        //    MenuTitle = "Manage Prospector",
        //    MenuChoices = new Dictionary<char, ProspectorAction>()
        //            {
        //                ProspectorAction.MissionSetup,
        //                ProspectorAction.TravelerInfo,
        //                ProspectorAction.Exit
        //            }
        //};
    }
}
