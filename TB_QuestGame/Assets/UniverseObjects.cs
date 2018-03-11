using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold all objects in the game universe; locations, game objects, npc's
    /// </summary>
    public static class UniverseObjects
    {
        public static List<RegionLocation> RegionLocations = new List<RegionLocation>()
        {

            new RegionLocation
            {
                CommonName = "Seattle",
                RegionLocationID = 1,
                Description = "Say hello to home! You know this place like the back of your hand. You've" +
                "spent a lot of time growing up here and have a great understanding of its layout. However," +
                "you won't be staying long..." +
                "\n",
                GeneralContents = "General Contents\n",
                ExperiencePoints = 10,
                PointsToEnter = 0,
                CanTravelToNext = new List<int>()
                {
                    2,
                    8
                }

            },

            new RegionLocation
            {
                CommonName = "Wilderness",
                RegionLocationID = 2,
                Description = "After walking for sometime you find yourself in the wilderness! You look around" +
                "and see an abundance of wood, water, and wildlife!" +
                "Far from the nearest town, your next action may be your last. What would you like to" +
                "do next?",
                GeneralContents = "Health Potion (+10 HP)\n" +
                "Medic Kit(+1 Life)",
                ExperiencePoints = 10,
                CanTravelToNext = new List<int>()
                {
                    3,
                    8
                }
            },

            new RegionLocation
            {
                CommonName = "Vancouver",
                RegionLocationID = 3,
                Description = "Vancouver.",
                GeneralContents = "Super Medic Kit(+5 Lives)",
                ExperiencePoints = 10,
                CanTravelToNext = new List<int>()
                {
                    4,
                    8
                }
            },

                        new RegionLocation
            {
                CommonName = "Wilderness",
                RegionLocationID = 4,
                Description = "After walking for sometime you find yourself in the wilderness! You look around" +
                "and see an abundance of wood, water, and wildlife!" +
                "Far from the nearest town, your next action may be your last. What would you like to" +
                "do next?",
                GeneralContents = "Super Potion (+50 HP)",
                ExperiencePoints = 20,
                CanTravelToNext = new List<int>()
                {
                    5,
                    8
                }
            },

            new RegionLocation
            {
                CommonName = "Skagway",
                RegionLocationID = 5,
                Description = "Skagway",
                GeneralContents = "Super Medic Kit(+5 Lives)",
                ExperiencePoints = 20,
                CanTravelToNext = new List<int>()
                {
                    6,
                    9
                }
            },

            new RegionLocation
            {
                CommonName = "Wilderness",
                RegionLocationID = 6,
                Description = "After walking for sometime you find yourself in the wilderness! You look around" +
                "and see an abundance of wood, water, and wildlife!" +
                "Far from the nearest town, your next action may be your last. What would you like to" +
                "do next?",
                GeneralContents = "Super Medic Kit(+5 Lives)",
                ExperiencePoints = 25,
                CanTravelToNext = new List<int>()
                {
                    7,
                    9
                }
            },

            new RegionLocation
            {
                CommonName = "Dawson",
                RegionLocationID = 7,
                Description = "Dawson",
                GeneralContents = "Super Medic Kit(+5 Lives)",
                ExperiencePoints = 25,
                CanTravelToNext = new List<int>()
                {
                    6, 
                }
            },

            new RegionLocation
            {
                CommonName = "Wilderness East",
                RegionLocationID = 8,
                Description = "After walking for sometime you find yourself in the wilderness! You look around" +
                "and see an abundance of wood, water, and wildlife!" +
                "Far from the nearest town, your next action may be your last. What would you like to" +
                "do next?",
                GeneralContents = "Super Medic Kit(+5 Lives)",
                ExperiencePoints = 30,
                CanTravelToNext = new List<int>()
                {
                    1,
                    2,
                    3,
                    10
                }
            },
            new RegionLocation
            {
                CommonName = "Edmonton",
                RegionLocationID = 9,
                Description = "Edmonton.",
                GeneralContents = "Super Medic Kit(+5 Lives)",
                ExperiencePoints = 30,
                CanTravelToNext = new List<int>()
                {
                    8,
                    10
                }
            },
            new RegionLocation
            {
                CommonName = "Wilderness West",
                RegionLocationID = 10,
                Description = "After walking for sometime you find yourself in the wilderness! You look around" +
                "and see an abundance of wood, water, and wildlife!" +
                "Far from the nearest town, your next action may be your last. What would you like to" +
                "do next?",
                GeneralContents = "Super Medic Kit(+5 Lives)",
                ExperiencePoints = 40,
                CanTravelToNext = new List<int>()
                {
                    4,
                    5,
                    6
                }
            },
        };
    }
}

