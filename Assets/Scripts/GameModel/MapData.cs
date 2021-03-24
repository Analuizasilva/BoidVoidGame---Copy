using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameModel
{
    [System.Serializable]
    public class MapData
    {
        public TileData[] TileData;
    }
    [System.Serializable]
    public class TileData
    {

        public int PositionX;

        public int PositionY;

        public int PositionZ;
        public int Cost;

        public string Bonus;

        public string TileCapturedState;

        public string TileTypeName;

        public string TileTypeReference;

        public Team Team;

        public Superstructure SuperStructure;

        public Obstacle Obstacle;

        public PointOfImportance PointOfImportance;

        public Mothership Mothership;

        public Spaceship SpaceShip;

        public NPC Npc;
    }
}
