using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "The Klondike Gold Rush" };
        public static List<string> FooterText = new List<string>() { "Elite Enertainment, 2018" };

        #region INTITIAL GAME SETUP

        public static string GameIntro()
        {
            string messageBoxText =
            "The summer of 1896 is quickly drawing to an end. After losing your job" +
            " you begin to worry about the supplies needed to support your family." +
            " As the weeks without income continue, you watch your personal savings diminish and urgently look for new opportunities." +
            " \n" +
            " \n" +
            "In big, bold letters, the newspaper reads: THE RUSH IS ON FOR GOLD IN KLONDIKE.\n" +
            " \n" +
            "You read about the thousands of people setting out for northwestern canada in hopes to strike it rich." +
            "Your heart starts to race after reading of the successes people are having and the wealth available." +
            "You decide to pack your bags, and set out as a pioneer\n" +
            "\n \n \n" +
            "\n\nTo begin your Journey North, you must fill out a form to confirm your identity.\n" +
            "\n \n \n \n \n" +
            "\tPress any key to begin!\n";

            return messageBoxText;
        }

        public static string CurrrentLocationInfo()
        {
            string messageBoxText =
            "You are located in the bustling city of Seattle! North of you lies the great " +
            "Canadian wilderness and Tundra! The world is yours.\n" +
            " \n" +
            "\tChoose from the menu options to proceed.\n";

            return messageBoxText;
        }

        #region Initialize Mission Text

        public static string InitializeAdventureIntro()
        {
            string messageBoxText =
                "As you prepare yourself for the long journey ahead, you'll need to fill out identification papers.\n" +
                "\n" +
                "You will be prompted for the required information. Please enter the information below.\n" +
                " \n" +
                "\tPress any key to begin.";

            return messageBoxText;
        }

        public static string InitializeAdventureGetProspectorName()
        {
            string messageBoxText =
                "Enter your First and Last Name:";
            return messageBoxText;
        }

        public static string InitializeAdventureGetProspectorAddress()
        {
            string messageBoxText =
                "Enter your Full Address:";
            return messageBoxText;
        }

        public static string InitializeAdventureGetTravelerAge(Prospector prospector)
        {
            string messageBoxText =
                $"From now on, you'll be known as {prospector.Name} on this adventure.\n" +
                "\n" +
                "Next, we need you to Enter your age below";

            return messageBoxText;
        }

        public static string InitializeAdventureGetHuntExperience(Prospector prospector)
        {
            string messageBoxText =
                $"As you journey across the great Canadian Plains, you may have to hunt for food.\n" +
                "\n" +
                "Do you have an Prior Experience Hunting?";

            return messageBoxText;
        }

        public static string InitializeAdventureGetPriorKnowledge(Prospector prospector)
        {
            string messageBoxText =
                $"It's important to know where you'll be headed to this journey.\n" +
                "\n" +
                "Have you heard of Klondike Before?";

            return messageBoxText;
        }
        public static string InitializeMissionGetTravelerTitle(Prospector gameTraveler)
        {
            string messageBoxText =
                $"{gameTraveler.Name}, what of the following titles best suits you?\n" +
                " \n" +
                "Please enter one of the following." +
                " \n";

            string titleList = null;

            foreach (Character.Title title in Enum.GetValues(typeof(Character.Title)))
            {
                if (title != Character.Title.None)
                {
                    titleList += $"\t{title}\n";
                }
            }

            messageBoxText += titleList;

            return messageBoxText;
        }

        public static string InitializeAdventureGetTravelerHealth(Prospector gameTraveler)
        {
            string messageBoxText =
                $"{gameTraveler.title} {gameTraveler.Name}, this journey is very dangerous! For that reason, we need to know your general health before we begin\n" +
                "Please enter one of the following." +
                " \n";

            string statusList = null;

            foreach (Prospector.overallHealth status in Enum.GetValues(typeof(Prospector.overallHealth)))
            {
                if (status != Prospector.overallHealth.None)
                {
                    statusList += $"\t{status}\n";
                }
            }

            messageBoxText += statusList;

            return messageBoxText;
        }
        public static string InitializeMissionEchoTravelerInfo(Prospector gameTraveler)
        {
            string messageBoxText =
                $"Alrighty! Well {gameTraveler.title} {gameTraveler.Name}.\n" +
                " \n" +
                "You have successfully completed the paperwork. All information is" +
                " listed below.\n" +
                " \n" +
                $"\t Your Name and Title: {gameTraveler.title} {gameTraveler.Name}\n" +
                $"\t Your Age: {gameTraveler.Age}\n" +
                $"\t Your Address: {gameTraveler.ProspectorAddress}\n" +
                $"\t Your Health Status: {gameTraveler.PlayerHealthStatus}\n" +
                $"\t Your Hunting Experience: {gameTraveler.HasFishedHunted}\n" +
                $"\t Your Knowledge about Klondike: {gameTraveler.PriorKnowledge}\n" +
                " \n" +
                "Press any key to begin your adventure.";

            return messageBoxText;
        }

        public static string DisplayAccountInfo(Prospector gameTraveler)
        {
            string messageBoxText =
                $"Below is your Current Information" +
                " \n" +
                $"\t 1) Your Name: {gameTraveler.Name}\n" +
                $"\t 2) Your Title: {gameTraveler.title}\n" +
                $"\t 3) Your Age: {gameTraveler.Age}\n" +
                $"\t 4) Your Address: {gameTraveler.ProspectorAddress}\n" +
                $"\t 5) Your Health Status: {gameTraveler.PlayerHealthStatus}\n" +
                $"\t 6) Your Hunting Experience: {gameTraveler.HasFishedHunted}\n" +
                $"\t 7) Your Knowledge about Klondike: {gameTraveler.PriorKnowledge}\n" +
                " \n" +
                "Enter the corresponding number to which field you want to change.";

            return messageBoxText;
        }
        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string TravelerInfo(Prospector gameTraveler)
        {
            string messageBoxText =
                $"\t Your Name and Title: {gameTraveler.title} {gameTraveler.Name}\n" +
                $"\t Your Age: {gameTraveler.Age}\n" +
                $"\t Your Address: {gameTraveler.ProspectorAddress}\n" +
                $"\t Your Health Status: {gameTraveler.PlayerHealthStatus}\n" +
                $"\t Your Hunting Experience: {gameTraveler.HasFishedHunted}\n" +
                $"\t Your Knowledge about Klondike: {gameTraveler.PriorKnowledge}\n" +
                $"\t Your Greeting: {gameTraveler.Greeting()}\n" +
                " \n";

            return messageBoxText;
        }

        public static string ListRegionLocations(IEnumerable<RegionLocation> regionLocations)
        {
            string messageBoxText =
                "Space-Time Locations\n" +
                " \n" +

            //
            // display table header
            //
            "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";


            //
            // display all locations
            //
            string regionLocationsList = null;
            foreach (RegionLocation rl in regionLocations)
            {
                regionLocationsList +=
                    $"{rl.RegionLocationID}".PadRight(10) +
                    $"{rl.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += regionLocationsList;

            return messageBoxText;

        }
        public static string LookAround(RegionLocation regionLocation)
        {
            string messageBoxText =
                $"Current Location: {regionLocation.CommonName}\n" +
                $" \n" +
                regionLocation.GeneralContents;

            return messageBoxText;
        }
        public static string Travel(Prospector gametraveler, List<RegionLocation> regionLocations)
        {
            string messageBoxText =
                $"{gametraveler.Name}, Where would you like to head next?\n" +
                $"Note: Remember, journeys into the wilderness can be deadly, make sure\n" +
                $"your ready!" +
                $"\n" +
                $"Enter the ID number of your desired next location below.\n" +
                $"\n" +
                $"ID".PadRight(10) + "Name".PadRight(30) + "Accessible".PadRight(10) + "\n" +
                "---".PadRight(10) + "-------------------------".PadRight(30) + "-----------".PadRight(10) + "\n";

            string regionLocationList = null;

            foreach (RegionLocation rl in regionLocations)
            {
                if (rl.RegionLocationID == gametraveler.CurrentRegionLocationID)
                {
                    foreach (var locationNum in rl.CanTravelToNext)
                    {
                        foreach (RegionLocation selectedLoc in regionLocations)
                        {
                            if (selectedLoc.RegionLocationID == locationNum)
                            {
                                regionLocationList +=
                                $"{selectedLoc.RegionLocationID}".PadRight(10);
                                    if (gametraveler.RegionLocationsVisited.Contains(selectedLoc.RegionLocationID))
                                {
                                    regionLocationList +=
                                    $"{selectedLoc.CommonName}".PadRight(30);
                                }
                                else
                                {
                                    regionLocationList +=
                                    $"????????".PadRight(30);
                                }
                                    regionLocationList +=
                                    $"{rl.Accessible}".PadRight(10) +
                                    Environment.NewLine;
                            }
                        }

                    }
                }

                //if (rl.CurrentRegionLocationID != gametraveler.CurrentRegionLocationID)
                //{

                //    regionLocationList +=                    
                //        $"{rl.CurrentRegionLocationID}".PadRight(10) +
                //        $"{rl.CommonName}".PadRight(30) +
                //        $"{rl.Accessible}".PadRight(10) +
                //        Environment.NewLine;
                //}


            }

            messageBoxText += regionLocationList;
            return messageBoxText;
        }

        public static string CurrentLocationInfo(RegionLocation regionLocation)
        {
            string messageBoxText =
                $"Current Location: {regionLocation.CommonName}\n" +
                "\n" +
                regionLocation.Description;

            return messageBoxText;
        }

        public static string VisitedLocations(IEnumerable<RegionLocation> regionLocations)
        {
            string messageBoxText =
                "Space-Time Locations Visted \n" +
                "\n" +

                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            string regionLocationList = null;
            foreach (RegionLocation rl in regionLocations)
            {
                regionLocationList +=
                    $"{rl.RegionLocationID}".PadRight(10) +
                    $"{rl.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += regionLocationList;

            return messageBoxText;
        }

        #endregion
    }
}
