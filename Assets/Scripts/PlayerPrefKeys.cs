using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerPrefKeys
{
    /* Total count of wins/loses/ties of single games */
    public const string TOTALWINS = "TotalWins";
    public const string TOTALLOSES = "TotalLoses";
    public const string TOTALTIES = "TotalTies";

    /* Total count of wins/loses/ties of sessions */
    public const string SESSIONWINS = "SessionWins";
    public const string SESSIONLOSES = "SessionLoses";
    public const string SESSIONTIES = "SessionTies";

    /* Count the number of times each weapon is used by the computer */
    public static string ComputerWeaponKey(string weapon)
    {
        return "Computer-" + weapon;
    }

    /* Count the number of times each weapon is used by the user */
    public static string PlayerWeaponKey(string weapon)
    {
        return "Player-" + weapon;
    }
}
