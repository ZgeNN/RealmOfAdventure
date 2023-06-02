using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTime : MonoBehaviour
{
    public float time;
    private TimeUI timer;
    public float stageTime;


    private void Awake()
    {
        timer = FindObjectOfType<TimeUI>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        stageTime += Time.deltaTime;
        timer.UpdateTime(time);
    }
}
