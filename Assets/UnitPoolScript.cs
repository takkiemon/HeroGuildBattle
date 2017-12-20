using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPoolScript : MonoBehaviour {

    // List of players.
    public List<GameObject> players;

    // Indicates which index turn it is.
    public int turnIndex;

    // The displayed text
    public Text playerText;

    // Use this for initialization
    void Start()
    {
        SetupTurn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Moves the turnIndex to the next player and returns that player
    public void NextTurn()
    {
        turnIndex++;
        if (turnIndex >= players.Count)
        {
            turnIndex = 0;
        }
        SetupTurn();
    }

    private void SetupTurn()
    {
        playerText.text = players[turnIndex].name;
    }
}
