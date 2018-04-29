using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class UniverseObjects
    {

        public static List<GameObject> gameObjects = new List<GameObject>()
        {

            new ProspectorObject
            {
                Id = 1,
                Name = "Shovel",
                RegionLocationId = 1,
                Description = "A rusty, well used shovel with a wooden handle.",
                Type = ProspectorObjectType.Tool,
                Value = 5,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 5,
                PickUpMessage = "You pick up a rusty shovel, hey, at least its free.",
                PutDownMessage = "You set down a rusty shovel. "
                
            },
            new ProspectorObject
            {
                Id = 2,
                Name = "String",
                RegionLocationId = 2,
                Description = "A spool of some string, may be useful!",
                Type = ProspectorObjectType.Tool,
                Value = 2,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 5
            },
            new ProspectorObject
            {
                Id = 3,
                Name = "Pick-Axe",
                RegionLocationId = 2,
                Description = "A tool used primarily for mining breaking down rocks.",
                Type = ProspectorObjectType.Tool,
                Value = 10,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 10
                
            },
            new ProspectorObject
            {
                Id = 4,
                Name = "Wood",
                RegionLocationId = 3,
                Description = "A couple of oak logs.",
                Type = ProspectorObjectType.Resource,
                Value = 5,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 15
                
            },
            new ProspectorObject
            {
                Id = 5,
                Name = "Musket",
                RegionLocationId = 4,
                Description = "A very trustworth and valuable weapon to have in the wilderness.",
                Type = ProspectorObjectType.Weapon,
                Value = 55,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 10
            },
            new ProspectorObject
            {
                Id = 6,
                Name = "Fur",
                RegionLocationId = 5,
                Description = "A heavy, lush piece of fur.",
                Type = ProspectorObjectType.Resource,
                Value = 15,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 10
            },
            new ProspectorObject
            {
                Id = 7,
                Name = "String",
                RegionLocationId = 6,
                Description = "A spool of some string, may be useful!",
                Type = ProspectorObjectType.Resource,
                Value = 2,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 5
                
            },
             new ProspectorObject
            {
                Id = 8,
                Name = "String",
                RegionLocationId = 7,
                Description = "A spool of some string, may be useful!",
                Type = ProspectorObjectType.Resource,
                Value = 2,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 5
            },
            new ProspectorObject
            {
                Id = 9,
                Name = "String",
                RegionLocationId = 8,
                Description = "A spool of some string, may be useful!",
                Type = ProspectorObjectType.Tool,
                Value = 2,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 5
                
            },

            new ProspectorObject
            {
                Id = 10,
                Name = "Fur",
                RegionLocationId = 9,
                Description = "A heavy, lush piece of fur.",
                Type = ProspectorObjectType.Resource,
                Value = 15,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExperiencePoints = 10
            },
            new ProspectorObject
            {
                Id = 11,
                Name = "Fur",
                RegionLocationId = 10,
                Description = "A heavy, lush piece of fur.",
                Type = ProspectorObjectType.Resource,
                Value = 15,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 10,
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 12,
                Name = "Hammer",
                RegionLocationId = 11,
                Description = "Useful for just about everything! A solid, steel hammer.",
                Type = ProspectorObjectType.Tool,
                Value = 25,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 5,
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 13,
                Name = "Hammer",
                RegionLocationId = 1,
                Description = "Useful for just about everything! A solid, steel hammer.",
                Type = ProspectorObjectType.Tool,
                Value = 25,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 5,
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 14,
                Name = "Hammer",
                RegionLocationId = 6,
                Description = "Useful for just about everything! A solid, steel hammer.",
                Type = ProspectorObjectType.Tool,
                Value = 25,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 5,
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 15,
                Name = "Pellet Rifle",
                RegionLocationId = 3,
                Description = "Great little rifle for shooting small game!",
                Type = ProspectorObjectType.Weapon,
                Value = 35,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 20,
                IsVisible = true
            },

            new ProspectorObject
            {
                Id = 16,
                Name = "Pellet Rifle",
                RegionLocationId = 9,
                Description = "Great little rifle for shooting small game!",
                Type = ProspectorObjectType.Weapon,
                Value = 35,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 20,
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 17,
                Name = "Shovel",
                RegionLocationId = 11,
                Description = "A rusty, well used shovel with a wooden handle.",
                Type = ProspectorObjectType.Tool,
                Value = 5,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 5,
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 18,
                Name = "Shovel",
                RegionLocationId = 8,
                Description = "A rusty, well used shovel with a wooden handle.",
                Type = ProspectorObjectType.Tool,
                Value = 5,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 5,
                IsVisible = true
            },

            new ProspectorObject
            {
                Id = 19,
                Name = "Shovel",
                RegionLocationId = 5,
                Description = "A rusty, well used shovel with a wooden handle.",
                Type = ProspectorObjectType.Tool,
                Value = 5,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 5,
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 20,
                Name = "FirstAidKit",
                RegionLocationId = 8,
                Description = "An assortment of bandages, gauze, and some pain killers.",
                Type = ProspectorObjectType.Medicine,
                Value = 15,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 10,
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 21,
                Name = "First Aid Kit",
                RegionLocationId = 1,
                Description = "An assortment of bandages, gauze, and some pain killers.",
                Type = ProspectorObjectType.Medicine,
                Value = 15,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 10,
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 22,
                Name = "Cough Medicine",
                RegionLocationId = 1,
                Description = "An small bottle of cough medicine. Looks to be expired.",
                Type = ProspectorObjectType.Medicine,
                Value = -15,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 10,
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 23,
                Name = "Gold Coins",
                RegionLocationId = 1,
                Description = "Looks to be 10 gold coins! Worth 100!",
                Type = ProspectorObjectType.Treasure,
                Value = 100,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 25,
                IsVisible = true,
                PickUpMessage = "You have added 100 gold coins to your wallet!!!"
                
            },
                new ProspectorObject
            {
                Id = 24,
                Name = "Message In A Bottle",
                RegionLocationId = 1,
                Description = "Looks to be a piece of paper in a bottle",
                Type = ProspectorObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 25,
                IsVisible = true,
                PickUpMessage = "The key to riches lies in klondike. HEAD NORTH NOW."
            },

              new ProspectorObject
            {
                Id = 25,
                Name = "Pain Killers",
                RegionLocationId = 7,
                Description = "Looks to be some white pain killers inside of a bottle",
                Type = ProspectorObjectType.Medicine,
                Value = 10,
                CanInventory = true,
                IsConsumable = true,
                ExperiencePoints = 25,
                IsVisible = true,
            },
             new ProspectorObject
            {
                Id = 26,
                Name = "Pain Killers",
                RegionLocationId = 9,
                Description = "Looks to be some white pain killers inside of a bottle. Expiration date is scratched off...",
                Type = ProspectorObjectType.Medicine,
                Value = -10,
                CanInventory = true,
                IsConsumable = true,
                ExperiencePoints = 25,
                IsVisible = true,
            },
                          new ProspectorObject
            {
                Id = 27,
                Name = "Pain Killers",
                RegionLocationId = 5,
                Description = "Looks to be some white pain killers inside of a bottle.",
                Type = ProspectorObjectType.Medicine,
                Value = 10,
                CanInventory = true,
                IsConsumable = true,
                ExperiencePoints = 25,
                IsVisible = true,
            },
            new ProspectorObject
            {
                Id = 28,
                Name = "Gold Coins",
                RegionLocationId = 3,
                Description = "Looks to be 5 gold coins! Worth 50!",
                Type = ProspectorObjectType.Treasure,
                Value = 50,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 25,
                IsVisible = true,
                PickUpMessage = "You have added 50 gold coins to your wallet!!!"

            },
             new ProspectorObject
            {
                Id = 29,
                Name = "Gold Coins",
                RegionLocationId = 5,
                Description = "Looks to be 10 gold coins! Worth 100!",
                Type = ProspectorObjectType.Treasure,
                Value = 100,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 25,
                IsVisible = true,
                PickUpMessage = "You have added 100 gold coins to your wallet!!!"

            },
            new ProspectorObject
            {
                Id = 30,
                Name = "Bread",
                RegionLocationId = 3,
                Description = "A loaf of bread.",
                Type = ProspectorObjectType.Food,
                Value = 15,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true,
                ExperiencePoints = 15

            },
            new ProspectorObject
            {
                Id = 31,
                Name = "Bread",
                RegionLocationId = 6,
                Description = "A loaf of bread.",
                Type = ProspectorObjectType.Food,
                Value = 15,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true,
                ExperiencePoints = 15

            },
           new ProspectorObject
            {
                Id = 32,
                Name = "Bread",
                RegionLocationId = 8,
                Description = "A loaf of bread.",
                Type = ProspectorObjectType.Food,
                Value = 15,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true,
                ExperiencePoints = 15

            },
                      new ProspectorObject
            {
                Id = 33,
                Name = "The Gold Mine",
                RegionLocationId = 9,
                Description = "You DID IT! Riches are yours!!!.",
                Type = ProspectorObjectType.Treasure,
                Value = 1000,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true,
                ExperiencePoints = 1000

            },
            new ProspectorObject
            {
                Id = 34,
                Name = "Cough Medicine",
                RegionLocationId = 4,
                Description = "An small bottle of cough medicine. Looks to be expired.",
                Type = ProspectorObjectType.Medicine,
                Value = 15,
                CanInventory = true,
                IsConsumable = false,
                ExperiencePoints = 10,
                IsVisible = true
            },





        };


    }
}
