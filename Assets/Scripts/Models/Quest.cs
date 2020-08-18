using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public interface Quest
    {
        // Method that rewards the given players
        void RewardQuest(List<GuildBehaviorScript> players);
    }
}