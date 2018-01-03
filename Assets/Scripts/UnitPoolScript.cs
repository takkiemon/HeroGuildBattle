using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 
 public class UnitPoolScript : MonoBehaviour
 {
     // Indicates which index turn it is.
     public int turnIndex;
     private GuildBehaviorScript currentPlayer;
 
     // The displayed text
     public Text nrOfUnits;
     public Text unitsOnQuest;
     
     private TurnHolderScript _turnHolderScript;
 
     // Use this for initialization
     void Start()
     {
         _turnHolderScript = GameObject.Find("Turn Indicator").GetComponent<TurnHolderScript>();
     }
 
     // Update is called once per frame
     void Update()
     {
         currentPlayer = _turnHolderScript.GetCurrentPlayer().GetComponent<GuildBehaviorScript>();
         
         nrOfUnits.text = currentPlayer.maxUnits - currentPlayer.unitsDeployed + " heroes in Guild Hall";
         unitsOnQuest.text = currentPlayer.unitsDeployed + " heroes on the quest";
     }
 }