using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    // �÷��̾� ����
    internal int level;

    // �÷��̾� ü��
    public float hpCurrent;
    public float hpMax;

    // �÷��̾� ���ݷ� ���
    public float atkPointMulti;

    // �÷��̾� ����ġ
    public float expCurrent;
    public float expMax;
    public float expMulti;
    internal bool levelUpCheck;
    //�÷��̾ ������ �� ��� üũ���ִ� �Լ�
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

    //�÷��̾� �̵��ӵ�
    public float speed;

    //�÷��̾� ������ ���ӽð�
    public float atkFrequency;

    private void Update()
    {
        LevelUpCheck();
    }
}
