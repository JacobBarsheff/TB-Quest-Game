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
        private int _prospectorHealth = 35;
        private bool _knowsAboutKlondike;
        private string _prospectorAddress;

        #endregion

        #region PROPERTIES
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

        #endregion

        #region CONSTRUCTORS

        public Prospector()
        {

        }

        public Prospector(string name, Title title) : base(name, title)
        {

        }

        #endregion

        #region METHODS
        public override string Greeting()
        {
            return $"Hello, my name is {base.title} {base.Name}.\n" +
                $"I am in {_propspectorHealthStatus} health. I live at {_prospectorAddress}.";
        }


        #endregion
    }
}
