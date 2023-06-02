using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using TMPro;

public class MainMenuCoinText : MonoBehaviour
{
    private TextMeshProUGUI coinDisplay;
    public DataContainer coinNumber;


    private void Start()
    {
        coinDisplay = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        coinDisplay.text = "" + coinNumber.coins;
    }
}
