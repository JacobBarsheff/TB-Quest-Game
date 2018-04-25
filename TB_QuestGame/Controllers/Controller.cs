using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Prospector _gamePlayer;
        private Universe _gameUniverse;
        private bool _playingGame;
        public RegionLocation _currentLocation;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gamePlayer = new Prospector();
            _gameUniverse = new Universe();
            _gameConsoleView = new ConsoleView(_gamePlayer, _gameUniverse);
            _playingGame = true;
            ProspectorObject prospectorObject;

            foreach (GameObject gameObject in _gameUniverse.GameObjects)
            {
                if (gameObject is ProspectorObject)
                {
                    prospectorObject = gameObject as ProspectorObject;
                    prospectorObject.objectAddedToInventory += HandleObjectAddedToInventory;
                }
            }

            //
            //add initial items to the travelers inventory
            //
            _gamePlayer.Inventory.Add(_gameUniverse.GetGameObjectById(1) as ProspectorObject);

            Console.CursorVisible = false;

        }
        private void HandleObjectAddedToInventory(object gameObject, EventArgs e)
        {
            if (gameObject.GetType() == typeof(ProspectorObject))
            {
                ProspectorObject travelerObject = gameObject as ProspectorObject;
                _gamePlayer.Inventory.Add(travelerObject);
                switch (travelerObject.Type)
                {
                    case ProspectorObjectType.Food:
                        _gameConsoleView.DisplayGamePlayScreen("Item Added", $"You have added {travelerObject.Name} to your inventory!", ActionMenu.MainMenu, "");
                        break;
                    case ProspectorObjectType.Medicine:
                        _gameConsoleView.DisplayGamePlayScreen("Item Added", $"You have added {travelerObject.Name} to your inventory!", ActionMenu.MainMenu, "");
                        break;
                    case ProspectorObjectType.Weapon:
                        _gameConsoleView.DisplayGamePlayScreen("Item Added", $"You have added {travelerObject.Name} to your inventory!", ActionMenu.MainMenu, "");
                        break;
                    case ProspectorObjectType.Treasure:
                        _gamePlayer.Money += travelerObject.Value;
                        _gameConsoleView.DisplayConfirmTravelerObjectAddedToMoney(travelerObject);
                        Random rnd = new Random();
                        travelerObject.RegionLocationId = rnd.Next(1, _gameUniverse.RegionLocations.Count);
                        break;
                    case ProspectorObjectType.Information:
                        _gameConsoleView.DisplayGamePlayScreen("An Important Message", travelerObject.PickUpMessage, ActionMenu.MainMenu, "");
                        break;
                    case ProspectorObjectType.Resource:
                        _gameConsoleView.DisplayGamePlayScreen("Item Added", $"You have added {travelerObject.Name} to your inventory!", ActionMenu.MainMenu, "");
                        break;
                    case ProspectorObjectType.Tool:
                        _gameConsoleView.DisplayGamePlayScreen("Item Added", $"You have added {travelerObject.Name} to your inventory!", ActionMenu.MainMenu, "");
                        break;
                    default:
                        break;
                       
                }
                
            }
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            ProspectorAction travelerActionChoice = ProspectorAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Game Intro", Text.GameIntro(), ActionMenu.GameIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission prospector
            // 
            InitializeAdventure();

            //
            // prepare game play screen
            //

            _currentLocation = _gameUniverse.GetRegionLocationById(_gamePlayer.CurrentRegionLocationID);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(), ActionMenu.MainMenu, "");

            //
            // game loop
            //
            while (_playingGame)
            {

                //
                // process all flags, events, and stats
                //

                UpdateGameStatus();
                //
                // get next game action from player
                //

                //
                // get next game action from player
                //
                travelerActionChoice = GetNextProspectorAction();
                //if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.MainMenu)
                //{
                //    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                //}
                //else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.AdminMenu)
                //{
                //    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                //}
                //else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.ManageInventory)
                //{
                //    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.useItem);
                //}
                //else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.ProspectorInfo)
                //{
                //    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ProspectorInfo);
                //}

                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case ProspectorAction.None:
                        break;

                    case ProspectorAction.ProspectorInfo:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ProspectorInfo;
                        _gameConsoleView.DisplayTravelerInfo();
                        //_gameConsoleView.DisplayTravelerInfo();
                        break;
                    case ProspectorAction.EditAccount:
                        editAccount();
                        break;
                    case ProspectorAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;
                    case ProspectorAction.Travel:
                        //
                        // get new location choice and update the current location property
                        //
                        _gamePlayer.CurrentRegionLocationID = _gameConsoleView.DisplayGetNextRegionLocation();
                        _currentLocation = _gameUniverse.GetRegionLocationById((_gamePlayer).CurrentRegionLocationID);

                        //
                        // set the game play screen to the current location info format
                        //
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;
                    case ProspectorAction.ProspectorInventory:
                        _gameConsoleView.DisplayInventory();
                        break;
                    case ProspectorAction.ProspectorLocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;
                    case ProspectorAction.ListDestinations:
                        _gameConsoleView.DisplayListOfRegionLocations();
                        break;
                    case ProspectorAction.ListItems:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        break;

                    case ProspectorAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        break;

                    case ProspectorAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;
                    case ProspectorAction.Exit:
                        _playingGame = false;
                        break;
                    case ProspectorAction.LookAt:
                        LookAtAction();
                        break;
                    case ProspectorAction.PickUpItem:
                        PickUpAction();
                        break;

                    case ProspectorAction.PutDownItem:
                        PutDownAction();
                        break;
                    case ProspectorAction.Shop:
                        if (_gameUniverse.GetRegionLocationById(_gamePlayer.CurrentRegionLocationID).CommonName == "Wilderness")
                        {
                            _gameConsoleView.DisplayCanNotVisitShop();
                        }
                        else
                        {
                        Shop();
                        } 
                        
                        break;
                    case ProspectorAction.ManageInventory:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ManageInventory;
                        _gameConsoleView.DisplayGamePlayScreen("Manage Inventory", $"Please select an menu action you would like to do with the below items: \n{Text.CurrentInventory(_gamePlayer.Inventory)}", ActionMenu.useItem, "");
                        break;
                    case ProspectorAction.ListNonPlayableCharacters:
                        _gameConsoleView.DisplayListOfAllNpcObjects();
                        break;
                    case ProspectorAction.TalkTo:
                        TalkToAction();
                        break;
                    case ProspectorAction.SellTo:
                        SellItem();
                        break;
                    case ProspectorAction.Interact:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Interact With NPC", "Please select an action!", ActionMenu.NpcMenu, "");
                        break;
                    case ProspectorAction.ConsumeItem:
                        ConsumeItem();
                        break;

                    case ProspectorAction.WieldItem:
                        WieldItem();
                        break;
                    case ProspectorAction.PlayerInfoMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ProspectorInfo;
                        _gameConsoleView.DisplayGamePlayScreen("Player Information", "Please select a menu option to your left to view Player Information", ActionMenu.ProspectorInfo, "");
                        break;
                    default:
                        break;

                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        /// 
        private void WieldItem()
        {
            int playerChoice;
            //show items

            playerChoice = _gameConsoleView.DisplayItemStats("wield");
            if (playerChoice == 0)
            {
                _gameConsoleView.DisplayGamePlayScreen("Cancelled", "You exited the inventory", ActionMenu.useItem, "Please Enter The Item Id: ");
            }
            else
            {
                if (_gamePlayer.Inventory[playerChoice - 3].Type == ProspectorObjectType.Weapon || _gamePlayer.Inventory[playerChoice - 3].Type == ProspectorObjectType.Tool)
                {
                    _gamePlayer.CurrentWieldedWeapon = _gamePlayer.Inventory[playerChoice - 3];
                    _gameConsoleView.DisplayGamePlayScreen("Item Equipped!", $"{_gamePlayer.Inventory[playerChoice - 3].Name} was equipped!", ActionMenu.useItem, "");

                }
                else
                {
                    _gameConsoleView.DisplayGamePlayScreen("Item Not Equipped!", $"{_gamePlayer.Inventory[playerChoice - 3].Name} is a {_gamePlayer.Inventory[playerChoice - 3].Type} and can not be equipped!", ActionMenu.useItem, "");
                }
            }
        }
        private void ConsumeItem()
        {
            int playerChoice;
            //show items
            playerChoice = _gameConsoleView.DisplayItemStats("consume");
            if (playerChoice == 0)
            {
                _gameConsoleView.DisplayGamePlayScreen("Cancelled", "You exited the inventory", ActionMenu.useItem, "Please Enter The Item Id: ");
            }
            else
            {


            //_gameConsoleView.DisplayGamePlayScreen("Consume Item", Text.CurrentInventoryNumbered(_gamePlayer.Inventory), ActionMenu.useItem, "Please Enter The Item Id: ");
            //_gameConsoleView.GetInteger("Please enter the Item #: ", 1, _gamePlayer.Inventory.Count(), out playerChoice);
            switch (_gamePlayer.Inventory[playerChoice - 3].Type)
            {
                case ProspectorObjectType.Food:
                    _gameConsoleView.DisplayGamePlayScreen("Item Consumed", $"You consumed {_gamePlayer.Inventory[playerChoice - 3].Name} for {_gamePlayer.Inventory[playerChoice - 3].Value} health points!" , ActionMenu.useItem, "Please Enter The Item Id: ");
                    _gamePlayer.ProspectorHealth += _gamePlayer.Inventory[playerChoice - 3].Value;
                    _gamePlayer.Inventory.Remove(_gamePlayer.Inventory[playerChoice - 3]);
                    
                    break;
                case ProspectorObjectType.Medicine:                    
                    
                    _gamePlayer.ProspectorHealth += _gamePlayer.Inventory[playerChoice - 3].Value;
                    _gameConsoleView.DisplayGamePlayScreen("Item Consumed", $"You consumed {_gamePlayer.Inventory[playerChoice - 3].Name} for {_gamePlayer.Inventory[playerChoice - 3].Value} health points!", ActionMenu.useItem, "Please Enter The Item Id: ");
                    _gamePlayer.Inventory.Remove(_gamePlayer.Inventory[playerChoice - 3]);
                    break;
                case ProspectorObjectType.Weapon:
                    _gameConsoleView.DisplayGamePlayScreen("Invalid Item", $"You can't consume a {_gamePlayer.Inventory[playerChoice - 3].Name} because it is a {_gamePlayer.Inventory[playerChoice - 3].Type}!", ActionMenu.useItem, "Please Enter The Item Id: ");
                    break;
                case ProspectorObjectType.Treasure:
                    _gameConsoleView.DisplayGamePlayScreen("Invalid Item", $"You can't consume a {_gamePlayer.Inventory[playerChoice - 3].Name} because it is a {_gamePlayer.Inventory[playerChoice - 3].Type}!", ActionMenu.useItem, "Please Enter The Item Id: ");
                    break;
                case ProspectorObjectType.Information:
                    _gameConsoleView.DisplayGamePlayScreen("Invalid Item", $"You can't consume a {_gamePlayer.Inventory[playerChoice - 3].Name} because it is a {_gamePlayer.Inventory[playerChoice - 3].Type}!", ActionMenu.useItem, "Please Enter The Item Id: ");
                    break;
                case ProspectorObjectType.Resource:
                    _gameConsoleView.DisplayGamePlayScreen("Invalid Item", $"You can't consume a {_gamePlayer.Inventory[playerChoice - 3].Name} because it is a {_gamePlayer.Inventory[playerChoice - 3].Type}!", ActionMenu.useItem, "Please Enter The Item Id: ");
                    break;
                case ProspectorObjectType.Tool:
                    _gameConsoleView.DisplayGamePlayScreen("Invalid Item", $"You can't consume a {_gamePlayer.Inventory[playerChoice - 3].Name} because it is a {_gamePlayer.Inventory[playerChoice - 3].Type}!", ActionMenu.useItem, "Please Enter The Item Id: ");
                    break;
                default:
                    break;
            }
            }
        }
        private void InitializeAdventure()
        {
            Prospector prospector = _gameConsoleView.GetInitialTravelerInfo();

            _gamePlayer.Name = prospector.Name;
            _gamePlayer.Age = prospector.Age;
            _gamePlayer.ProspectorAddress = prospector.ProspectorAddress;
            _gamePlayer.title = prospector.title;
            _gamePlayer.PlayerHealthStatus = prospector.PlayerHealthStatus;
            _gamePlayer.HasFishedHunted = prospector.HasFishedHunted;
            _gamePlayer.PriorKnowledge = prospector.PriorKnowledge;

            _gamePlayer.CurrentRegionLocationID = 1;
        }

        private void editAccount()
        {
            int playerChoice =_gameConsoleView.DisplayPlayerEdit(_gamePlayer);
            Prospector prospector = _gameConsoleView.DisplayPlayerEditPrompt(playerChoice);
            switch (playerChoice)
            {
                case 0:break;
                case 1:
                    _gamePlayer.Name = prospector.Name;
                    break;
                case 2:
                    _gamePlayer.title = prospector.title;
                    break;
                case 3:
                    _gamePlayer.Age = prospector.Age;
                    break;
                case 4:
                    _gamePlayer.ProspectorAddress = prospector.ProspectorAddress;
                    break;
                case 5:
                    _gamePlayer.PlayerHealthStatus = prospector.PlayerHealthStatus;
                    break;
                case 6:
                    _gamePlayer.HasFishedHunted = prospector.HasFishedHunted;
                    break;
                case 7:
                    _gamePlayer.PriorKnowledge = prospector.PriorKnowledge;
                    break;
                default:
                    break;
            }
            _gameConsoleView.DisplayUpdatedTravelerInfo(_gamePlayer);
        }
        private void UpdateGameStatus()
        {
            if (!_gamePlayer.hasVisited(_currentLocation.RegionLocationID))
            {
                //add locations
                _gamePlayer.RegionLocationsVisited.Add(_currentLocation.RegionLocationID);
            }
            _gamePlayer.ExpPoints += _currentLocation.ExperiencePoints;

          

        }
        private void LookAtAction()
        {
            //
            // display a list of game objects in space-time location and get a player choice
            //
            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectToLookAt();

            //
            // display game object info
            //
            if (gameObjectToLookAtId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(gameObjectToLookAtId);

                //
                // display information for the object chosen
                //
                _gameConsoleView.DisplayGameObjectInfo(gameObject);
            }
        }
        /// <summary>
        /// process the Pick Up action
        /// </summary>
        private void PickUpAction()
        {
            //
            // display a list of traveler objects in space-time location and get a player choice
            //
            int travelerObjectToPickUpId = _gameConsoleView.DisplayGetTravelerObjectToPickUp();

            //
            // add the traveler object to traveler's inventory
            //
            if (travelerObjectToPickUpId != 0)
            {
                //
                // get the game object from the universe
                //
                ProspectorObject travelerObject = _gameUniverse.GetGameObjectById(travelerObjectToPickUpId) as ProspectorObject;
                _gamePlayer.ExpPoints += travelerObject.ExperiencePoints;
                //
                // note: traveler object is added to list and the space-time location is set to 0
                //
                //if (travelerObject.Type == ProspectorObjectType.Treasure)
                //{
                //_gamePlayer.Money += travelerObject.Value;
                //_gameConsoleView.DisplayConfirmTravelerObjectAddedToMoney(travelerObject);
                //Random rnd = new Random();
                //  travelerObject.RegionLocationId = rnd.Next(1, _gameUniverse.RegionLocations.Count);
                //}
                //else if(travelerObject.Type == ProspectorObjectType.Medicine){
                //    _gamePlayer.PlayerHealthStatus += 10;
                //}
                //else
                //{
                //_gamePlayer.Inventory.Add(travelerObject);
                travelerObject.RegionLocationId = 0;
                //_gameConsoleView.DisplayConfirmTravelerObjectAddedToInventory(travelerObject);
                // }


                //
                // display confirmation message
                //
                //_gamePlayer.Inventory.Add(travelerObject);
            }
        }

        private void PutDownAction()
        {
            //
            // display a list of traveler objects in inventory and get a player choice
            //
            int inventoryObjectToPutDownId = _gameConsoleView.DisplayGetInventoryObjectToPutDown();

            //
            // get the game object from the universe
            //
            ProspectorObject travelerObject = _gameUniverse.GetGameObjectById(inventoryObjectToPutDownId) as ProspectorObject;

            //
            // remove the object from inventory and set the space-time location to the current value
            //
            _gamePlayer.Inventory.Remove(travelerObject);
            travelerObject.RegionLocationId = _gamePlayer.CurrentRegionLocationID;

            //
            // display confirmation message
            //
            _gameConsoleView.DisplayConfirmTravelerObjectRemovedFromInventory(travelerObject);

        }
        private void Shop()
        {
            int userChoice = _gameConsoleView.DisplayShopOptions();
            switch (userChoice)
            {
                case 1:
                    buyItem();
                    break;
                case 2:
                    GameObject item = _gameConsoleView.DisplaySell();
                    ProspectorObject itemtoSell = item as ProspectorObject;
                    _gamePlayer.Inventory.Remove(itemtoSell);
                    _gamePlayer.Money += (int)(itemtoSell.Value*(.5));
                    _gameConsoleView.DisplayConfirmationSell(itemtoSell);
                    break;
                case 3:
                    _gameConsoleView.DisplayNoShop();
                    break;
                default:
                    _gameConsoleView.DisplayNoShop();
                    break;
            }

        }
        private void buyItem()
        {
            Random R = new Random();
            
            double currentPricePercent = R.Next(1, 50);
            GameObject itemToBuy = _gameConsoleView.DisplayBuy(currentPricePercent);
            ProspectorObject travelerObject = itemToBuy as ProspectorObject;

            if (_gamePlayer.Money - travelerObject.Value > 0)
            {
                //_gamePlayer.Inventory.Add(travelerObject);
                travelerObject.RegionLocationId = 0;
                _gamePlayer.Money -= travelerObject.Value;
                _gameConsoleView.DisplayConfirmationPurchase(travelerObject);
            }
            else
            {
                _gameConsoleView.DisplayCanNotBuy();
            }
        }

        private ProspectorAction GetNextProspectorAction()
        {
            ProspectorAction prospectorAction = ProspectorAction.None;

            switch (ActionMenu.currentMenu)
            {
                case ActionMenu.CurrentMenu.MissionIntro:
                    prospectorAction = _gameConsoleView.GetActionMenuChoice(ActionMenu.GameIntro);
                    break;
                case ActionMenu.CurrentMenu.InitializeMission:
                    prospectorAction = _gameConsoleView.GetActionMenuChoice(ActionMenu.InitializeMission);
                    break;
                case ActionMenu.CurrentMenu.MainMenu:
                    prospectorAction = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                    break;
                case ActionMenu.CurrentMenu.AdminMenu:
                    prospectorAction = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                    break;
                case ActionMenu.CurrentMenu.ManageInventory:
                    prospectorAction = _gameConsoleView.GetActionMenuChoice(ActionMenu.useItem);
                    break;
                case ActionMenu.CurrentMenu.ProspectorInfo:
                    prospectorAction = _gameConsoleView.GetActionMenuChoice(ActionMenu.ProspectorInfo);
                    break;
                case ActionMenu.CurrentMenu.NpcMenu:
                    prospectorAction = _gameConsoleView.GetActionMenuChoice(ActionMenu.NpcMenu);
                    break;
                default:
                    break;
            }

            return prospectorAction;

        }
       private void TalkToAction()
        {
            int npcToTalkToId = _gameConsoleView.DisplayGetNpcToTalkTo();

            if (npcToTalkToId != 0)
            {
                Npc npc = _gameUniverse.GetNpcById(npcToTalkToId);



                _gameConsoleView.DisplayTalkTo(npc);
            }


        }
        private void SellItem()
        {

            

            int npcToSellToId = _gameConsoleView.DisplayGetNpcToSellTo();
            GameObject itemToSell = _gameConsoleView.DisplaySellToNPC();
            ProspectorObject objecttosell = itemToSell as ProspectorObject;

            _gameConsoleView.DisplayGamePlayScreen("The offer", $"{_gameUniverse.GetNpcById(npcToSellToId).Name} would like to offer you {objecttosell.Value}", ActionMenu.NpcMenu, "");
            int userResponse;
            _gameConsoleView.GetInteger("Enter 1 for YES and 2 for No", 1, 2, out userResponse);
            if (userResponse == 1)
            {
                _gamePlayer.Money += objecttosell.Value;
                _gamePlayer.Inventory.Remove(objecttosell);

                _gameConsoleView.DisplayGamePlayScreen("Deal Processed!", $"{_gameUniverse.GetNpcById(npcToSellToId).Name} bought {objecttosell.Name} for {objecttosell.Value}", ActionMenu.NpcMenu, "");
            }
            else
            {
                _gameConsoleView.DisplayGamePlayScreen("Deal Cancelled!", $"The deal was cancelled", ActionMenu.NpcMenu, "");
            }
        }

        
    }
    


#endregion
}
