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

    // Use this for initialization
    void Start () {
        sessionWins.text = PlayerPrefs.GetInt(PlayerPrefKeys.SESSIONWINS).ToString();
        sessionLoses.text = PlayerPrefs.GetInt(PlayerPrefKeys.SESSIONLOSES).ToString();
        sessionTies.text = PlayerPrefs.GetInt(PlayerPrefKeys.SESSIONTIES).ToString();

        totalWins.text = PlayerPrefs.GetInt(PlayerPrefKeys.TOTALWINS).ToString();
        totalLoses.text = PlayerPrefs.GetInt(PlayerPrefKeys.TOTALLOSES).ToString();
        totalTies.text = PlayerPrefs.GetInt(PlayerPrefKeys.TOTALTIES).ToString();

        //sessionWins.text = PlayerPrefs.GetInt(PlayerPrefKeys.SESSIONWINS).ToString();
        //sessionWins.text = PlayerPrefs.GetInt(PlayerPrefKeys.SESSIONWINS).ToString();
    }
}
