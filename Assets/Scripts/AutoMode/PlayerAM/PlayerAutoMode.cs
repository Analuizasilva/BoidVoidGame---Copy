using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.AutoMode.PlayerAM
{
    [Serializable]
    public class PlayerAutoMode
    {
        public string Name { get; set; }
        public bool AutoModeState = false;
        public string PlayerTitle;
        public bool OnSwarm { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsViceCaptain { get; set; }
        //public int Index { get; set; }


        

    }
}
