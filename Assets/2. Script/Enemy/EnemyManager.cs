using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyObject enemy1, enemy2;

    TimerManager time;
    private void Awake()
    {
        time = TimerManager.timer;
    }
    void EnemyStatusUP()
    {

    }
}
