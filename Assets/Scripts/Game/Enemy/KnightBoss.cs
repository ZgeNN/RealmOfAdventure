using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightBoss : Log
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*else if (Vector3.Distance(target.position,
                     transform.position) > chaseRadius)
        {
            anim.SetBool("WakeUp", false);
        }*/
    }
    
    
   public override void CheckDistance()
    {
        if(Vector3.Distance(target.position, 
               transform.position) <= chaseRadius
           && Vector3.Distance(target.position,
               transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position,
                    target.position,
                    moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                //anim.SetBool("WakeUp", true);
            }
        }else if (Vector3.Distance(target.position, 
                         transform.position) <= chaseRadius
                        && Vector3.Distance(target.position,
                         transform.position) <= attackRadius)
        {
            if (currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                StartCoroutine(AttackCo());
            }
        }
    }

   public IEnumerator AttackCo()
   {
       currentState = EnemyState.attack;
       anim.SetBool("Attack", true);
       yield return new WaitForSeconds(1f);
       currentState = EnemyState.walk;
       anim.SetBool("Attack", false);
   }
}
