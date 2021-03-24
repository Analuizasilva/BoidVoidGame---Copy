using Assets.Scripts.GameModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour
{
    public GameObject BaseTile;
    public GameObject HigherCostTile;
    public GameObject HighlightedTile;
    public GameObject SelectedTile;
    public GameObject CapturedTile;

    [HideInInspector]
    public bool isPressed;
    [HideInInspector]
    public bool isCaptured;
    [HideInInspector]
    public bool isVoid;
    [HideInInspector]
    public bool isOfHigherCost;
    [HideInInspector]
    public int CaptureState; 

    private void Awake()
    {
        BaseTile.SetActive(true);
        isPressed = false;
        HighlightedTile.SetActive(false);
        SelectedTile.SetActive(false);
        HigherCostTile.SetActive(false);
        CaptureState = 0;
        var tile = gameObject.GetComponent<Tile>();
        if (tile.TileCapturedState == null)
        {
            CapturedTile.SetActive(false);
        }
        else
        {
            //how are we going to get the current TileCapture?
            
        }
    }
    private void Update()
    {
        if (isOfHigherCost)
        {
            HigherCostTile.SetActive(true);
        }
        if (isVoid)
        {
            gameObject.SetActive(false);
        }
        if (isPressed)
        {
            SelectedTile.SetActive(true);
        }
        if (!isPressed)
        {
            SelectedTile.SetActive(false);
        }
        if (isCaptured)
        {
            CapturedTile.SetActive(true);
        }
        if (!isCaptured)
        {
            CapturedTile.SetActive(false);
        }
    }
    private void OnMouseOver()
    {
        HighlightedTile.SetActive(true);
    }
    private void OnMouseExit()
    {
        HighlightedTile.SetActive(false);
    }
    private void OnMouseDown()
    {
        SelectedTile.SetActive(true);
        isPressed = true;
    }

}
