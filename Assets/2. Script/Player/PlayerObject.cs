using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public static PlayerObject player;

    // �÷��̾� ����
    internal int level;

    // �÷��̾� ü��
    public float hpCurrent;
    public float hpMax;

    // �÷��̾� ���ݷ� ���
    public float atkPointPulti;

    // �÷��̾� ����ġ
    public float expCurrent;
    public float expMax;
    public float expMulti;

    //�÷��̾� �̵��ӵ�
    public float speed;

    //�÷��̾� ������ - 

    //�÷��̾� ������Ʈ �̱��� ����
    private void Awake()
    {
        if(player == null)
        {
            player = this;
        }
    }
}
