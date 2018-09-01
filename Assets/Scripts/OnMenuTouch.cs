using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnMenuTouch : MonoBehaviour {

	// Use this for initialization
	public void OnNewGameButtonTouch () {
        SceneManager.LoadScene("Game");
	}

    public void OnSettingsButtonTouch(){
        // TODO: Implement function
    }

    public void OnHighscoreButtonTouch(){
        // TODO: Implement function
    }
		
}
