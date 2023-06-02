using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinTextManager : MonoBehaviour
{
    public TextMeshProUGUI coinDisplay;
    public DataContainer coinNumber;
    
    public void UpdateCoinCount()
    {
        coinDisplay.text = "" + coinNumber.coins;
    }
}
