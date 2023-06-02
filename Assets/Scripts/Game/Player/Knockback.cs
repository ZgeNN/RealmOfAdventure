using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knockback : MonoBehaviour
{

    public float thrust;
    public float knockTime;
    //public float damage=1f;
    public float playerDamage;
    public float enemyDamage=1f;
    [SerializeField] public DataContainer dataContainer;

    

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                
                if (other.gameObject.CompareTag("Enemy") && other.isTrigger && !this.CompareTag("Enemy"))
                {
                    hit.AddForce(difference, ForceMode2D.Impulse);
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime, playerDamage + (dataContainer.GetUpgradeLevel(PlayerpersistentUpgrades.Damage)) );
                }
                if (other.gameObject.CompareTag("Player") && !this.gameObject.CompareTag("Bullet"))
                {
                    if (other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                    {
                        hit.AddForce(difference, ForceMode2D.Impulse);
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        other.GetComponent<PlayerMovement>().Knock(knockTime, enemyDamage);
                    }
                }
            }
        }
    }
}
