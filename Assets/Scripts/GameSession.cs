﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    public static GameSession Instance { get; private set; }

    private CardManager cardManager;

    public ScrollRectSnap scrollRectSnap;

    private static WeaponData PlayerWeapon = null;
	private static WeaponData ComputerWeapon = null;

    public Text PlayerCardText;
    public Text ComputerCardText;

    public Text ReasonText;
    public Text StatusText;
    public Text ScoreText;

	private static int loses = 0;
	private static int wins = 0;
	private static int ties = 0;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        cardManager = CardManager.GetInstance();
        loses = wins = ties = 0;
        PlayerWeapon = ComputerWeapon = null;
    }

    public void SelectACardWithIndex(int cardIndex)
    {
        // Create weapons
        PlayerWeapon = cardManager.getWeaponObject(cardIndex);
        System.Random rand = new System.Random();
        int computerIndex = rand.Next(cardManager.numOfWeapons()-1);
        ComputerWeapon = cardManager.getWeaponObject(computerIndex);

        // TODO: Check who wins
        // TODO: Update counters

        SetPlayerCardText();
        SetComputerCardText();

        SetStatusString();
        SetReasonString();

        ResetScoreText();
    }

    private void SetPlayerCardText()
    {
        if(PlayerWeapon == null)
        {
            PlayerCardText.text = "UNKNOWN";
        }
        else
        {
            PlayerCardText.text = PlayerWeapon.weapon;
        }
    }

    private void SetComputerCardText()
    {
        if (ComputerWeapon == null)
        {
            ComputerCardText.text = "UNKNOWN";
        }
        else
        {
            ComputerCardText.text = ComputerWeapon.weapon;
        }
    }

    private void SetStatusString()
    {
        Status status = cardManager.GetGameStatus(PlayerWeapon, ComputerWeapon);

        if (status == Status.Win)
        {
            wins++;
            StatusText.text = "You Win!";
        }
        else if (status == Status.Lose)
        {
            loses++;
            StatusText.text = "You Lost!";
        }
        else
        {
            ties++;
            StatusText.text = "Tie Game!";
        }
    }

    private void SetReasonString()
    {
        ReasonText.text = cardManager.GetGameStatusReason(PlayerWeapon, ComputerWeapon);
    }

    private void ResetScoreText()
    {
        string sessionScore = "Wins - " + wins + " / Loses - " + loses;
        if(ties > 0)
        {
            sessionScore += " / Ties - " + ties;
        }
        ScoreText.text = sessionScore;
    }
}
