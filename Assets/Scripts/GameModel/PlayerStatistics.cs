using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameModel
{
    [System.Serializable]
    public class PlayerStatistics
    {
        public int FightsWon;

        public int FightsLost;

        public int FieldsCaptured;

        public int Respawns;
    }
}
