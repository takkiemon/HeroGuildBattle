using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployScript : MonoBehaviour {
	
	private TurnHolderScript _turnHolderScript;
	
	// Use this for initialization
	void Start()
	{
		_turnHolderScript = GameObject.Find("Turn Indicator").GetComponent<TurnHolderScript>();
	}
	
	public void DeployUnit()
	{
		var guildBehaviorScript = _turnHolderScript.GetCurrentPlayer();
		if (guildBehaviorScript.unitsDeployed < guildBehaviorScript.maxUnits)
		{
			guildBehaviorScript.unitsDeployed++;
		}
	}

	public void CancelDeploy()
	{
		var guildBehaviorScript = _turnHolderScript.GetCurrentPlayer().GetComponent<GuildBehaviorScript>();
		if (guildBehaviorScript.unitsDeployed > 0)
		{
			guildBehaviorScript.unitsDeployed--;
		}
	}
}
