using System.Collections.Generic;
using UnityEngine;

namespace Models.Quests
{
    public class SimpleQuest : Quest
    {
        public void RewardQuest(List<GameObject> players)
        {
            foreach (var gameObject in players)
            {
                var guildBehaviorScript = gameObject.GetComponent<GuildBehaviorScript>();
                guildBehaviorScript.gold += guildBehaviorScript.unitsDeployed * 100;
            }
        }
    }
}