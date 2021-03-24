using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameModel
{
    [System.Serializable]
    public class Player:MonoBehaviour
    {
        public Guid Id;
        public string Name;
        public bool AutoModeState;
        public string Avatar;

        //public PlayerTitle PlayerTitle;

        public float Attack;
        public float Defense;
        public float BoidBattery;
        public int Respawns;
        public int ActionPoints;
    }
}
