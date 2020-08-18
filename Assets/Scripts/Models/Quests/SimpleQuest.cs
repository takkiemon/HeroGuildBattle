using System.Collections.Generic;
using UnityEngine;

namespace Models.Quests
{
    public class SimpleQuest : Quest
    {
        public void RewardQuest(List<GuildBehaviorScript> players)
        {
            foreach (var script in players)
            {
                script.gold += script.unitsDeployed * 100;
            }
        }
    }
}