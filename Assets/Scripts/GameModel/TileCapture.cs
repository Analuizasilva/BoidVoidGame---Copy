
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GameModel
{
    public class TileCapture : MonoBehaviour
    {

        public Guid Id { get; set; }
        public bool IsCaptured { get; set; }

        public Guid TileId { get; set; }
        public Tile Tile { get; set; }

        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}