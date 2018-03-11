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

            Console.CursorVisible = false;
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

                travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);

                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case ProspectorAction.None:
                        break;

                    case ProspectorAction.ProspectorInfo:
                        _gameConsoleView.DisplayTravelerInfo();
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
                    case ProspectorAction.ProspectorLocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;
                    case ProspectorAction.ListDestinations:
                        _gameConsoleView.DisplayListOfRegionLocations();
                        break;
                    case ProspectorAction.Exit:
                        _playingGame = false;
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
        #endregion
    }
}
