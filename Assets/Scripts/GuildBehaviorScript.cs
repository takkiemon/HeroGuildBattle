using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildBehaviorScript : NetworkBehaviour {

    public int gold;
    public int maxUnits;
    public int unitsDeployed;
    public TurnHolderScript.Phase currentPhase;

	// Use this for initialization
	void Awake () {
        maxUnits = 5;
        unitsDeployed = 0;
        gold = 10;
        SetPhase(TurnHolderScript.Phase.Enter);
	}
	
    public void SetPhase(TurnHolderScript.Phase newPhase)
    {
        currentPhase = newPhase;
    }

    private void SetUI(TurnHolderScript.Phase currentPhase)
    {

    }
}
