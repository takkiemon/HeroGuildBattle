using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 
 public class UnitPoolScript : MonoBehaviour
 {
     // Indicates which index turn it is.
     public int turnIndex;
     private GuildBehaviorScript currentPlayerScript;
 
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
         currentPlayerScript = _turnHolderScript.GetCurrentPlayer().GetComponent<GuildBehaviorScript>();

         if (currentPlayerScript.gold > 0)
         {
             nrOfUnits.text = currentPlayerScript.maxUnits - currentPlayerScript.unitsDeployed + " heroes in Guild Hall";
             unitsOnQuest.text = currentPlayerScript.unitsDeployed + " heroes on the quest";
         } 
         else
         {
             nrOfUnits.text = "YOU DEAD SUCK";
         }
     }
 }