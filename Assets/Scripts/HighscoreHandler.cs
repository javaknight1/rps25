using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreHandler : MonoBehaviour {

    public Text sessionWins;
    public Text sessionLoses;
    public Text sessionTies;

    public Text totalWins;
    public Text totalLoses;
    public Text totalTies;

    public Text topComputerWeapon;
    public Text topUserWeapon;

    void Start()
    {
        UpdateScores();
    }

    void Update()
    {
        UpdateScores();
    }

    // Use this for initialization
    void UpdateScores () {

        sessionWins.text = GetIfAvailable(PlayerPrefKeys.SESSIONWINS).ToString();
        sessionLoses.text = GetIfAvailable(PlayerPrefKeys.SESSIONLOSES).ToString();
        sessionTies.text = GetIfAvailable(PlayerPrefKeys.SESSIONTIES).ToString();

        totalWins.text = GetIfAvailable(PlayerPrefKeys.TOTALWINS).ToString();
        totalLoses.text = GetIfAvailable(PlayerPrefKeys.TOTALLOSES).ToString();
        totalTies.text = GetIfAvailable(PlayerPrefKeys.TOTALTIES).ToString();

        WeaponData topUserWeaponData = null;
        foreach (WeaponData weapon in CardManager.GetInstance().weapons)
        {
            if(topUserWeaponData == null)
            {
                topUserWeaponData = weapon;
                continue;
            }

            int maxWeaponCount = GetIfAvailable(PlayerPrefKeys.PlayerWeaponKey(topUserWeaponData.weapon));
            int currentWeaponCount = GetIfAvailable(PlayerPrefKeys.PlayerWeaponKey(weapon.weapon));
            if (currentWeaponCount > maxWeaponCount)
            {
                topUserWeaponData = weapon;
            }
        }
        if (GetIfAvailable(PlayerPrefKeys.PlayerWeaponKey(topUserWeaponData.weapon)) > 0)
        {
            topUserWeapon.text = topUserWeaponData.weapon + " (" + GetIfAvailable(PlayerPrefKeys.PlayerWeaponKey(topUserWeaponData.weapon)) + ")";

        }
        else
        {
            topUserWeapon.text = "N/A";
        }

        WeaponData topComputerWeaponData = null;
        foreach (WeaponData weapon in CardManager.GetInstance().weapons)
        {
            if (topComputerWeaponData == null)
            {
                topComputerWeaponData = weapon;
                continue;
            }

            int maxWeaponCount = GetIfAvailable(PlayerPrefKeys.ComputerWeaponKey(topComputerWeaponData.weapon));
            int currentWeaponCount = GetIfAvailable(PlayerPrefKeys.ComputerWeaponKey(weapon.weapon));
            if (currentWeaponCount > maxWeaponCount)
            {
                topComputerWeaponData = weapon;
            }
        }
        if(GetIfAvailable(PlayerPrefKeys.ComputerWeaponKey(topComputerWeaponData.weapon)) > 0)
        {
            topComputerWeapon.text = topComputerWeaponData.weapon + " (" + GetIfAvailable(PlayerPrefKeys.ComputerWeaponKey(topComputerWeaponData.weapon)) + ")";
        }
        else
        {
            topComputerWeapon.text = "N/A";
        }
    }

    private int GetIfAvailable(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);
        }
        else
        {
            return 0;
        }
    }
}
