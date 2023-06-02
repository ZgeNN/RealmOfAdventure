using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PickUp
{
    public DataContainer coin;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            coin.coins += 1;
            powerupSignal.Raise();
            Destroy((this.gameObject));
            
        }
    }
}
