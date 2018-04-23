using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class ProspectorObject : GameObject
    {

        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        //public override int RegionLocationId { get; set; }
       // public TravelerObjectType Type { get; set; }
        public ProspectorObjectType Type { get; set; }
        public bool CanInventory { get; set; }
        public bool IsConsumable { get; set; }
        public bool IsVisible { get; set; }
        public int Value { get; set; }
        public int ExperiencePoints { get; set; }
        public string PickUpMessage { get; set; }
        public string PutDownMessage { get; set; }

        private int _regionLocation;

        //
        // raise event when an object is added or removed from the inventory
        //
        public override int RegionLocationId {
            get
            {
                return _regionLocation;
            }
            set
            {
                _regionLocation = value;
                if (value == 0)
                {
                    onObjectAddedToInventory();
                }

            }
        }
        


        public event EventHandler objectAddedToInventory;

        public void onObjectAddedToInventory()
        {
            if (objectAddedToInventory != null)
            {
                objectAddedToInventory(this, EventArgs.Empty);
            }
            
        }



    }
}
