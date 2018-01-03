using System.Collections;
using System.Collections.Generic;
using Models;
using Models.Quests;
using UnityEngine;
using UnityEngine.UI;

public class TurnHolderScript : MonoBehaviour {

	// List of players.
	public List<GameObject> players;

	// Indicates which index turn it is.
	public int turnIndex;

	// The displayed text
	public Text playerText;
	
	// Current Quest
	private Quest _currentQuest;

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
		playerText.text = players[turnIndex].name + "(" + players[turnIndex].GetComponent<GuildBehaviorScript>().gold + ")";
		_currentQuest = new SimpleQuest();
	}

	private void SetupRound()
	{
		turnIndex = 0;
		
		// Reward players with the current quest
		_currentQuest.RewardQuest(players);
		
		// Clear deployed units and increment max units
		foreach (var player in players)
		{
			var guild = player.GetComponent<GuildBehaviorScript>();
			guild.unitsDeployed = 0;
			guild.maxUnits++;
		}
	}

}
