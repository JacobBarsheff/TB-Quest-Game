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
            DisplayInventoryBox(_gameTraveler);
        }

        public void DisplayGamePlayScreenHighlighted(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt, int currentSelection)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBoxHighlighted(messageBoxHeaderText, messageBoxText, currentSelection);
            DisplayMenuBox(menu);
            DisplayInputBox();
            string playerHealth = " ";
            DisplayHealthBox($"Player Status", playerHealth);
            DisplayMapBox();
            DisplayInventoryBox(_gameTraveler);
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

            //
            // validate on range if either minimumValue and maximumValue are not 0
            //
            bool validateRange = (minimumValue != 0 || maximumValue != 0);

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)


            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (validateRange)
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
                        validResponse = true;
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            Console.CursorVisible = false;

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
        private void DisplayMessageBoxHighlighted(string headerText, string messageText, int currentSelection)
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
            int startingRow1 = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow2 = startingRow1 + messageTextLines.Count();
            int row3 = startingRow1;
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);
            for (int i = 0; i < ConsoleLayout.MessageBoxHeight; i++)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row3);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("                                                                            ");
                row3 += 1;
                i++;
            }
            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            int counter = 1;
            foreach (string messageTextLine in messageTextLines)
            {
                if (currentSelection ==  counter)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
                row++;
                counter++;
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
            Console.ForegroundColor = ConsoleTheme.HealthBoxForegroundColor;
            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;


            Console.SetCursorPosition(ConsoleLayout.HealthBoxPositionLeft + 2, ConsoleLayout.HealthBoxPositionTop + 2);
            Console.Write($"Health { _gameTraveler.ProspectorHealth}/100");




            int startingRow = ConsoleLayout.HealthBoxPositionTop + 3;
            int row = startingRow;
            Console.SetCursorPosition(ConsoleLayout.HealthBoxPositionLeft + 2, row);
            decimal convertedPlayerHealth = (((decimal)_gameTraveler.ProspectorHealth / (decimal)100) * (decimal)33);
            int playerHealthRemaining = 33 - (int)convertedPlayerHealth;
            
            Console.BackgroundColor = ConsoleTheme.HealthBackgroundColor;     
            if(convertedPlayerHealth > 33)
            {
                convertedPlayerHealth = 33;
            }            
            for (int i = 0; i < (convertedPlayerHealth -1); i++)
            {
                Console.Write(" ");
            }

            for (int i = 0; i < playerHealthRemaining; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(" ");
            }




            //display exp
            Console.BackgroundColor = ConsoleTheme.EXPBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.EXPBoxForegroundColor;

            int startingRowExp = ConsoleLayout.HealthBoxPositionTop + 10;
            int rowExp = startingRow;
            Console.SetCursorPosition(ConsoleLayout.HealthBoxPositionLeft + 2, 8);
            Console.Write($"Current XP: {_gameTraveler.ExpPoints} ");

            Console.ForegroundColor = ConsoleTheme.HealthBoxForegroundColor;
            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;


            Console.SetCursorPosition(ConsoleLayout.HealthBoxPositionLeft + 2, 9);
            Console.Write($"Money: ${_gameTraveler.Money}");



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
        public void DisplayInventoryBox(Prospector gamePlayer)
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InventoryBoxPositionTop,
                ConsoleLayout.InventoryBoxPositionLeft,
                ConsoleLayout.InventoryBoxWidth,
                ConsoleLayout.InventoryBoxHeight);
            int row = ConsoleLayout.InventoryBoxPositionTop + 3;
            int index = 1;
            Console.SetCursorPosition(ConsoleLayout.InventoryBoxPositionLeft + 10, ConsoleLayout.InventoryBoxPositionTop+1);
            Console.WriteLine("Current Inventory");
            foreach (ProspectorObject item in gamePlayer.Inventory)
            {
                Console.SetCursorPosition(ConsoleLayout.InventoryBoxPositionLeft + 2, row);
                Console.WriteLine($"{index}.  " + item.Name);
                row++;
                index++;
            }

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
            DisplayGamePlayScreen("Prospector Information", Text.TravelerInfo(_gameTraveler), ActionMenu.ProspectorInfo, "");
        }

        public int DisplayPlayerEdit(Prospector gamePlayer)
        {


            DisplayGamePlayScreen("Adventure Prep - Account Edit", Text.DisplayAccountInfo(_gameTraveler), ActionMenu.ProspectorInfo, "");

            int playerChoice;
            GetInteger("Enter a Number, PRESS (0) TO EXIT:", 0, 7, out playerChoice);
            ClearInputBox();
            return playerChoice;
        }
        public Prospector DisplayPlayerEditPrompt(int playerChoice) { 
            switch (playerChoice)
              
            {
                case 0:
                    break;
                case 1:
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
            DisplayGamePlayScreen("Prospector Updated Information", Text.TravelerInfo(gameplayer), ActionMenu.ProspectorInfo, "");
        }


        public void DisplayListOfRegionLocations()
        {
            DisplayGamePlayScreen("List: Region Locations", Text.ListRegionLocations
                (_gameUniverse.RegionLocations), ActionMenu.AdminMenu, "");
        }

        #region ----- display responses to menu action choices -----


        public void DisplayLookAround()
        {
            RegionLocation currentRegionLocation = _gameUniverse.GetRegionLocationById(_gameTraveler.CurrentRegionLocationID);
            //DisplayGamePlayScreen("Current Location", Text.LookAround(currentRegionLocation), ActionMenu.MainMenu, "");

            // get list of objects in current region location


            List<GameObject> gameObjectsInCurrentRegionLocation = _gameUniverse.GetGameObjectsByRegionLocationId(_gameTraveler.CurrentRegionLocationID);

            List<Npc> npcsInCurrentRegionLocation = _gameUniverse.GetNpcsByRegionLocationId(_gameTraveler.CurrentRegionLocationID);

            string messageBoxText = Text.LookAround(currentRegionLocation) + Environment.NewLine + Environment.NewLine;
            messageBoxText += Text.GameObjectsChooseList(gameObjectsInCurrentRegionLocation) + Environment.NewLine;

            //
            //get list of npc
            //


            messageBoxText += Text.NpcsChooseList(npcsInCurrentRegionLocation);

            DisplayGamePlayScreen("Current Location", messageBoxText, ActionMenu.MainMenu, "");

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

            DisplayGamePlayScreen("Regions Visited", Text.VisitedLocations(visitedRegionLocations), ActionMenu.ProspectorInfo, "");

        }
        public void DisplayListOfAllGameObjects()
        {
            // _gameUniverse.GameObjects.OrderBy(x => x.RegionLocationId);
            Console.CursorVisible = false;
            int userMenuNumber = 1;
            bool done = false;
            do {
            List<GameObject> sortedList = new List<GameObject>();
            if (userMenuNumber == 1)
            {

                int start = 1;
                for (int i = 0; sortedList.Count < 17; i++)
                {
    
                    foreach (var item in _gameUniverse.GameObjects)
                    {
                        if (item.RegionLocationId == start)
                        {
                        sortedList.Add(item);

                        }
                        
                    }
                          start++;  
                    
                }
            }
            else
            {
                int start = 6;
                for (int i = 0; i < 20; i++)
                {

                    foreach (var item in _gameUniverse.GameObjects)
                    {
                        if (item.RegionLocationId == start)
                        {
                            sortedList.Add(item);

                        }

                    }
                    start++;

                }
            }


                DisplayGamePlayScreen("List: Game Objects", $"{Text.ListAllGameObjects(sortedList)}\n \nPlease use the left and right arrow keys to navigate list, or Escape to select a menu option.\nPage {userMenuNumber}/2", ActionMenu.AdminMenu, "");
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.LeftArrow)
                {
                    if (userMenuNumber == 1)
                    {
                        userMenuNumber = 2;
                    }
                    else
                    {
                        userMenuNumber = 1;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.RightArrow)
                {
                    if (userMenuNumber == 1)
                    {
                        userMenuNumber = 2;
                    }
                    else
                    {
                        userMenuNumber = 1;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.Escape)
                {
                    done = true;
                }
   

        } while (!done);
           


        }
        public int DisplayGetGameObjectToLookAt()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;

            //
            //get a list of game objects in the current region-location
            //

            List<GameObject> gameObjectsinRegionLocation = _gameUniverse.GetGameObjectsByRegionLocationId(_gameTraveler.CurrentRegionLocationID);
            if (gameObjectsinRegionLocation.Count > 0)
            {
                DisplayGamePlayScreen("Look at a Object", Text.GameObjectsChooseList(gameObjectsinRegionLocation), ActionMenu.NpcMenu, "");

                while (!validGameObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to look at: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as a valid game object id and in current location
                    //
                    if (_gameUniverse.IsValidGameObjectByLocationId(gameObjectId, _gameTraveler.CurrentRegionLocationID))
                    {
                        validGameObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Look at a Object", "It appears there are no game objects here.", ActionMenu.NpcMenu, "");
            }

            return gameObjectId;



        }
        public void DisplayGameObjectInfo(GameObject gameObject)
        {
            DisplayGamePlayScreen("Current Location", Text.LookAt(gameObject), ActionMenu.NpcMenu, "");
        }
        public void DisplayInventory()
        {
            DisplayGamePlayScreen("Current Inventory", Text.CurrentInventory(_gameTraveler.Inventory), ActionMenu.MainMenu, "");
        }
        public int DisplayGetTravelerObjectToPickUp()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;

            //
            // get a list of traveler objects in the current space-time location
            //
            List<ProspectorObject> travelerObjectsInSpaceTimeLocation = _gameUniverse.GetTravelerObjectsBySpaceTimeLocationId(_gameTraveler.CurrentRegionLocationID);

            if (travelerObjectsInSpaceTimeLocation.Count > 0)
            {
                DisplayGamePlayScreen("Pick Up Game Object", Text.GameObjectsChooseList(travelerObjectsInSpaceTimeLocation), ActionMenu.MainMenu, "");

                while (!validGameObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to add to your inventory: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as a valid game object id and in current location
                    //
                    if (_gameUniverse.IsValidTravelerObjectByLocationId(gameObjectId, _gameTraveler.CurrentRegionLocationID))
                    {
                        ProspectorObject travelerObject = _gameUniverse.GetGameObjectById(gameObjectId) as ProspectorObject;
                        if (travelerObject.CanInventory)
                        {
                            validGameObjectId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears you may not inventory that object. Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no game objects here.", ActionMenu.MainMenu, "");
            }

            return gameObjectId;
        }
        public int DisplayGetInventoryObjectToPutDown()
        {
            int travelerObjectId = 0;
            bool validInventoryObjectId = false;

            if (_gameTraveler.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Put Down Game Object", Text.GameObjectsChooseList(_gameTraveler.Inventory), ActionMenu.MainMenu, "");

                while (!validInventoryObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to remove from your inventory: ", 0, 0, out travelerObjectId);

                    //
                    // find object in inventory
                    // note: LINQ used, but a foreach loop may also be used 
                    //
                    ProspectorObject objectToPutDown = _gameTraveler.Inventory.FirstOrDefault(o => o.Id == travelerObjectId);

                    //
                    // validate object in inventory
                    //
                    if (objectToPutDown != null)
                    {
                        validInventoryObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered the Id of an object not in the inventory. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no objects currently in inventory.", ActionMenu.MainMenu, "");
            }

            return travelerObjectId;
        }
        public void DisplayConfirmTravelerObjectAddedToInventory(ProspectorObject objectAddedToInventory)
        {
            if (objectAddedToInventory.PickUpMessage != null)
            {
                           DisplayGamePlayScreen("Pick Up Game Object",objectAddedToInventory.PickUpMessage, ActionMenu.MainMenu, "");
            }
            else
            {
            DisplayGamePlayScreen("Pick Up Game Object", $"The {objectAddedToInventory.Name} has been added to your inventory.", ActionMenu.MainMenu, "");
            }
            
        }
        public void DisplayConfirmTravelerObjectAddedToMoney(ProspectorObject objectAddedToInventory)
        {
            DisplayGamePlayScreen("Pick Up Treasure", $"The {objectAddedToInventory.Name} has been added to your wallet!", ActionMenu.MainMenu, "");
        }

        public void DisplayConfirmTravelerObjectRemovedFromInventory(ProspectorObject objectRemovedFromInventory)
        {
            DisplayGamePlayScreen("Put Down Game Object", $"The {objectRemovedFromInventory.Name} has been removed from your inventory.", ActionMenu.useItem, "");
        }
        public int DisplayShopOptions()
        {
            DisplayGamePlayScreen("Weclome to the Store!", "Would you like to BUY(1) or SELL(2) items?", ActionMenu.MainMenu, "");
            int userChoice;
            GetInteger($"Please press (1) to BUY and (2) to SELL and (3) to EXIT", 1, 3, out userChoice);

            return userChoice;
        }
        public GameObject DisplayBuy(double itemPercent)
        {

            Random rnd = new Random();
            int num = rnd.Next(2, 6);
            List<GameObject> shopItems = new List<GameObject>();
            for (int i = 0; i < num;)
            {
                Random rnd2 = new Random();

                int num2 = rnd.Next(1, _gameUniverse.GameObjects.Count());

                ProspectorObject travelerObject = _gameUniverse.GetGameObjectById(num2) as ProspectorObject;
                List<string> shopItemString = new List<string>();
                foreach (var shopitem in shopItems)
                {
                    shopItemString.Add(shopitem.Name);
                }
                if (travelerObject.Type == ProspectorObjectType.Treasure || shopItemString.Contains(_gameUniverse.GetGameObjectById(num2).Name.ToString()) || travelerObject.Value < 0)
                {
                    break;
                }
                else
                {
                shopItems.Add(_gameUniverse.GetGameObjectById(num2));
                    i++;
                }      
                
            }
            
            
            DisplayGamePlayScreen("Weclome to the Store!", Text.DisplayShopItems(shopItems, itemPercent), ActionMenu.MainMenu, "");
            int userChoice;
            GetInteger($"Enter the Item Number you would like to buy", 0, shopItems.Count, out userChoice);


            return shopItems[userChoice - 1];
            


        }
        public void DisplayConfirmationPurchase(ProspectorObject itembought)
        {
            DisplayGamePlayScreen("Purchase Complete!", $"You bought {itembought.Name} for ${itembought.Value}.00. You have ${_gameTraveler.Money} left", ActionMenu.MainMenu, "");
        }
        public void DisplayConfirmationSell(ProspectorObject itemsold)
        {
            DisplayGamePlayScreen("Sell Complete!", $"You sold {itemsold.Name} for ${(int)(itemsold.Value*.5)}. You have ${_gameTraveler.Money} left", ActionMenu.MainMenu, "");
        }
        public void DisplayNoShop()
        {
            DisplayGamePlayScreen("Shop Canceled", $"Please select a menu option on the right!", ActionMenu.MainMenu, "");
        }

        public void DisplayCanNotVisitShop ()
        {
            DisplayGamePlayScreen("Invalid Selection", $"Looks like your not in a city! You must be in a city to access that function!", ActionMenu.MainMenu, "");
        }

        public GameObject DisplaySell()
        {
            DisplayGamePlayScreen("Current Inventory", Text.CurrentInventorySell(_gameTraveler.Inventory), ActionMenu.MainMenu, "");
            int userChoice = 0;
            GetInteger($"Enter the Item Number you would like to sell", 0, _gameTraveler.Inventory.Count, out userChoice);
            return _gameTraveler.Inventory[userChoice - 1];
        }
        public GameObject DisplaySellToNPC()
        {
            DisplayGamePlayScreen("Current Inventory", Text.CurrentInventorySellToNPC(_gameTraveler.Inventory), ActionMenu.MainMenu, "");
            int userChoice = 0;
            GetInteger($"Enter the Item Number you would like to sell", 0, _gameTraveler.Inventory.Count, out userChoice);
            return _gameTraveler.Inventory[userChoice - 1];
        }
        public void DisplayCanNotBuy()
        {
            DisplayGamePlayScreen("Declined", $"Looks like you don't have enough money to purchase this item.", ActionMenu.MainMenu, "");
        }
        public void DisplayListOfAllNpcObjects()
        {
            DisplayGamePlayScreen("List: Npc Objects", Text.ListAllNpcObjects(_gameUniverse.Npcs), ActionMenu.AdminMenu, "");
        }
        public int DisplayGetNpcToTalkTo()
        {
            int npcId = 0;
            bool validNpcId = false;

            List<Npc> npcsInRegionLocation = _gameUniverse.GetNpcsByRegionLocationId(_gameTraveler.CurrentRegionLocationID);

            if (npcsInRegionLocation.Count > 0)
            {
                DisplayGamePlayScreen("Choose A Character To Speak With", Text.NpcsChooseList(npcsInRegionLocation), ActionMenu.NpcMenu,"");

                while (!validNpcId)
                {
                    //
                    //get an integer from the player
                    //
                    GetInteger($"Enter the Number of the character you would like to speak with:", 0, 0, out npcId);

                    if (_gameUniverse.IsValidNpcByLocation(npcId, _gameTraveler.CurrentRegionLocationID))
                    {
                        Npc npc = _gameUniverse.GetNpcById(npcId);

                        if (npc is ISpeak)
                        {
                            validNpcId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears this character has nothing to say");
                        }

                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid NPC id. Please try again");
                    }

                }
            }
            else
            {
                DisplayGamePlayScreen("Choose a character to Speak With", "It appears there are no NPCs here.", ActionMenu.NpcMenu, "");
            }
            return npcId;
        }
        public int DisplayGetNpcToSellTo()
        {
            int npcId = 0;
            bool validNpcId = false;

            List<Npc> npcsInRegionLocation = _gameUniverse.GetNpcsByRegionLocationId(_gameTraveler.CurrentRegionLocationID);

            if (npcsInRegionLocation.Count > 0)
            {
                DisplayGamePlayScreen("Choose A Character To Sell To", Text.NpcsChooseList(npcsInRegionLocation), ActionMenu.NpcMenu, "");

                while (!validNpcId)
                {
                    //
                    //get an integer from the player
                    //
                    GetInteger($"Enter the Number of the character you would like to sell with:", 0, 0, out npcId);

                    if (_gameUniverse.IsValidNpcByLocation(npcId, _gameTraveler.CurrentRegionLocationID))
                    {
                        Npc npc = _gameUniverse.GetNpcById(npcId);

                        if (npc is ISpeak)
                        {
                            validNpcId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears this character has nothing to say");
                        }

                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid NPC id. Please try again");
                    }

                }
            }
            else
            {
                DisplayGamePlayScreen("Choose a character to Speak With", "It appears there are no NPCs here.", ActionMenu.NpcMenu, "");
            }
            return npcId;
        }
        public void DisplayTalkTo(Npc npc)
        {
            ISpeak speakingNpc = npc as ISpeak;

            string message = speakingNpc.Speak();

            if (message == "")
            {
                message = "It appears the character has nothing to say."; 
            }

            DisplayGamePlayScreen("Speaking to Character", message, ActionMenu.NpcMenu, "");

        }
        public int DisplayItemStats(string actionType)
        {

            Console.CursorVisible = false;
            bool ItemSelected = false;
            int currentSelection = 3;

            string currentItemInfo = $"Select {_gameTraveler.Inventory[currentSelection - 3].Name}?";
            DisplayInputBoxPrompt("Press Enter To Select Item, Or ESCAPE to leave");
            do
            {

                if (actionType == "consume")
                {
                    if (_gameTraveler.Inventory[currentSelection - 3].Type == ProspectorObjectType.Food || _gameTraveler.Inventory[currentSelection -3].Type == ProspectorObjectType.Medicine)
                    {
                        if (_gameTraveler.Inventory[currentSelection - 3].Value < 0)
                        {
                            currentItemInfo = $"Description:'{_gameTraveler.Inventory[currentSelection - 3].Description}'\n {_gameTraveler.Inventory[currentSelection - 3].Name} will heal ????." +
                           $"\n Your health may rise or lower...A risk you can afford?";
                        }
                        else
                        {
                        currentItemInfo = $"Description:'{_gameTraveler.Inventory[currentSelection - 3].Description}'\n {_gameTraveler.Inventory[currentSelection - 3].Name} will heal {_gameTraveler.Inventory[currentSelection - 3].Value}." +
                            $"\n Your health would rise to {_gameTraveler.ProspectorHealth + _gameTraveler.Inventory[currentSelection - 3].Value}";
                        }
                     
                    }
                    else
                    {
                       currentItemInfo = $"Description:'{_gameTraveler.Inventory[currentSelection - 3].Description}'\n {_gameTraveler.Inventory[currentSelection - 3].Name} is a {_gameTraveler.Inventory[currentSelection - 3].Type} and can not be consumed!";
                    }
                }
                else if (actionType == "wield")
                {
                    if (_gameTraveler.Inventory[currentSelection - 3].Type == ProspectorObjectType.Weapon)
                    {

                        currentItemInfo = $"Description:'{_gameTraveler.Inventory[currentSelection - 3].Description}'\n {_gameTraveler.Inventory[currentSelection - 3].Name} will add {_gameTraveler.Inventory[currentSelection - 3].Value} attack points." +
                              $"\n Your attack level would rise to { _gameTraveler.Inventory[currentSelection - 3].Value + _gameTraveler.AttackLevel}";
                    }
                    else if (_gameTraveler.Inventory[currentSelection - 3].Type == ProspectorObjectType.Tool)
                    {
                        currentItemInfo = $"Description:'{_gameTraveler.Inventory[currentSelection - 3].Description}'\n {_gameTraveler.Inventory[currentSelection - 3].Name} is a tool and should be used to as one. However, it can be used as a weapon and will add {_gameTraveler.Inventory[currentSelection - 3].Value} attack points." +
                             $"\n Your attack level would rise to { _gameTraveler.Inventory[currentSelection - 3].Value + _gameTraveler.AttackLevel}";
                    }
                    else
                    {
                        currentItemInfo = $"Description:{_gameTraveler.Inventory[currentSelection - 3].Name} is a {_gameTraveler.Inventory[currentSelection - 3].Type} and can not be wielded!";
                    }
                }

                DisplayMessageBoxHighlighted("Item Selection", $"{Text.CurrentInventoryHighlighted(_gameTraveler.Inventory, currentSelection)}" + $"\n \n \n {currentItemInfo}", currentSelection);
                Console.CursorVisible = false;
                ConsoleKeyInfo keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (currentSelection >= _gameTraveler.Inventory.Count() + 2)
                    {
                    currentSelection = 3;
                    }
                    else
                    {
                        currentSelection += 1;
                    }
                    
                    
                }
                else if(keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (currentSelection == 3)
                    {
                        currentSelection = _gameTraveler.Inventory.Count() + 2;
                    }
                    else
                    {
                        currentSelection -= 1;
                    }
                }
                else if(keyinfo.Key == ConsoleKey.Enter)
                {
                    ItemSelected = true;
                }
                else if(keyinfo.Key == ConsoleKey.Escape)
                {
                    currentSelection = 0;
                    ItemSelected = true;
                }

            } while (!ItemSelected);




            return currentSelection;


        }
        #endregion

        #endregion
        #endregion
    }
}
