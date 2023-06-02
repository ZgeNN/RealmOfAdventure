using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerpersistentUpgrades
{
    HP,
    Damage,
}

[Serializable]
public class PlayerUpgrades
{
    public PlayerpersistentUpgrades persistentUpgrades;
    public int costToUpgrade;
    public int level;
}

[CreateAssetMenu]
public class DataContainer : ScriptableObject
{
    public int coins;

    public List<PlayerUpgrades> upgrades;

    public int GetUpgradeLevel(PlayerpersistentUpgrades persistentUpgrade)
    {
        return upgrades[(int)persistentUpgrade].level;
    }
}
