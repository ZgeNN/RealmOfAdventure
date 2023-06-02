using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerState{
    walk,
    attack,
    shoot,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour {


    
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Knockback playerDamage;
    private bool isDead;
    private Animator animator;
    public FloatValue currentHealth;
    public FloatValue heartContainers;
    public SignalSender playerHealthSignal;
    public GameObject projectile;
    public float damageBonus;
    [SerializeField] public DataContainer dataContainer;
    public FloatValue playerMaxHealth;
    public PlayerState currentState;
    public float speed;
    
    
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start ()
    {
        ApplyPersistantUpgrade();
        currentState = PlayerState.walk;
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", -1);
    }

    public void ApplyPersistantUpgrade()
    {
        int hpUpgradeLevel = dataContainer.GetUpgradeLevel(PlayerpersistentUpgrades.HP);
        
        heartContainers.RuntimeValue += hpUpgradeLevel;
        currentHealth.RuntimeValue += hpUpgradeLevel * 2;
        playerMaxHealth.initialValue = currentHealth.RuntimeValue;
        
        int damageUpgradeLevel = dataContainer.GetUpgradeLevel(PlayerpersistentUpgrades.Damage);

        damageBonus = 1f + 0.1f * damageUpgradeLevel;

    }
    private void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("Fire1") && currentState != PlayerState.attack 
                                        && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (Input.GetButtonDown("Fire2") && currentState!=PlayerState.shoot
                 && currentState != PlayerState.stagger)
        {
            StartCoroutine(ShootCo());
        }
    }

    void FixedUpdate () {
        if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
	}

    private IEnumerator AttackCo()
    {
        animator.SetBool("isAttacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }
    
    private IEnumerator ShootCo()
    {
        animator.SetBool("isShooting", true);
        currentState = PlayerState.shoot;
        yield return null;
        MakeBullet();
        animator.SetBool("isShooting", false);
        yield return new WaitForSeconds(.5f);
        currentState = PlayerState.walk;
        
    }
    private void MakeBullet()
    {
        
        Vector2 temp = new Vector2(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"));
        Bullet bullet = Instantiate(projectile,transform.position,Quaternion.identity).GetComponent<Bullet>();
        bullet.Setup(temp,ChooseBulletDirection());
    }
    
    Vector3 ChooseBulletDirection()
    {
        float temp = -Mathf.Atan2(animator.GetFloat("Vertical"), animator.GetFloat("Horizontal"))* Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }


    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("Horizontal", change.x);
            animator.SetFloat("Vertical", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * (speed * Time.deltaTime)
        );
    }

    public void Knock(float knockTime, float damage)
    {
        if (isDead == true) { return;}
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            GetComponent<CharacterGameOver>().GameOver();
            isDead = true;
        }
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
