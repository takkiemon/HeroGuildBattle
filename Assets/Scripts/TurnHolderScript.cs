using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnHolderScript : MonoBehaviour {

	// List of players.
	public List<GameObject> players;

	// Indicates which index turn it is.
	public int turnIndex;

	// The displayed text
	public Text playerText;

	// Use this for initialization
	void Start () {
		SetupTurn();
	}

	// Update is called once per frame
	void Update () {
		
	}

	// Moves the turnIndex to the next player and returns that player
	public void NextTurn ()
	{
		turnIndex++;
		if (turnIndex >= players.Count){
			SetupRound();
		}
		SetupTurn();
	}

	public GameObject GetCurrentPlayer()
	{
		return players[turnIndex];
	}

	private void SetupTurn (){
		playerText.text = players[turnIndex].name;
	}

	private void SetupRound()
	{
		turnIndex = 0;
		foreach (var player in players)
		{
			var guild = player.GetComponent<GuildBehaviorScript>();
			guild.unitsDeployed = 0;
			guild.maxUnits++;
		}
	}

}
