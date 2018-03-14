using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {
        #region ENUMS

        private enum ViewStatus
        {
            TravelerInitialization,
            PlayingGame
        }

        #endregion

        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Prospector _gameTraveler;
        Universe _gameUniverse;

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Prospector gameTraveler, Universe gameUniverse)
        {
            _gameTraveler = gameTraveler;
            _gameUniverse = gameUniverse;

            _viewStatus = ViewStatus.TravelerInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS
        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
            string playerHealth = " ";
            DisplayHealthBox($"Player Status", playerHealth);
            DisplayMapBox();
            DisplayInventoryBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public ProspectorAction GetActionMenuChoice(Menu menu)
        {
            ProspectorAction choosenAction = ProspectorAction.None;
            Console.CursorVisible = false;

            //
            // create an array of valid keys from menu dictionary
            //
            char[] validKeys = menu.MenuChoices.Keys.ToArray();

            //
            // validate key pressed as in MenuChoices dictionary
            //
            char keyPressed;
            do
            {
                ConsoleKeyInfo keyPressedInfo = Console.ReadKey();
                keyPressed = keyPressedInfo.KeyChar;

            } while (!validKeys.Contains(keyPressed));

            choosenAction = menu.MenuChoices[keyPressed];
            Console.CursorVisible = true;

            return choosenAction;
        }
        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get a bool value from the user
        /// </summary>
        /// <returns>string value</returns>
        public bool GetBool()
        {
            bool userResponse;
            bool.TryParse(Console.ReadLine(), out userResponse);



            return userResponse;
        }
        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {

                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Character.Title GetTitle()
        {
            Character.Title titleType;
            Enum.TryParse<Character.Title>(Console.ReadLine(), out titleType);

            return titleType;
        }
        public Prospector.overallHealth GetHealthStatus()
        {
            Prospector.overallHealth health;
            Enum.TryParse<Prospector.overallHealth>(Console.ReadLine(), out health);

            return health;
        }
        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);
            Console.WriteLine(tabSpace + @" _   ___                  _ _ _          _____       _      _  ");
            Console.WriteLine(tabSpace + @"| | / / |                | (_) |        | __  \     | |    | | ");
            Console.WriteLine(tabSpace + @"| |/ /| | ___  _ __   __ | |_| | _____  | | \ / ___ | | __ | | ");
            Console.WriteLine(tabSpace + @"|    \| |/ _ \| '_ \ / _`| | | |/ / _ \ | | __ / _ \| |/  _` | ");
            Console.WriteLine(tabSpace + @"| |\  \ | (_) | | | | (_ | | |   < ___/ | |_\ \ (_) | | (_ | | ");
            Console.WriteLine(tabSpace + @"\_| \_/_|\___/|_| |_|\__,_ |_|_|\_\___| \____ /\___/|_|\__,_ | ");


            Console.WriteLine(tabSpace + @" ______           _      ");
            Console.WriteLine(tabSpace + @"| ___  \         | |     ");
            Console.WriteLine(tabSpace + @"| |_/  /   _ ___ | |__   ");
            Console.WriteLine(tabSpace + @"|     / | | / __|| '_ \  ");
            Console.WriteLine(tabSpace + @"| | \ \ |_| \__ \| | | | ");
            Console.WriteLine(tabSpace + @"\_|  \_\__,_|___/|_| |_| ");

            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "The Aion Project";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, ProspectorAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != ProspectorAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        public void DisplayHealthBox(string headerText, string healthBar)
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.HealthBoxPositionTop,
                ConsoleLayout.HealthBoxPositionLeft,
                ConsoleLayout.HealthBoxWidth,
                ConsoleLayout.HealthBoxHeight);


            //
            // display health box header
            //
            Console.BackgroundColor = ConsoleTheme.HealthBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.HealthBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.HealthBoxPositionLeft + 2, ConsoleLayout.HealthBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.HealthBoxWidth - 4));

            //
            // display the text for the health box
            //
            Console.BackgroundColor = ConsoleTheme.HealthBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.HealthBoxForegroundColor;
            int startingRow = ConsoleLayout.HealthBoxPositionTop + 3;
            int row = startingRow;
            Console.SetCursorPosition(ConsoleLayout.HealthBoxPositionLeft + 2, row);
            Console.Write(ConsoleWindowHelper.Center(healthBar, ConsoleLayout.HealthBoxWidth - 4 - (Math.Abs(_gameTraveler.ProspectorHealth - 35))));
            if (_gameTraveler.ProspectorHealth == 35)
            {
 
            }
            else
            {

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(ConsoleWindowHelper.Center(healthBar, ConsoleLayout.HealthBoxWidth - 4 - (_gameTraveler.ProspectorHealth - 2)));
            }

            //display exp
            Console.BackgroundColor = ConsoleTheme.EXPBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.EXPBoxForegroundColor;

            int startingRowExp = ConsoleLayout.HealthBoxPositionTop + 10;
            int rowExp = startingRow;
            Console.SetCursorPosition(ConsoleLayout.HealthBoxPositionLeft + 2, 8);
            Console.Write($"Current XP: {_gameTraveler.ExpPoints} ");




            //List<string> messageTextLines = new List<string>();
            //messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            //int startingRow = ConsoleLayout.HealthBoxPositionTop + 3;
            //int endingRow = startingRow + messageTextLines.Count();
            //int row = startingRow;
            //foreach (string messageTextLine in messageTextLines)
            //{
            //    Console.SetCursorPosition(ConsoleLayout.HealthBoxPositionLeft + 2, row);
            //    Console.Write(messageTextLine);
            //    row++;
            //}
        }

        public void DisplayMapBox()
        {
            Console.BackgroundColor = ConsoleTheme.MapBoxBorderBackColor;
            Console.ForegroundColor = ConsoleTheme.MapBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MapBoxPositionTop,
                ConsoleLayout.MapBoxPositionLeft,
                ConsoleLayout.MapBoxWidth,
                ConsoleLayout.MapBoxHeight);
            for (int height = 1; height < ConsoleLayout.MapBoxHeight - 1; height++)
            {
            Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft+1, ConsoleLayout.MapBoxPositionTop+height);
            for (int i = 0; i < ConsoleLayout.InventoryBoxWidth-2; i++)
            {               
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write(" ");
                
            }
            
            }

            //Console.BackgroundColor = ConsoleTheme.MapBoxHeaderBackgroundColor;
            //Console.ForegroundColor = ConsoleTheme.MapBoxHeaderForegroundColor;
            //Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 15, ConsoleLayout.MapBoxPositionTop + 1);
            //Console.Write(ConsoleWindowHelper.Center("Map", ConsoleLayout.MapBoxWidth - 30));
            //int startingRow = ConsoleLayout.MapBoxPositionTop + 1;
            //int row = startingRow;
            //Console.BackgroundColor = ConsoleTheme.MapBoxBackgroundColor;
            //Console.ForegroundColor = ConsoleTheme.MapBoxForegroundColor;
            //Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 2, row);
            //Console.WriteLine(_gameUniverse.RegionLocations[6].CommonName);
            //Console.WriteLine("Dawson");
            //Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 3, row + 2);
            //Console.WriteLine("Wilderness");
            //Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 24, row +2);
            //Console.WriteLine("Edmonton");
            //Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 3, row + 4);
            //Console.WriteLine("Skagway");
            //Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 13, row + 4);
            //Console.WriteLine("Wilderness");
            //Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 3, row + 6);
            //Console.WriteLine("Wilderness");
            //Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 5, row + 8);
            //Console.WriteLine("Vancouver");
            //Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 19, row + 8);
            //Console.WriteLine("Wilderness");
            //Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 5, row + 10);
            //Console.WriteLine("Wilderness");
            //Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 7, row + 12);
            //Console.WriteLine("Seattle");
            //Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 28, row + 10);
            //Console.WriteLine("N");
            //Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 29, row + 11);
            //Console.WriteLine("E");
            //Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 28, row + 12);
            //Console.WriteLine("S");
            //Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 27, row + 11);
            //Console.WriteLine("W ");

            Console.BackgroundColor = ConsoleTheme.MapBoxHeaderBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MapBoxHeaderForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 15, ConsoleLayout.MapBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center("Map", ConsoleLayout.MapBoxWidth - 30));
            int startingRow = ConsoleLayout.MapBoxPositionTop + 1;
            int row = startingRow;
            Console.BackgroundColor = ConsoleTheme.MapBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MapBoxForegroundColor;


                for (int index = 0; index < _gameUniverse.RegionLocations.Count ; index++)
                {   
                    
                    // highlight current location
                    if (_gameTraveler.CurrentRegionLocationID == _gameUniverse.RegionLocations[index].RegionLocationID)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    else
                    {
                        Console.BackgroundColor = ConsoleTheme.MapBoxBackgroundColor;
                        Console.ForegroundColor = ConsoleTheme.MapBoxForegroundColor;
                    }

                // if location is on the visited locations list or its the users current location, display it
                if (_gameTraveler.RegionLocationsVisited.Contains(_gameUniverse.RegionLocations[index].RegionLocationID) || _gameTraveler.CurrentRegionLocationID == _gameUniverse.RegionLocations[index].RegionLocationID)
                {
                    Console.SetCursorPosition(_gameUniverse.RegionLocations[index].PositonLeft, _gameUniverse.RegionLocations[index].PositionTop);
                    Console.WriteLine(_gameUniverse.RegionLocations[index].CommonName);
                }
                else
                {
                    Console.SetCursorPosition(_gameUniverse.RegionLocations[index].PositonLeft, _gameUniverse.RegionLocations[index].PositionTop);
                    Console.WriteLine("");
                }

                // reapply styling....fixes bug that makes mulitple locations red when traveling to loc ID10
                
                Console.BackgroundColor = ConsoleTheme.MapBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.MapBoxForegroundColor;

                foreach (RegionLocation rl in _gameUniverse.RegionLocations)
                    {
                        if (rl.RegionLocationID == _gameTraveler.CurrentRegionLocationID)
                        {
                            foreach (var locationNum in rl.CanTravelToNext)
                            {
                                if (!_gameTraveler.RegionLocationsVisited.Contains(locationNum))
                                {
                                    Console.SetCursorPosition(_gameUniverse.RegionLocations[locationNum-1].PositonLeft, _gameUniverse.RegionLocations[locationNum-1].PositionTop);
                                    Console.WriteLine($"???({locationNum})???");
                                }
                            }
                        }
                    }

                }

            Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 28, row + 10);
            Console.WriteLine("N");
            Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 29, row + 11);
            Console.WriteLine("E");
            Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 28, row + 12);
            Console.WriteLine("S");
            Console.SetCursorPosition(ConsoleLayout.MapBoxPositionLeft + 27, row + 11);
            Console.WriteLine("W ");

        }
        public void DisplayInventoryBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InventoryBoxPositionTop,
                ConsoleLayout.InventoryBoxPositionLeft,
                ConsoleLayout.InventoryBoxWidth,
                ConsoleLayout.InventoryBoxHeight);
        }
        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>prospector object with all properties updated</returns>
        public Prospector GetInitialTravelerInfo()
        {
            Prospector prospector = new Prospector();

            //
            // intro
            //
            DisplayGamePlayScreen("Adventure Prep", Text.InitializeAdventureIntro(), ActionMenu.GameIntro, "");
            GetContinueKey();

            //
            // get prospector's name
            //
            DisplayGamePlayScreen("Adventure Prep - Name", Text.InitializeAdventureGetProspectorName(), ActionMenu.GameIntro, "");
            DisplayInputBoxPrompt("Enter your name: ");
            prospector.Name = GetString();

            //
            // get prospector's age
            //
            //DisplayGamePlayScreen("Adventure Prep - Age", Text.InitializeAdventureGetTravelerAge(prospector), ActionMenu.GameIntro, "");
            //int prospectorAge;
            //GetInteger($"Enter your age {prospector.Name}: ", 0, 100, out prospectorAge);
            //prospector.Age = prospectorAge;

            //
            // get prospector's title
            //
            DisplayGamePlayScreen("Adventure Prep - Title", Text.InitializeMissionGetTravelerTitle(prospector), ActionMenu.GameIntro, "");
            DisplayInputBoxPrompt($"Enter your Title {prospector.Name}: ");
            prospector.title = GetTitle();

            //
            // get prospector's address
            //
            DisplayGamePlayScreen("Adventure Prep - Address", Text.InitializeAdventureGetProspectorAddress(), ActionMenu.GameIntro, "");
            DisplayInputBoxPrompt("Enter your Full Address: ");
            prospector.ProspectorAddress = GetString();
            //
            // get prospector's health
            //
            DisplayGamePlayScreen("Adventure Prep - Health Status", Text.InitializeAdventureGetTravelerHealth(prospector), ActionMenu.GameIntro, "");
            DisplayInputBoxPrompt($"Enter your current Status {prospector.Name}: ");
            prospector.PlayerHealthStatus = GetHealthStatus();

            //
            // get prospector's hunt experience
            //
            DisplayGamePlayScreen("Adventure Prep - Hunting or Fishing Experience", Text.InitializeAdventureGetHuntExperience(prospector), ActionMenu.GameIntro, "");
            DisplayInputBoxPrompt($"Enter TRUE or FALSE {prospector.Name}: ");
            prospector.HasFishedHunted = GetBool();

            //
            // get prospector's klondike knowledge
            //
            DisplayGamePlayScreen("Adventure Prep - Prior Knowledge", Text.InitializeAdventureGetPriorKnowledge(prospector), ActionMenu.GameIntro, "");
            DisplayInputBoxPrompt($"Enter TRUE or FALSE {prospector.Name}: ");
            prospector.PriorKnowledge = GetBool();

            //
            // echo the prospector's info
            //
            DisplayGamePlayScreen("Adventure Prep - Complete", Text.InitializeMissionEchoTravelerInfo(prospector), ActionMenu.GameIntro, "");
            GetContinueKey();

            return prospector;
        }

        #region ----- display responses to menu action choices -----

        public void DisplayTravelerInfo()
        {
            DisplayGamePlayScreen("Prospector Information", Text.TravelerInfo(_gameTraveler), ActionMenu.MainMenu, "");
        }

        public int DisplayPlayerEdit(Prospector gamePlayer)
        {


            DisplayGamePlayScreen("Adventure Prep - Account Edit", Text.DisplayAccountInfo(_gameTraveler), ActionMenu.MainMenu, "");

            int playerChoice;
            GetInteger("Enter a Number:", 1, 7, out playerChoice);
            ClearInputBox();
            return playerChoice;
        }
        public Prospector DisplayPlayerEditPrompt(int playerChoice) { 
            switch (playerChoice)
            { case 1:
                    DisplayInputBoxPrompt($"Enter Your New Name: ");
                    _gameTraveler.Name = GetString();
                    break;
               case 2:
                    DisplayInputBoxPrompt($"Enter A New Title: ");
                    _gameTraveler.title = GetTitle();
                    break;
                case 3:
                    DisplayInputBoxPrompt($"Enter New Age: ");
                    int prospectorAge;
                    GetInteger($"Enter your age {_gameTraveler.Name}: ", 0, 100, out prospectorAge);
                    _gameTraveler.Age = prospectorAge;
                    break;
                case 4:
                    DisplayInputBoxPrompt($"Enter New Address: ");
                    _gameTraveler.ProspectorAddress = GetString();
                    break;
                case 5:
                    DisplayInputBoxPrompt($"Enter new Health Status: ");
                    _gameTraveler.PlayerHealthStatus = GetHealthStatus();
                    break;
                case 6:
                    DisplayInputBoxPrompt($"Enter Hunting Experience: ");
                    _gameTraveler.HasFishedHunted = GetBool();
                    break;
                case 7:
                    DisplayInputBoxPrompt($"Enter Prior Knowledge: ");
                    _gameTraveler.PriorKnowledge = GetBool();
                    break;
                default:
                    break;
            }
            return _gameTraveler;
        }

        public void DisplayUpdatedTravelerInfo(Prospector gameplayer)
        {
            DisplayGamePlayScreen("Prospector Updated Information", Text.TravelerInfo(gameplayer), ActionMenu.MainMenu, "");
        }


        public void DisplayListOfRegionLocations()
        {
            DisplayGamePlayScreen("List: Region Locations", Text.ListRegionLocations
                (_gameUniverse.RegionLocations), ActionMenu.MainMenu, "");
        }

        #region ----- display responses to menu action choices -----


        public void DisplayLookAround()
        {
            RegionLocation currentRegionLocation = _gameUniverse.GetRegionLocationById
                (_gameTraveler.CurrentRegionLocationID);
            DisplayGamePlayScreen("Current Location", Text.LookAround(currentRegionLocation), ActionMenu.MainMenu, "");
        }

        public int DisplayGetNextRegionLocation()
        {
            int regionLocationID = 0;
            bool validRegionLocationId = false;

            DisplayGamePlayScreen($"Travel, Current Location {_gameUniverse.RegionLocations[_gameTraveler.CurrentRegionLocationID -1].CommonName}", Text.Travel(_gameTraveler, _gameUniverse.RegionLocations), ActionMenu.MainMenu, "");

            while (!validRegionLocationId)
            {
                //
                // get an integer from the player
                //
                GetInteger($"Enter your new location {_gameTraveler.Name}: ", 1, _gameUniverse.GetMaxRegionLocationId(), out regionLocationID);

                //
                // validate integer as a valid space-time location id and determine accessibility
                //
                if (_gameUniverse.IsValidRegionLocationLocationId(regionLocationID))
                {
                    if (_gameUniverse.GetRegionLocationById(_gameTraveler.CurrentRegionLocationID).CanTravelToNext.Contains(regionLocationID))
                    {
                        validRegionLocationId = true;
                        //if (_gameUniverse.RegionLocations[regionLocationID].CanTravelToNext.Contains(regionLocationID))
                        //{
                        //    validRegionLocationId = true;
                        //}
                        //else
                        //{
                        //    ClearInputBox();
                        //    DisplayInputErrorMessage("You don't have enough experience points to enter!");
                        //}

                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you attempting to travel to an inaccessible location. Please try again.");
                    }
                }
                else
                {
                    DisplayInputErrorMessage($"It appears you entered an{regionLocationID} invalid Space-Time location id. Please try again.");
                }
            }

            return regionLocationID;
        }
        public void DisplayLocationsVisited()
        {
            // generate a list of space time locations that have been visited

            List<RegionLocation> visitedRegionLocations = new List<RegionLocation>();
            foreach (int regionLocationId in _gameTraveler.RegionLocationsVisited)
            {
                visitedRegionLocations.Add(_gameUniverse.GetRegionLocationById(regionLocationId));
            }

            DisplayGamePlayScreen("Regions Visited", Text.VisitedLocations(visitedRegionLocations), ActionMenu.MainMenu, "");

        }
        #endregion

        #endregion
        #endregion
    }
}
