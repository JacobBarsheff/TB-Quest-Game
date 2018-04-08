using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Prospector : Character
    {
        #region ENUMERABLES
        public enum overallHealth
        {
            None,
            Poor,
            Average,
            AboveAverage
        }

        #endregion

        #region FIELDS
        private overallHealth _propspectorHealthStatus;
        private int _prospectorHealth  = 100;
        private bool _knowsAboutKlondike;
        private string _prospectorAddress;
        private List<int> _regionLocationsVisited;
        private int _expPoints;
        private List<ProspectorObject> _inventory;
        private int _money = 100;

        #endregion

        #region PROPERTIES
        public int ExpPoints
        {
            get { return _expPoints; }
            set { _expPoints = value; }
        }

        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }


        public int ProspectorHealth
        {
            get { return _prospectorHealth; }
            set { _prospectorHealth = value; }
        }

        public bool PriorKnowledge
        {
            get { return _knowsAboutKlondike; }
            set { _knowsAboutKlondike = value; }
        }
        public overallHealth PlayerHealthStatus
        {
            get { return _propspectorHealthStatus; }
            set { _propspectorHealthStatus = value; }
        }
        public string ProspectorAddress
        {
            get { return _prospectorAddress; }
            set { _prospectorAddress = value; }
        }

        public List<int> RegionLocationsVisited
        {
            get { return _regionLocationsVisited; }
            set { _regionLocationsVisited = value; }
        }
       public List<ProspectorObject> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public Prospector()
        {
            _regionLocationsVisited = new List<int>();
            _inventory = new List<ProspectorObject>();
        }

        public Prospector(string name, Title title, int regionLocationID) : base(name, title)
        {
            _regionLocationsVisited = new List<int>();
            _inventory = new List<ProspectorObject>();
        }

        #endregion

        #region METHODS
        public override string Greeting()
        {
            return $"Hello, my name is {base.title} {base.Name}.\n" +
                $"I am in {_propspectorHealthStatus} health. I live at {_prospectorAddress}.";
        }

        public bool hasVisited(int _regionLocationId)
        {
            if (RegionLocationsVisited.Contains(_regionLocationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
