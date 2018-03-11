﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB_QuestGame;

namespace TB_QuestGame
{
    /// <summary>
    /// class of the game map
    /// </summary>
    public class Universe
    {
        #region ***** define all lists to be maintained by the Universe object *****
        //
        // list of all space-time locations 
        //
        private List<RegionLocation> _regionLocations;

        public List<RegionLocation> RegionLocations
        {
            get { return _regionLocations; }
            set { _regionLocations = value; }
        }


        #endregion

        #region ***** constructor *****

        //
        // default Universe constructor
        //
        public Universe()
        {
            //
            // add all of the universe objects to the game
            // 
            IntializeUniverse();
        }

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the universe with all of the space-time locations
        /// </summary>
        private void IntializeUniverse()
        {
            _regionLocations = UniverseObjects.RegionLocations;
        }

        #endregion

        #region ***** define methods to return game element objects and information *****

        /// <summary>
        /// determine if the Space-Time Location Id is valid
        /// </summary>
        /// <param name="spaceTimeLocationId">true if Space-Time Location exists</param>
        /// <returns></returns>
        public bool IsValidRegionLocationLocationId(int regionLocationID)
        {
            List<int> regionLocationIDs = new List<int>();

            //
            // create a list of space-time location ids
            //
            foreach (RegionLocation rl in _regionLocations)
            {
                regionLocationIDs.Add(rl.RegionLocationID);
            }

            //
            // determine if the space-time location id is a valid id and return the result
            //
            if (regionLocationIDs.Contains(regionLocationID))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        /// <summary>
        /// determine if a location is accessible to the player
        /// </summary>
        /// <param name="regionLocationID"></param>
        /// <returns>accessible</returns>
        public bool IsAccessibleLocation(int regionLocationID)
        {
            RegionLocation regionLocation = GetRegionLocationById(regionLocationID);
            if (regionLocation.Accessible == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// return the next available ID for a SpaceTimeLocation object
        /// </summary>
        /// <returns>next SpaceTimeLocationObjectID </returns>
        public int GetMaxRegionLocationId()
        {
            int MaxId = 0;

            foreach (RegionLocation regionLocations in RegionLocations)
            {
                if (regionLocations.RegionLocationID > MaxId)
                {
                    MaxId = regionLocations.RegionLocationID;
                }
            }

            return MaxId;
        }

        /// <summary>
        /// get a SpaceTimeLocation object using an Id
        /// </summary>
        /// <param name="Id">space-time location ID</param>
        /// <returns>requested space-time location</returns>
        public RegionLocation GetRegionLocationById(int Id)
        {
            RegionLocation regionLocation = null;

            //
            //run through the space-time location list and grab the correct one
            //
            foreach (RegionLocation location in _regionLocations)
            {
                if (location.RegionLocationID == Id)
                {
                    regionLocation = location;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //

            if (regionLocation == null)
            {
                string feedbackMessage = $"The Region Location ID {Id} does not exist in the" +
                    $"current Universe.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return regionLocation;
        }

        #endregion
    }
}