using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    //싱글톤 생성
    public static TimerManager timer;

    DateTime startTime;
    [SerializeField] Text text;

    private void Awake()
    {
        if (timer == null)
        {
            timer = this;
        }
        //게임이 시작될 때의 시간 표시
        startTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ShowCurrentTime();
    }

    // 현재 시간 - 게임이 시작된 시간 을 구하는 함수
    public TimeSpan GetCurrentTime()
    {
        TimeSpan timer = DateTime.Now - startTime;
        return timer;
    }

    // GetCurrentTime 에서 가져온 시간을 String으로 변환
    String ShowCurrentTime()
    {
        TimeSpan timer = GetCurrentTime();
        return timer.Minutes + ":" + timer.Seconds;
    }
}
