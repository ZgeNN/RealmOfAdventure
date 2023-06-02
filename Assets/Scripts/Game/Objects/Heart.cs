using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PickUp
{
    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public float amounttoIncrease;
    public FloatValue playerMaxHealth;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && playerMaxHealth.RuntimeValue> playerHealth.RuntimeValue)
        { 
            playerHealth.RuntimeValue += amounttoIncrease;
            if (playerHealth.initialValue > heartContainers.RuntimeValue * 2f)
            { 
                playerHealth.initialValue = heartContainers.RuntimeValue * 2f;
            }
            powerupSignal.Raise();
            Destroy((this.gameObject));
        }
    }
}
