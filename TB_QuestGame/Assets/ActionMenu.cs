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
        public enum CurrentMenu
        {
            MissionIntro,
            InitializeMission,
            MainMenu,
            AdminMenu
        }

        public static CurrentMenu currentMenu = CurrentMenu.MainMenu;
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
                    { 'A', ProspectorAction.ProspectorInfo},
                    { '1', ProspectorAction.EditAccount},
                    {'2', ProspectorAction.LookAround},
                    {'3', ProspectorAction.LookAt},
                    {'4', ProspectorAction.Travel},
                    {'5', ProspectorAction.ProspectorLocationsVisited},
                    {'6', ProspectorAction.AdminMenu},
                    {'7', ProspectorAction.PickUpItem},
                    {'8', ProspectorAction.PutDownItem},
                    {'9', ProspectorAction.ProspectorInventory},
                    {'S', ProspectorAction.Shop},
                    {'0', ProspectorAction.Exit}
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
        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, ProspectorAction>()
                {
                    { '1', ProspectorAction.ListDestinations },
                    { '2', ProspectorAction.ListItems},
                    { '0', ProspectorAction.ReturnToMainMenu }
                }
        };
    }
}
