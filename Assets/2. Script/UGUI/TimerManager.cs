using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{

    DateTime startTime;
    [SerializeField] Text text;

    private void Awake()
    {
        //������ ���۵� ���� �ð� ǥ��
        startTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ShowCurrentTime();
    }

    // ���� �ð� - ������ ���۵� �ð� �� ���ϴ� �Լ�
    public TimeSpan GetCurrentTime()
    {
        TimeSpan timer = DateTime.Now - startTime;
        return timer;
    }

    // GetCurrentTime ���� ������ �ð��� String���� ��ȯ
    String ShowCurrentTime()
    {
        TimeSpan timer = GetCurrentTime();
        return timer.Minutes + ":" + timer.Seconds;
    }
}
