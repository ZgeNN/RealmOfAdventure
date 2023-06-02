using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStab : MonoBehaviour
{
    /*[SerializeField] private Transform _stabOffset;
    [SerializeField] private float _stabRate;
    
    private float _stabTime=0.25f;
    private float _stabCounter=0.25f;
    private bool isStabbing;
    private bool input;
    private PlayerMovement playerMovement;
    private float _lastmovehorizontal;
    private float _lastmovevertical;

    private Rigidbody2D _rb;
    //private PlayerInput inputActions;

    public Animator animator;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
        //inputActions = new PlayerInput();
        //_lastmovehorizontal = playerMovement._movementInput.x;
        //_lastmovehorizontal = playerMovement._movementInput.y;
        //inputActions.Player.Stab.performed += context => Stab();

    }

    void Update()
    {
        if (input)
        {
            //float timeSinceLastStab = Time.time - _lastStabTime;
            Stab();
            //isStabbing = true;
            CoolDownStabing(_stabCounter);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            _stabCounter = _stabTime;
            Stab();
        }

        if (isStabbing)
        {
            _rb.velocity = Vector2.zero;
            _stabCounter -= Time.deltaTime;
            if (_stabCounter <= 0)
            {
                animator.SetBool("isStabing",false);
                isStabbing = false;
            }
        }
    }
    
    public void CoolDownStabing(float stabcounter)
    {
        StartCoroutine(StabCoroutine(stabcounter));
    }
    private IEnumerator StabCoroutine(float stabcounter)
    {
        yield return new WaitForSeconds(stabcounter);
        animator.SetBool("isStabing", false);
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = _bulletSpeed * transform.up;
    }

    private void Stab()
    {
        animator.SetFloat("lastMoveHorizontal", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("lastMoveVertical", Input.GetAxisRaw("Vertical"));
        animator.SetBool("isStabing", true);
        isStabbing = true;
    }
    

    private void OnStab(InputValue inputValue)
    {
        input = inputValue.Get<>()
    }*/
    
    
}
