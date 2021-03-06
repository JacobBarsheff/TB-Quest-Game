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
        private List<GameObject> _gameObjects;
        private List<Npc> _npcs;


        public List<Npc> Npcs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }

        public List<RegionLocation> RegionLocations
        {
            get { return _regionLocations; }
            set { _regionLocations = value; }
        }
        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
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
            _gameObjects = UniverseObjects.gameObjects;
            _npcs = UniverseObjects.Npcs;
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


            public bool IsValidGameObjectByLocationId(int gameObjectId, int currentRegionLocation)
            {
                List<int> gameObjectIds = new List<int>();

                //
                // create a list of game object ids in current space-time location
                //

                foreach (GameObject gameObject in _gameObjects)
                {
                    if (gameObject.RegionLocationId == currentRegionLocation)
                    {
                        gameObjectIds.Add(gameObject.Id);
                    }
                }

                //
                // determine if the game object id is a valid id and returnt the result
                //
                if (gameObjectIds.Contains(gameObjectId))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            public GameObject GetGameObjectById(int Id)
            {

                GameObject gameObjectToReturn = null;

                //
                // run through the game object list and grab the correct one
                //
                foreach (GameObject gameObject in _gameObjects)
                {
                    if (gameObject.Id == Id)
                    {
                        gameObjectToReturn = gameObject;
                    }
                }
                //
                //the specified ID was not found in the universe
                //throw exception
                //
                if (gameObjectToReturn == null)
                {
                    string feedbackMessage = $"The Game Object ID {Id} does not exist in the current Universe.";
                    throw new ArgumentException(feedbackMessage, Id.ToString());
                }
                return gameObjectToReturn;
            }
            
            public List<GameObject> GetGameObjectsByRegionLocationId(int regionLocationId)
            {
                List<GameObject> gameObjects = new List<GameObject>();

                //
                //run through the game object list and grab all thatbare in the current region-location
                //

                foreach (GameObject gameObject in _gameObjects)
                {
                    if (gameObject.RegionLocationId == regionLocationId)
                    {
                        gameObjects.Add(gameObject);
                    }
                }

                return gameObjects;
            }
        public bool IsValidTravelerObjectByLocationId(int travelerObjectId, int currentRegionLocation)
        {
            List<int> travelerObjectIds = new List<int>();

            //
            // create a list of traveler object ids in current space-time location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.RegionLocationId == currentRegionLocation && gameObject is ProspectorObject)
                {
                    travelerObjectIds.Add(gameObject.Id);
                }

            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (travelerObjectIds.Contains(travelerObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<ProspectorObject> GetTravelerObjectsBySpaceTimeLocationId(int spaceTimeLocationId)
        {
            List<ProspectorObject> travelerObjects = new List<ProspectorObject>();

            //
            // run through the game object list and grab all that are in the current space-time location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.RegionLocationId == spaceTimeLocationId && gameObject is ProspectorObject)
                {
                    travelerObjects.Add(gameObject as ProspectorObject);
                }
            }

            return travelerObjects;
        }

        public bool IsValidNpcByLocation(int npcId, int currentRegionLocation)
        {
            List<int> npcIds = new List<int>();

            foreach (Npc npc in _npcs)
            {
                if(npc.CurrentRegionLocationID == currentRegionLocation)
                {
                    npcIds.Add(npc.Id);
                }
            }

            if (npcIds.Contains(npcId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Npc GetNpcById( int Id)
        {
            Npc npcToReturn = null;


            foreach (Npc npc in _npcs)
            {
                if (npc.Id == Id)
                {
                    npcToReturn = npc;
                }
            }

            if(npcToReturn == null)
            {
                string feedBackMessage = $"The NPC ID {Id} does not exist :(";
                throw new ArgumentException(feedBackMessage, Id.ToString());
            }

            return npcToReturn;
        }

        public List<Npc> GetNpcsByRegionLocationId(int regionLocation)
        {
            List<Npc> npcs = new List<Npc>();


            foreach (Npc npc in _npcs)
            {
                if(npc.CurrentRegionLocationID == regionLocation)
                {
                    npcs.Add(npc);
                }
            }

            return npcs;

        }

        #endregion
    }
}
