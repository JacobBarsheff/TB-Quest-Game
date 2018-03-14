using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// class for the game map locations
    /// </summary>
    public class RegionLocation
    {
        #region FIELDS

        private string _commonName;
        private int _regionLocationID; // must be a unique value for each object
        private int _universalDate;
        private string _universalLocation;
        private string _description;
        private string _generalContents;
        private bool _accessable;
        private int _pointsToEnter;
        private int _experiencePoints;
        private List<int> _canTravelToNext;
        private int _postionLeft;
        private int _positonTop;

        public int PositionTop
        {
            get { return _positonTop; }
            set { _positonTop = value; }
        }

        public int PositonLeft
        {
            get { return _postionLeft; }
            set { _postionLeft = value; }
        }





        #endregion


        #region PROPERTIES

        public List<int> CanTravelToNext
        {
            get { return _canTravelToNext; }
            set { _canTravelToNext = value; }
        }


        public string CommonName
        {
            get { return _commonName; }
            set { _commonName = value; }
        }

        public int RegionLocationID
        {
            get { return _regionLocationID; }
            set { _regionLocationID = value; }
        }

        public int UniversalDate
        {
            get { return _universalDate; }
            set { _universalDate = value; }
        }

        public string UniversalLocation
        {
            get { return _universalLocation; }
            set { _universalLocation = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string GeneralContents
        {
            get { return _generalContents; }
            set { _generalContents = value; }
        }

        public bool Accessible
        {
            get { return _accessable; }
            set { _accessable = value; }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }
        public int PointsToEnter
        {
            get { return _pointsToEnter; }
            set { _pointsToEnter = value; }
        }

        #endregion


        #region CONSTRUCTORS



        #endregion


        #region METHODS



        #endregion


    }
}
