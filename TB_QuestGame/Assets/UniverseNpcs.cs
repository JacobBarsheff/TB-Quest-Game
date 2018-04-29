using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class UniverseObjects
    {
        public static List<Npc> Npcs = new List<Npc>()
        {

            new Civilian
            {
                Id = 1,
                Name = "Doc Lou",
                CurrentRegionLocationID = 1,
                healing = 1,
                expPoints = 45,
                Description = "A tall, slender man wearing a white lab coat.",
                Messages = new List<string>
                {
                    "Here's some health for you!",
                    "I'm glad you talked to me, hope you feel better!",
                    "Feeling sick, here let me help!"
                }
            },

            new Civilian
            {
                Id = 2,
                Name = "Joe Johnson",
                CurrentRegionLocationID = 2,
                expPoints = 10,
                healing = 0,
                Description = "A well dressed, short man with a Canadian Accent.",
                Messages = new List<string>
                {
                    "I haven't seen you around here before, are you new?",
                    "Hello there, whats your name?",
                    "How do you do today fine sir?"
                }
            },
            new Civilian
            {
                Id = 3,
                Name = "Brian Gold",
                CurrentRegionLocationID = 3,
                Description = "A rough looking man with a black coat and gray pants.",
                expPoints = 20,
                healing = 0,
                Messages = new List<string>
                {
                    "Have you heard about the gold rush?",
                    "Hello there, whats your name?",
                    "You look tired, want a place to stay for the night?"
                }
            },
                        new Civilian
            {
                Id = 4,
                Name = "Nurse Jane",
                CurrentRegionLocationID = 3,
                Description = "A short, red hair, blues eyes nurse.",
                expPoints = 20,
                healing = 1,
                Messages = new List<string>
                {
                    "Your looking a litte rough, let me help!",
                    "Heres some health for you!",
                    "Hope you feel better!"
                }
            },
         new Civilian
            {
                Id = 5,
                Name = "Doc Watson",
                CurrentRegionLocationID = 7,
                Description = "A tall, slender man wearing a white lab coat.",
                expPoints = 20,
                healing = 1,
                Messages = new List<string>
                {
                    "I'm glad you talked to me, hope you feel better!",
                    "Heres some health for you!",
                    "Feeling sick, here let me help!"
                }
            },
                     new Civilian
            {
                Id = 6,
                Name = "Roy",
                CurrentRegionLocationID = 8,
                Description = "A rich looking man wearing a dark black suit.",
                expPoints = 20,
                healing = 0,
                Messages = new List<string>
                {
                    "My Name is Roy, I am the richest person in all of Dawson",
                    "Good luck finding gold!",
                }
            },




        };


    }
}
