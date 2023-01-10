using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerObject player;
    public Camera mainCamera;
    public TimerManager timer;
    public EnemyPoolManager poolManager;

    private void Awake()
    {
        instance = this;
    }
}
