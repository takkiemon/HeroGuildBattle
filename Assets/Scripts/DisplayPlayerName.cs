using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerName : MonoBehaviour {

    public Text currentPlayer;
    public PlayerMoveScript player1;
    public PlayerMoveScript player2;

    // Use this for initialization
    void Start () {
        player1 = GameObject.Find("Player1").GetComponent<PlayerMoveScript>();
        player2 = GameObject.Find("Player2").GetComponent<PlayerMoveScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if (player1.isTurn) {
            currentPlayer.text = "Player 1";
        } else if (player2.isTurn)
        {
            currentPlayer.text = "Player 2";
        }
	}
}
