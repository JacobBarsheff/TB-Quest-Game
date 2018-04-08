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
    public static partial class UniverseObjects
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
                Accessible = true,
                GeneralContents = "General Contents\n",
                ExperiencePoints = 10,
                PointsToEnter = 0,
                CanTravelToNext = new List<int>()
                {
                    2,
                    8
                },
                PositonLeft = 128,
                PositionTop = 16
                

            },

            new RegionLocation
            {
                CommonName = "Wilderness",
                RegionLocationID = 2,
                Description = "After walking for sometime you find yourself in the wilderness! You look around" +
                "and see an abundance of wood, water, and wildlife!" +
                "Far from the nearest town, your next action may be your last. What would you like to" +
                "do next?",
                Accessible = true,
                GeneralContents = "Health Potion (+10 HP)\n" +
                "Medic Kit(+1 Life)",
                ExperiencePoints = 10,
                CanTravelToNext = new List<int>()
                {
                    1,
                    3,
                    8
                },
                PositonLeft = 126,
                PositionTop = 14

            },

            new RegionLocation
            {
                CommonName = "Vancouver",
                RegionLocationID = 3,
                Description = "A small town just north of Seattle, their are many people who are passing through " +
                "town, on their way further north. Vancouver has several shops and Inns you can stay and rest up at!",
                GeneralContents = "Super Medic Kit(+5 Lives)",
                ExperiencePoints = 10,
                Accessible = true,
                CanTravelToNext = new List<int>()
                {   2,
                    4,
                    8
                },
                PositonLeft = 126,
                PositionTop = 12

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
                Accessible = true,
                CanTravelToNext = new List<int>()
                {
                    3,
                    5,
                    8,
                    10
                },
                PositonLeft = 126,
                PositionTop = 10
            },

            new RegionLocation
            {
                CommonName = "Skagway",
                RegionLocationID = 5,
                Description = "Deep in the north, you stumble upon Skagway. A small town with just over 500 people living here." +
                "Not much to do here. ",
                GeneralContents = "Super Medic Kit(+5 Lives)",
                ExperiencePoints = 20,
                Accessible = true,
                CanTravelToNext = new List<int>()
                {
                    4,
                    6,
                    10
                },
                PositonLeft = 124,
                PositionTop = 8

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
                Accessible = true,
                CanTravelToNext = new List<int>()
                {   
                    5,
                    7,
                    10
                },
                PositonLeft = 124,
                PositionTop = 6
            },

            new RegionLocation
            {
                CommonName = "Dawson",
                RegionLocationID = 7,
                Description = "Dawson",
                GeneralContents = "Super Medic Kit(+5 Lives)",
                ExperiencePoints = 25,
                Accessible = true,
                CanTravelToNext = new List<int>()
                {
                    6,
                },
                PositonLeft = 123,
                PositionTop = 4

                
            },

            new RegionLocation
            {
                CommonName = "Wilderness",
                RegionLocationID = 8,
                Description = "After walking for sometime you find yourself in the wilderness! You look around" +
                "and see an abundance of wood, water, and wildlife!" +
                "Far from the nearest town, your next action may be your last. What would you like to" +
                "do next?",
                GeneralContents = "Super Medic Kit(+5 Lives)",
                ExperiencePoints = 30,
                Accessible = true,
                CanTravelToNext = new List<int>()
                {
                    2,
                    3,
                    4,
                    10
                },
                PositonLeft = 140,
                PositionTop = 12
            },
            new RegionLocation
            {
                CommonName = "Edmonton",
                RegionLocationID = 9,
                Description = "Edmonton.",
                GeneralContents = "Super Medic Kit(+5 Lives)",
                ExperiencePoints = 30,
                Accessible = true,
                CanTravelToNext = new List<int>()
                {
                    6,
                    10
                },
                PositionTop = 6,
                PositonLeft =  145
            },
            new RegionLocation
            {
                CommonName = "Wilderness",
                RegionLocationID = 10,
                Description = "After walking for sometime you find yourself in the wilderness! You look around" +
                "and see an abundance of wood, water, and wildlife!" +
                "Far from the nearest town, your next action may be your last. What would you like to" +
                "do next?",
                GeneralContents = "Super Medic Kit(+5 Lives)",
                ExperiencePoints = 40,
                Accessible = true,
                CanTravelToNext = new List<int>()
                {
                    4,
                    5,
                    6,
                    8,
                    9
                },
                PositonLeft = 135,
                PositionTop = 8
            },
        };
    }
}

