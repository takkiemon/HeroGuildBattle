﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildBehaviorScript : MonoBehaviour {

    public int gold;
    public int maxUnits;
    public int unitsDeployed;

	// Use this for initialization
	void Awake () {
        maxUnits = 5;
        unitsDeployed = 0;
        gold = 10;
	}
	
}
