using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

	public Card pc;
	public Card user;

	private int loses = 0;
	private int wins = 0;
	private int ties = 0;

	public void selectedCard(Card pc)
    {
		// TODO: Check who wins and add to counter
	}
}
