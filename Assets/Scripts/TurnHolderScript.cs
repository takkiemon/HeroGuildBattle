using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHolderScript : MonoBehaviour {

	// List of players.
	public List<GameObject> players;

	// Indicates which index turn it is.
	public int turnIndex;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	// Moves the turnIndex to the next player and returns that player
	public GameObject nextTurn()
	{
		turnIndex++;
		if (turnIndex >= players.Count){
			turnIndex = 0;
		}
		return players[turnIndex];
	}
}
