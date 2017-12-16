using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {

    public TurnObjectScript turnSystem;
    public TurnClass09 turnClass;
    public bool isTurn = false;
    public KeyCode moveKey;

	// Use this for initialization
	void Start () {
        turnSystem = GameObject.Find("TurnObject").GetComponent<TurnObjectScript>();

        foreach(TurnClass09 tc in turnSystem.playersGroup)
        {
            if (tc.playerGameObject.name == gameObject.name)
            {
                turnClass = tc;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        isTurn = turnClass.isTurn;

        if (isTurn && Input.GetKeyDown(moveKey))
        {
            transform.position += Vector3.forward;
            isTurn = false;
            turnClass.isTurn = false;
            turnClass.wasTurnPrev = true;
        }
	}

    public void EndTurnButton()
    {
        if (isTurn)
        {
            isTurn = false;
            turnClass.isTurn = false;
            turnClass.wasTurnPrev = true;
        }
    }
}
