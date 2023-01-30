using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerObject player;
    public Camera mainCamera;
    public TimerManager timer;
    public EnemyPoolManager enemyPoolManager;
    public DropExpPoolManager expPoolManager;

    private void Awake()
    {
        instance = this;
    }
}
