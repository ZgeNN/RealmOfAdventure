using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public SignalSender powerupSignal;

    private void Start()
    {
        powerupSignal.Raise();
    }
}
