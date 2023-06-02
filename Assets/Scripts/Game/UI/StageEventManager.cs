using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] private StageData stageData;
    [SerializeField] private EnemyManager enemyManager; 

    private StageTime stageTime;
    private int eventIndex;


    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
    }

    private void Update()
    {
        if (eventIndex >= stageData.stageEvents.Count)
        {
            return;
        }
        
        if (stageTime.stageTime > stageData.stageEvents[eventIndex].time)
        {
            Debug.Log(stageData.stageEvents[eventIndex].message);

            for (int i = 0; i < stageData.stageEvents[eventIndex].count; i++)
            {
                enemyManager.SpawnEnemy(stageData.stageEvents[eventIndex].enemyToSpawn);
            }
            
            eventIndex += 1;
        }

        if (eventIndex==3)
        {
            eventIndex = 0;
            stageTime.stageTime = 0;
        }
    }
}
