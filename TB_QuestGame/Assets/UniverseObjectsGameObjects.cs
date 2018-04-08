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
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 2,
                Name = "String",
                RegionLocationId = 1,
                Description = "A spool of some string, may be useful!",
                Type = ProspectorObjectType.Tool,
                Value = 2,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
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
                IsVisible = true
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
                IsVisible = true
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
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 7,
                Name = "String",
                RegionLocationId = 6,
                Description = "A spool of some string, may be useful!",
                Type = ProspectorObjectType.Tool,
                Value = 2,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },
             new ProspectorObject
            {
                Id = 8,
                Name = "String",
                RegionLocationId = 7,
                Description = "A spool of some string, may be useful!",
                Type = ProspectorObjectType.Tool,
                Value = 2,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
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
                IsVisible = true
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
                IsVisible = true
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
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 19,
                Name = "First Aid Kit",
                RegionLocationId = 5,
                Description = "An assortment of bandages, gauze, and some pain killers.",
                Type = ProspectorObjectType.Medicine,
                Value = 15,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 20,
                Name = "First Aid Kit",
                RegionLocationId = 8,
                Description = "An assortment of bandages, gauze, and some pain killers.",
                Type = ProspectorObjectType.Medicine,
                Value = 15,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 21,
                Name = "First Aid Kit",
                RegionLocationId = 6,
                Description = "An assortment of bandages, gauze, and some pain killers.",
                Type = ProspectorObjectType.Medicine,
                Value = 15,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },
            new ProspectorObject
            {
                Id = 22,
                Name = "Gold Coins",
                RegionLocationId = 1,
                Description = "Looks to be 10 gold coins! Worth 100!",
                Type = ProspectorObjectType.Treasure,
                Value = 100,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },








        };


    }
}
