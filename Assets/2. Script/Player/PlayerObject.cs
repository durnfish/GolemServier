using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    // 플레이어 레벨
    internal int level;

    // 플레이어 체력
    public float hpCurrent;
    public float hpMax;

    // 플레이어 공격력 배수
    public float atkPointMulti;

    // 플레이어 경험치
    public float expCurrent;
    public float expMax;
    public float expMulti;
    internal bool levelUpCheck;
    //플레이어가 레벨업 한 경우 체크해주는 함수
    void LevelUpCheck()
    {
         if (expCurrent >= expMax)
         {
            LevelUp();
         }
    }
    void LevelUp()
    {
        levelUpCheck = true;
    }

    //플레이어 이동속도
    public float speed;

    //플레이어 쓰끼리 지속시간
    public float atkFrequency;

    private void Update()
    {
        LevelUpCheck();
    }
}
