using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DefenderButton : MonoBehaviour
{

    [SerializeField] Defender defenderPrefab;


    private void Start()
    {
        SetStarCost();
    }

    private void SetStarCost()
    {
        Text starCost = GetComponentInChildren<Text>();

        if (!starCost)
        {
            Debug.LogError(name = " missing star cost");
        }
        else
        {
            starCost.text = defenderPrefab.GetStarCost().ToString();
        }


    }

    private void OnMouseDown()
    {

        var buttons = FindObjectsOfType<DefenderButton>();

        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(68, 68, 68, 255);

        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);

    }




}
