using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnMenuTouch : MonoBehaviour {

	/*
	 *  Used for MainMenu scene
	 */
	public void OnNewGameButtonTouch () {
        SceneManager.LoadScene("Game");
	}

    public void OnSettingsButtonTouch(){
        // TODO: Implement function
    }

    public void OnHighscoreButtonTouch(){
        // TODO: Implement function
    }

    /*
     *  Used for Game scene
     */
    public void OnMainMenuButtonTouch()
    {
        GameSession.SaveSessionData();
        SceneManager.LoadScene("MainMenu");
    }
}
