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
            AdminMenu,
            ManageInventory,
            ProspectorInfo,
            NpcMenu
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
                    { '1', ProspectorAction.ProspectorInfo},
                    //{ '1', ProspectorAction.EditAccount},
                    {'2', ProspectorAction.LookAround},
                    //{'3', ProspectorAction.LookAt},
                    {'3', ProspectorAction.Travel},
                //{'5', ProspectorAction.ProspectorLocationsVisited},
                    {'4', ProspectorAction.PickUpItem},
                    {'5', ProspectorAction.ManageInventory},

                    
                    //{'8', ProspectorAction.PutDownItem},
                    //{'9', ProspectorAction.ProspectorInventory},

                    {'6', ProspectorAction.Shop},
                    {'7', ProspectorAction.AdminMenu},
                    {'8', ProspectorAction.Interact},
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
                    { '3', ProspectorAction.ListNonPlayableCharacters},
                    { '0', ProspectorAction.ReturnToMainMenu }
                }
        };
        public static Menu useItem = new Menu()
        {
            MenuName = "ManageInventory",
            MenuTitle = "Manage Inventory",
            MenuChoices = new Dictionary<char, ProspectorAction>()
                {
                    { '1', ProspectorAction.PutDownItem },
                    { '2', ProspectorAction.ConsumeItem},
                    { '3', ProspectorAction.WieldItem},
                    { '0', ProspectorAction.ReturnToMainMenu }
                }
        };
        public static Menu ProspectorInfo = new Menu()
        {
            MenuName = "ProspectorInfo",
            MenuTitle = "Player Info",
            MenuChoices = new Dictionary<char, ProspectorAction>()
                {
                    { '1', ProspectorAction.ProspectorInfo },
                    { '2', ProspectorAction.EditAccount},
                    { '3', ProspectorAction.ProspectorLocationsVisited},
                    { '0', ProspectorAction.ReturnToMainMenu }
                }
        };
        public static Menu NpcMenu = new Menu()
        {
            MenuName = "NpcMenu",
            MenuTitle = "NPC Menu",
            MenuChoices = new Dictionary<char, ProspectorAction>()
                {
                    { '1', ProspectorAction.TalkTo },
                    { '2', ProspectorAction.SellTo },
                    { '0', ProspectorAction.ReturnToMainMenu }
                }
        };
    }
}
