
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Scripts.GameModel;
using System.Linq;
using System.Threading;
using BlockBase.BoidGame.BoidVoidGame.Assets.Scripts;

public class TileMap : MonoBehaviour
{
    [HideInInspector]
    public GameObject CurrentTile;
    public Text TimeTurner;
    public GameObject SidePanel;
    public Slider SidePanelSlider;
    public GameObject TileObjectPrefab;
    public GameObject PlayerPrefab;
    private GameObject Player;
    int[,] tiles;
    public int MapSizeX;
    public int MapSizeY;
    private List<GameObject> allTiles;


    void Awake()
    {
        tiles = new int[MapSizeX, MapSizeY];

        GenerateMapVisual();
        GeneratePlayer();

    }
    void GeneratePlayer()
    {
        var content = GameObject.FindGameObjectWithTag("PlayersContent");
        var tile = GameObject.FindGameObjectWithTag("0,0");
        Player = Instantiate(PlayerPrefab, tile.transform.position, Quaternion.identity, content.transform);
        tile.GetComponent<DisplayUI>().isPressed = true;

    }
    void GenerateMapVisual()
    {
        #region Randoms
        //System.Random randNumberOneX = new System.Random();
        //System.Random randNumberOneY = new System.Random();

        //System.Random randNumberTwoX = new System.Random();
        //System.Random randNumberTwoY = new System.Random();

        //System.Random randNumberThreeX = new System.Random();
        //System.Random randNumberThreeY = new System.Random();

        //int voidX = randNumberOneX.Next(1, MapSizeX - 1);
        //int voidY = randNumberOneY.Next(1, MapSizeY - 2);
        //int void2X = randNumberTwoX.Next(1, MapSizeX - 3);
        //int void2Y = randNumberTwoY.Next(1, MapSizeY - 4);
        //int void3X = randNumberThreeX.Next(1, MapSizeX - 4);
        //int void3Y = randNumberThreeY.Next(1, MapSizeY - 2);

        //Map cannot be smaller than 5x5
        #endregion

        var numberOfTiles = MapSizeX * MapSizeY;

        allTiles = new List<GameObject>();

        for (var x = 0; x < MapSizeX; x++)
        {
            for (var y = 0; y < MapSizeY; y++)
            {
                var tiles = GameObject.FindGameObjectWithTag("Tiles");

                var prefab = Instantiate(TileObjectPrefab, tiles.transform);
                if (x == 0 && y == 0) prefab.tag = $"{x},{y}";

                allTiles.Add(prefab);

                prefab.GetComponent<Button>().onClick.AddListener(delegate
                {
                    CurrentTile = prefab;
                    OpenSidePanel();


                });

                var prefabRectTransform = prefab.GetComponent<RectTransform>();
                if (y % 2 == 0)
                {
                    prefabRectTransform.anchoredPosition3D = new Vector3(x * 60 + 30, y * 45, 0);
                }
                else
                {
                    prefabRectTransform.anchoredPosition3D = new Vector3(x * 60, y * 45, 0);
                }

                var tileProperty = prefab.GetComponent<Tile>();
                tileProperty.PositionX = x;
                tileProperty.PositionY = y;

                #region VoidTiles
                //if (numberOfTiles <= 25)
                //{
                //    if (x == voidX && y == voidY) prefab.GetComponent<DisplayUI>().isVoid = true;
                //}
                //else if (numberOfTiles > 25 && numberOfTiles <= 100)
                //{
                //    if (x == voidX && y == voidY) prefab.GetComponent<DisplayUI>().isVoid = true;
                //    if (x == void2X && y == void2Y) prefab.GetComponent<DisplayUI>().isVoid = true;
                //}
                //else
                //{
                //    if (x == voidX && y == voidY) prefab.GetComponent<DisplayUI>().isVoid = true;
                //    if (x == void2X && y == void2Y) prefab.GetComponent<DisplayUI>().isVoid = true;
                //    if (x == void3X && y == void3Y) prefab.GetComponent<DisplayUI>().isVoid = true;
                //}
                #endregion
            }
        }
        var moveButton = SidePanel.GetComponentsInChildren<Button>().Where(x => x.name == "MoveButton").SingleOrDefault();
        moveButton.onClick.AddListener(delegate
        {
            MovePlayer();

        });
        var captureButton = SidePanel.GetComponentsInChildren<Button>().Where(x => x.name == "CaptureCellButton").SingleOrDefault();

        captureButton.onClick.AddListener(delegate
        {
            CaptureCell();
        });

    }
    void GenerateTileBarrier()
    {
        var tileHeight = TileObjectPrefab.GetComponent<RectTransform>().sizeDelta.y - 15;
        var tileWidth = TileObjectPrefab.GetComponent<RectTransform>().sizeDelta.x;

        var content = GameObject.FindGameObjectWithTag("Content");


        var rectContent = content.GetComponent<RectTransform>();

        var yMax = rectContent.anchorMin.y;
        var xMax = rectContent.anchorMin.x;

        var yMin = yMax - (MapSizeY * tileHeight);
        var xMin = xMax - (MapSizeX * tileWidth);

        if (rectContent.anchoredPosition3D.x < xMin)
        {
            rectContent.anchoredPosition3D = new Vector3(xMin, rectContent.anchoredPosition3D.y, rectContent.anchoredPosition3D.z);
        }
        if (rectContent.anchoredPosition3D.x > xMax)
        {
            rectContent.anchoredPosition3D = new Vector3(xMax, rectContent.anchoredPosition3D.y, rectContent.anchoredPosition3D.z);
        }
        if (rectContent.anchoredPosition3D.y < yMin)
        {
            rectContent.anchoredPosition3D = new Vector3(rectContent.anchoredPosition3D.x, yMin, rectContent.anchoredPosition3D.z);
        }
        if (rectContent.anchoredPosition3D.y > yMax)
        {
            rectContent.anchoredPosition3D = new Vector3(rectContent.anchoredPosition3D.x, yMax, rectContent.anchoredPosition3D.z);
        }
    }

    void OpenSidePanel()
    {
        SidePanel.SetActive(true);

        var sidePanelComponents = SidePanel.GetComponentsInChildren<Text>();
        var tileProps = CurrentTile.GetComponent<Tile>();

        SidePanelSlider.value = 0;
        SidePanelSlider.gameObject.SetActive(false);
        if (tileProps.TileCapturedState == "1")
        {
            SidePanelSlider.gameObject.SetActive(true);
            SidePanelSlider.value = 1;
        }
        if (tileProps.TileCapturedState == "2")
        {
            SidePanelSlider.gameObject.SetActive(true);
            SidePanelSlider.value = 2;
        }
        foreach (var component in sidePanelComponents)
        {
            if (component.name == "Position") component.text = $"Position: {tileProps.PositionX} , {tileProps.PositionY}";
        }
    }
    public void CenterBoard()
    {
        var content = GameObject.FindGameObjectWithTag("Content");
        var rectT = content.GetComponent<RectTransform>();
        rectT.anchoredPosition3D = new Vector3(0, 0, 0);
    }
    public void MovePlayer()
    {
        foreach (var tile in allTiles)
        {
            var displayUI = tile.GetComponent<DisplayUI>();
            if (displayUI.isPressed) displayUI.isPressed = false;
        }
        var actionPoints = Player.GetComponent<Player>().ActionPoints;
        var cost = CurrentTile.GetComponent<Tile>().Cost;
        if (actionPoints >= cost)
        {
            Player.transform.position = CurrentTile.transform.position;
            CurrentTile.GetComponent<DisplayUI>().isPressed = true;
            var difference = actionPoints - cost;
            Player.GetComponent<Player>().ActionPoints = difference;
        }

    }
    void CaptureCell()
    {
        if (CurrentTile.transform.position.ToString() == Player.transform.position.ToString())
        {

            var tileProps = CurrentTile.GetComponent<Tile>();
            var sidePanelComponents = SidePanel.GetComponentsInChildren<Text>();
            SidePanelSlider.gameObject.SetActive(true);
            var sidePanelSlider = SidePanel.GetComponentInChildren<Slider>();
            var positionInPanel = sidePanelComponents.Where(x => x.name == "Position").SingleOrDefault().text;

            var sliderValue = sidePanelSlider.value;
            if (sliderValue == 0)
            {
                sidePanelSlider.value = sidePanelSlider.value + 1;
            }

        }

    }

    void LimitArea()
    {
        var tileHeight = TileObjectPrefab.GetComponent<RectTransform>().sizeDelta.y - 15;
        var tileWidth = TileObjectPrefab.GetComponent<RectTransform>().sizeDelta.x;

        var content = GameObject.FindGameObjectWithTag("Content");
        var rectT = content.GetComponent<RectTransform>();
        var tiles = GameObject.FindGameObjectWithTag("Tiles").GetComponentsInChildren<RectTransform>();

        var yBorderLimitMax = rectT.anchorMin.y;
        var xBorderLimitMax = rectT.anchorMin.x;

        var yBorderLimitMin = yBorderLimitMax - (MapSizeY * tileHeight);
        var xBorderLimitMin = xBorderLimitMax - (MapSizeX * tileWidth);

        var firstTile = tiles[0];
        xBorderLimitMin = firstTile.anchoredPosition.x;
        xBorderLimitMax = firstTile.anchoredPosition.x;

        yBorderLimitMin = firstTile.anchoredPosition.y;
        yBorderLimitMax = firstTile.anchoredPosition.y;


        foreach (var tile in tiles)
        {
            if (tile.anchoredPosition.x <= xBorderLimitMin)
            {
                xBorderLimitMin = tile.anchoredPosition.x;
            }

            if (tile.anchoredPosition.y <= yBorderLimitMin)
            {
                yBorderLimitMin = tile.anchoredPosition.y;
            }

            if (tile.anchoredPosition.x >= xBorderLimitMax)
            {
                xBorderLimitMax = tile.anchoredPosition.x;
            }

            if (tile.anchoredPosition.y >= yBorderLimitMax)
            {
                yBorderLimitMax = tile.anchoredPosition.y;
            }
        }

        xBorderLimitMax *= 3;
        yBorderLimitMax *= 3;
        var vectorMax = new Vector3(xBorderLimitMax, yBorderLimitMax, 0);
        var vectorMin = new Vector3(xBorderLimitMin, yBorderLimitMin, 0);    


        var eixoX = Mathf.Clamp(rectT.anchoredPosition.x, vectorMin.x, vectorMax.x);
        var eixoY = Mathf.Clamp(rectT.anchoredPosition.y, vectorMin.y, vectorMax.y);

        rectT.anchoredPosition = new Vector3(eixoX, eixoY, rectT.transform.position.z);
    }


    private void Update()
    {
        LimitArea();
        var sidePanelComponents = SidePanel.GetComponentsInChildren<Text>();
        var positionInPanel = sidePanelComponents.Where(x => x.name == "Position").SingleOrDefault().text;
        var playerActionPoints = Player.GetComponent<Player>().ActionPoints;

        for (var t = 0; t < allTiles.Count; t++)
        {
            var playerPosition = Player.transform.position;
            var displayUI = allTiles[t].GetComponent<DisplayUI>();
            var tileProps = allTiles[t].GetComponent<Tile>();
            var cost = tileProps.Cost;

            if (tileProps.Cost == 2)
            {
                displayUI.isOfHigherCost = true;
            }

            if (SidePanelSlider.value > 0)
            {
                var turn = TimeTurner;

                if (turn.text == "00:00")
                {

                    SidePanelSlider.value += 1;

                    if (SidePanelSlider.value == 3)
                    {
                        if (positionInPanel == $"Position: {tileProps.PositionX} , {tileProps.PositionY}")
                        {
                            allTiles[t].GetComponent<DisplayUI>().isCaptured = true;
                            SidePanelSlider.gameObject.SetActive(false);
                        }
                    }
                }

            }

            if (allTiles[t].transform.position.ToString() == playerPosition.ToString()) displayUI.isPressed = true;
            else
            {
                if (positionInPanel == $"Position: {tileProps.PositionX} , {tileProps.PositionY}")
                {
                    displayUI.isPressed = true;
                }
                else
                {
                    displayUI.isPressed = false;
                }
            }
        }

    }
}