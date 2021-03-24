using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.GameModel
{
    [System.Serializable]
    public class Tile:MonoBehaviour
    {
        [HideInInspector]
        public int PositionX;

        [HideInInspector]
        public int PositionY;
        [HideInInspector]
        public int PositionZ;
        [HideInInspector]
        public int Cost;

        [HideInInspector]
        public string Bonus;
        [HideInInspector]
        public string TileCapturedState;
        [HideInInspector]
        public string TileTypeName;
        [HideInInspector]
        public string TileTypeReference;
        [HideInInspector]
        public Team Team;
        [HideInInspector]
        public Superstructure SuperStructure;
        [HideInInspector]
        public Obstacle Obstacle;
        [HideInInspector]
        public PointOfImportance PointOfImportance;
        [HideInInspector]
        public Mothership Mothership;
        [HideInInspector]
        public Spaceship SpaceShip;
        [HideInInspector]
        public NPC Npc;
        //[HideInInspector]
        //public Guid Id;
        //[HideInInspector]
        //public int XPosition;
        //[HideInInspector]
        //public int YPosition;
        //[HideInInspector]
        //public int ZPosition;
        //[HideInInspector]
        //public int Cost;
        //[HideInInspector]
        //public string Bonus;
        //[HideInInspector]
        //public string TileCapturedState;
        //[HideInInspector]
        //public string TileTypeName;
        //[HideInInspector]
        //public string TileTypeReference;


        //public Guid TileTypeId;
        //public TileType TileType;

        //public Guid PointOfImportanceId;
        //public PointOfImportance PointOfImportance;

        //public Guid SuperstructureId;
        //public Superstructure Superstructure;

        //public Guid ObstacleId;
        //public Obstacle Obstacle;

        //public ICollection<TileCapture> TileCaptures;

        //public Mothership Mothership;
        //public Spaceship SpaceShip;
        //public NPC Npc;

    }

}
