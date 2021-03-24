using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameModel
{
    [System.Serializable]
    public class Team
    {
        public Guid Id;
        public string Name;
        public Player[] Players;
    }


    [System.Serializable]
    public class Scoreboard
    {
        public Team[] Teams;
    }
}
