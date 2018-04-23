﻿using System;
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
                Name = "Joe Johnson",
                CurrentRegionLocationID = 1,
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
                Id = 2,
                Name = "Brian Gold",
                CurrentRegionLocationID = 1,
                Description = "A rough looking man with a black coat and gray pants.",
                Messages = new List<string>
                {
                    "Have you heard about the gold rush?",
                    "Hello there, whats your name?",
                    "You look tired, want a place to stay for the night?"
                }
            },



        };


    }
}
