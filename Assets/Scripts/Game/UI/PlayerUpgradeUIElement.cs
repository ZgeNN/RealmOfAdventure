using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerUpgradeUIElement : MonoBehaviour
{
    [SerializeField] PlayerpersistentUpgrades upgrade;
    [SerializeField] TextMeshProUGUI upgradeName;
    [SerializeField] TextMeshProUGUI upgradePrice;
    [SerializeField] TextMeshProUGUI upgradeLevel;
    
    [SerializeField] DataContainer dataContainer;

    private void Start()
    {
        UpdateElement();
    }

    public void Upgrade()
    {
        PlayerUpgrades playerUpgrades = dataContainer.upgrades[(int)upgrade];

        if (dataContainer.coins >= playerUpgrades.costToUpgrade)
        {
            dataContainer.coins -= playerUpgrades.costToUpgrade;
            playerUpgrades.level += 1;
            UpdateElement();
        }
    }


    void UpdateElement()
    {
        PlayerUpgrades playerUpgrades = dataContainer.upgrades[(int)upgrade];
        
        upgradeName.text = upgrade.ToString();
        upgradeLevel.text = playerUpgrades.level.ToString();
        upgradePrice.text = playerUpgrades.costToUpgrade.ToString();
    }
}
