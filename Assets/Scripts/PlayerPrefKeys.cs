using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerPrefKeys
{
    public const string TOTALWINS = "TotalWins";
    public const string TOTALLOSES = "TotalLoses";
    public const string TOTALTIES = "TotalTies";

    public const string SESSIONWINS = "SessionWins";
    public const string SESSIONLOSES = "SessionLoses";
    public const string SESSIONTIES = "SessionTies";

    public static string ComputerWeaponKey(string weapon)
    {
        return "Computer-" + weapon;
    }

    public static string PlayerWeaponKey(string weapon)
    {
        return "Player-" + weapon;
    }
}
