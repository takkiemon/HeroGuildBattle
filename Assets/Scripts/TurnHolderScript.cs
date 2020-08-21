using System.Collections;
using System.Collections.Generic;
using Models;
using Models.Quests;
using UnityEngine;
using UnityEngine.UI;

public class TurnHolderScript : MonoBehaviour
{
    // List of players.
    public List<GuildBehaviorScript> players;

    // Indicates which index turn it is.
    public int turnIndex;

    // Indicates which Phase it is
    public Phase phase;

    // The displayed text
    public Text playerText;

    // The displayed text
    public Text MoneyAmount;

    // Players deploy buttons
    public List<GameObject> playerButtons;

    // Current Quest
    private Quest _currentQuest;

    public enum Phase
    {
        Enter,
        Main1,
        Tavern,
        Plan,
        Execution,
        Results
    }

    // Use this for initialization
    void Start()
    {
        SetupTurn();
        _currentQuest = new SimpleQuest();
        phase = Phase.Enter;
    }

    // Move to next Phase
    void NextPhase()
    {
        //phase
        phase++;
    }

    // Moves the turnIndex to the next player and returns that player
    public void NextTurn()
    {
        turnIndex++;
        NextPhase();

        if (turnIndex >= players.Count)
        {
            turnIndex = 0;
            SetupRound();
        }

        SetupTurn();
    }
    
    public GuildBehaviorScript GetCurrentPlayer()
    {
        return players[turnIndex];
    }

    private void SetupTurn()
    {
        var gold = players[turnIndex].gold;

        MoneyAmount.text = "(" + gold + ")";

        playerText.text = players[turnIndex].name;

        foreach (var playerButton in playerButtons)
        {
            playerButton.SetActive(gold > 0);
        }
    }

    private void SetupRound()
    {
        // Reward players with the current quest
        _currentQuest.RewardQuest(players);

        // Clear deployed units and increment max units
        foreach (var player in players)
        {
            var guild = player.GetComponent<GuildBehaviorScript>();
            guild.unitsDeployed = 0;
            guild.maxUnits++;
            guild.gold -= 300;
        }

        //
    }
}