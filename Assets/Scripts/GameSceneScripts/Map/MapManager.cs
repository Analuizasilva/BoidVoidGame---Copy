using Assets.Scripts.GameModel;
using BlockBase.BoidGame.BoidVoidGame.Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Assets.Scripts.GameSceneScripts.Map
{
    public class MapManager : MonoBehaviour
    {

        [SerializeField]
        public GameObject SidePanel;
        private MapData map;


        void Update()
        {
            StartCoroutine(
                Requester.Get("http://localhost:62448/api/map", (error, data) =>
                { LoadData(error, data); })
                );
        }

        private void LoadData(string error, byte[] data)
        {
            if (!string.IsNullOrEmpty(error))
            {
                Debug.LogError(error);
            }
            else
            {
                var requestResult = System.Text.Encoding.Default.GetString(data);
                map = new MapData() { TileData = JsonHelper.GetJsonArray<TileData>(requestResult, "Tiles") };

                var allTiles = GameObject.FindGameObjectWithTag("Tiles");
                var allTilesComponent = allTiles.GetComponentsInChildren<Tile>();

                if (map.TileData != null)
                {
                    for (var i = 0; i < allTilesComponent.Length; i++)
                    {
                        for (var j = 0; j < map.TileData.Length; j++)
                        {
                            var tileProps = allTilesComponent[i];
                            var posX = map.TileData[j].PositionX;
                            var posY = map.TileData[j].PositionY;


                            var tileCaptureState = map.TileData[j].TileCapturedState;
                            var sidePanelComponents = SidePanel.GetComponentsInChildren<Text>();
                            var text = sidePanelComponents.Where(x => x.name == "Position").SingleOrDefault().text;
                            if (text == $"Position: {posX} , {posY}")
                            {
                                sidePanelComponents.Where(x => x.name == "Owner").SingleOrDefault().text = tileCaptureState;
                                sidePanelComponents.Where(x => x.name == "Cost").SingleOrDefault().text = map.TileData[j].Cost.ToString();
                            }

                            if (tileProps.PositionX == posX && tileProps.PositionY == posY)
                            {
                                tileProps.Cost = map.TileData[j].Cost;
                                tileProps.Bonus = map.TileData[j].Bonus;
                                tileProps.TileCapturedState = map.TileData[j].TileCapturedState;
                                tileProps.TileTypeName = map.TileData[j].TileTypeName;
                                tileProps.TileTypeReference = map.TileData[j].TileTypeReference;
                                tileProps.Team = map.TileData[j].Team;
                                tileProps.SuperStructure = map.TileData[j].SuperStructure;
                                tileProps.Obstacle = map.TileData[j].Obstacle;
                                tileProps.PointOfImportance = map.TileData[j].PointOfImportance;
                                tileProps.Mothership = map.TileData[j].Mothership;
                                tileProps.SpaceShip = map.TileData[j].SpaceShip;
                                tileProps.Npc = map.TileData[j].Npc;
                            }
                        }

                    }
                }
            }
        }
    }
}