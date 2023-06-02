using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Loot
{
    public PickUp thisLoot;
    public int lootChance;
}



[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    public Loot[] loots;

    public PickUp LootPickUp()
    {
        int cumProb = 0;
        int currentProb = Random.Range(0, 100);
        for (int i = 0; i < loots.Length; i++)
        {
            cumProb += loots[i].lootChance;
            if (currentProb <= cumProb)
            {
                return loots[i].thisLoot;
            }
        }
        return null;
    }
    
}
