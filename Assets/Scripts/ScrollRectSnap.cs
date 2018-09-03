﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScrollRectSnap : MonoBehaviour {

    public RectTransform panel; // To hold the ScrollPanel
    public GameObject[] bttn;
    public RectTransform center; // Center to compare the distance for each button

    public float[] distance; // All button's distance to the center
    public float[] distReposition;
    private bool dragging = false; // Will be true while we drag panel
    private int bttnDistance; // Will hold the distance between the buttons
    private int minButtonNum; // To hold the number of the button with the smallest distance to center

    private const string weaponsListFileName = "weapons.json";
    private WeaponData[] weapons;

    public void Start()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, weaponsListFileName);
        if(File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            WeaponsData weaponData = WeaponsData.CreateFromJSON(dataAsJson);
            this.weapons = weaponData.weapons;
        }
        else
        {
            // TODO: Handle an error case here
            this.weapons = new WeaponData[0];
        }

        GameObject prefab = Resources.Load("Card") as GameObject;
        bttn = new GameObject[weapons.Length];
        for (int i = 0; i < weapons.Length; i++)
        {
            Card card = new Card();
            card.weaponName = weapons[i].weapon;
            card.description = weapons[i].description;
            card.artwork = Resources.Load<Sprite>("Sprites/Weapons/" + weapons[i].weapon);

            GameObject go = Instantiate(prefab) as GameObject;
            go.transform.position = new Vector2(i * 300f, 0);
            go.GetComponent<CardDisplay>().DefineCard(card);
            go.transform.SetParent(panel.transform, false);

            bttn[i] = go;
        }
       
        distance = new float[weapons.Length];
        distReposition = new float[weapons.Length];

        // Get distance between buttons
        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
    }

    public void Update()
    {
        float? minDistance = null;
        for (int i = 0; i < bttn.Length; i++)
        {
            distReposition[i] = center.GetComponent<RectTransform>().position.x - bttn[i].GetComponent<RectTransform>().position.x;
            distance[i] = Mathf.Abs(distReposition[i]);

            if(distReposition[i] > 1200)
            {
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

                Vector2 newAnchoredPos = new Vector2(curX + (bttn.Length * bttnDistance), curY);
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
            }

            if(distReposition[i] < -1200)
            {
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

                Vector2 newAnchoredPos = new Vector2(curX - (bttn.Length * bttnDistance), curY);
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
            }

            // Check if it's the minimal distance from center
            if (!minDistance.HasValue || distance[i] < minDistance)
            {
                minDistance = distance[i];
                minButtonNum = i;
            }
        }

        if (!dragging)
        {
            //LerpToBttn(minButtonNum * -bttnDistance);
            LerpToBttn(-bttn[minButtonNum].GetComponent<RectTransform>().anchoredPosition.x);
        }

    }

    private void LerpToBttn(float position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 10f);
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }
}