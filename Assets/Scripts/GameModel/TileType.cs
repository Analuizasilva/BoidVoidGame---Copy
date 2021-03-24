using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GameModel
{
    [System.Serializable]
    public class TileType
    {
        public Guid TypeOfTileId { get; set; }
        public string Name { get; set; } = "Name";
        public string Reference { get; set; }
        public string Bonus { get; set; }
    }
}