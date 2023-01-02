using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public static PlayerObject player;

    // 플레이어 레벨
    internal int level;

    // 플레이어 체력
    public float hpCurrent;
    public float hpMax;

    // 플레이어 공격력 배수
    public float atkPointPulti;

    // 플레이어 경험치
    public float expCurrent;
    public float expMax;
    public float expMulti;

    //플레이어 이동속도
    public float speed;

    //플레이어 쓰끼리 - 

    //플레이어 오브젝트 싱글톤 구현
    private void Awake()
    {
        if(player == null)
        {
            player = this;
        }
    }
}
