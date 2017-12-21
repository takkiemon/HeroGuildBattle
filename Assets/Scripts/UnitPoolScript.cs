using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPoolScript : MonoBehaviour {
    
    // Indicates which index turn it is.
    public int turnIndex;

    // The displayed text
    public Text nrOfUnits;
    public Text unitsOnQuest;

    // The script attached to the player
    private GuildBehaviorScript guildStats;

    // Use this for initialization
    void Start()
    {
        guildStats = GameObject.Find("Player 1").GetComponent<GuildBehaviorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        nrOfUnits.text = (guildStats.maxUnits - guildStats.unitsDeployed).ToString() + " heroes in Guild Hall";
        unitsOnQuest.text = (guildStats.unitsDeployed).ToString() + " heroes on the quest";
    }
}
