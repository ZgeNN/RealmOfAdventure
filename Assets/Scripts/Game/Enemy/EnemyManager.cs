using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesGroup
{
   
   public int count;
}


public class EnemyManager : MonoBehaviour
{
   [SerializeField] private GameObject enemy;
   [SerializeField] private Vector2 spawnArea;
   [SerializeField] private float spawnTimer;
   [SerializeField] private Transform target;
   private float timer;
   
   public void SpawnEnemy(Enemy enemyToSpawn)
   {
      Vector3 position = GenerateRandomPosition();

      GameObject newEnemy = Instantiate(enemyToSpawn.gameObject);
      newEnemy.transform.position = position;
   }

   private Vector3 GenerateRandomPosition()
   {
      Vector3 position = new Vector3();

      float f = Random.value > 0.5f ? -1f : 1f;
      if (Random.value > 0.5f)
      {
         position.x = Random.Range(-spawnArea.x, spawnArea.x);
         position.y = spawnArea.y * f;
      }
      else
      {
         position.y = Random.Range(-spawnArea.y, spawnArea.y);
         position.x = spawnArea.x * f;
      }
      position.z = 0;

      return position;
   }
}
