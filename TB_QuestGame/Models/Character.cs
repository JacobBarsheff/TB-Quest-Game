using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum Title
        {
            None,
            Sir,
            Mr,
            Miss,
            Mrs
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _age;
        private Title _title;
        private bool _hasFishedHunted;
        private int _currentRegionLocationID;






        #endregion

        #region PROPERTIES

        public int CurrentRegionLocationID
        {
            get { return _currentRegionLocationID; }
            set { _currentRegionLocationID = value; }
        }



        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public Title title
        {
            get { return _title; }
            set { _title = value; }
        }

        public bool HasFishedHunted
        {
            get { return _hasFishedHunted; }
            set { _hasFishedHunted = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, Title title)
        {
            _name = name;
            _title = title;
        }

        #endregion

        #region METHODS

        public virtual string Greeting()
        {
            return $"Hello, my name is {_title} {_name}.";
        }

        #endregion
    }
}
