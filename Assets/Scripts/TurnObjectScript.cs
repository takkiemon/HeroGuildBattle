using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObjectScript : MonoBehaviour {

    public List<TurnClass09> playersGroup;
	// Use this for initialization
	void Start () {
        ResetTurns();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTurns();
	}

    void ResetTurns()
    {
        for (int i = 0; i < playersGroup.Count; i++)
        {
            playersGroup[i].isTurn = (i == 0);
            playersGroup[i].wasTurnPrev = false;
        }
    }

    void UpdateTurns()
    {
        for (int i = 0; i < playersGroup.Count; i++)
        {
            if (!playersGroup[i].wasTurnPrev)
            {
                playersGroup[i].isTurn = true;
                break;
            }
            else if (i== playersGroup.Count - 1 && playersGroup[i].wasTurnPrev)
            {
                ResetTurns();
            }
        }
    }
}

[System.Serializable]
public class TurnClass09
{
    public GameObject playerGameObject;
    public bool isTurn = false;
    public bool wasTurnPrev = false;
}
