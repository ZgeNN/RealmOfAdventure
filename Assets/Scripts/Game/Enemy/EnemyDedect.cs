using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDedect : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }
    
    [SerializeField]private float _playerdedectdistance;
    
    private Transform _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>().transform;
    }

    
    void Update()
    {
        Vector2 enemytoPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemytoPlayerVector.normalized;
        if (enemytoPlayerVector.magnitude <= _playerdedectdistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
