using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    StarDisplay starDisplay;

    GameObject defenderParent;
    const string DEFENDERS = "Defender";

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {

        defenderParent = GameObject.Find(DEFENDERS);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDERS);
        }

    }


    private void OnMouseDown()
    {
        PlaceDefenderAt(GetSquareClicked());
    }


    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    public void PlaceDefenderAt(Vector2 gridPos)
    {
        int defenderCost = defender.GetStarCost();

        if (starDisplay.haveEnoughStars(defenderCost))
        {
            starDisplay.SpendStars(defenderCost);
            SpawnDefender(gridPos);     
        }

    }



    private Vector2 GetSquareClicked()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        int newX = Mathf.RoundToInt(rawWorldPos.x);
        int newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 gridCoordinates)
    {
        Defender newDefender = Instantiate(defender, gridCoordinates, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    
    }
}
