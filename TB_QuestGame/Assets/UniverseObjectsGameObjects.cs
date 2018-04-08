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
                RegionLocationId = 0,
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
                RegionLocationId = 2,
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
                RegionLocationId = 3,
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
                RegionLocationId = 2,
                Description = "A couple of oak logs.",
                Type = ProspectorObjectType.Wood,
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
            }






        };


    }
}
