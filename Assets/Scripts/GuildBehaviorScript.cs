using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildBehaviorScript : MonoBehaviour {

    public int gold;
    public int maxUnits;
    public int unitsDeployed;

	// Use this for initialization
	void Start () {
        maxUnits = 5;
        unitsDeployed = 0;
        gold = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
