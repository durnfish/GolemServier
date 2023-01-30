using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    [SerializeField] Transform poolTransform;
    //���� 2������ �� �ڸ�
    [SerializeField] GameObject[] enemies;

    //����Ʈ�� ��, ����Ʈ �迭 Ǯ
    List<GameObject>[] EnemyPools;

    private void Awake()
    {
        //���� ���� ��ŭ�� ����Ʈ �迭 ����
        EnemyPools = new List<GameObject>[enemies.Length];

        //�迭�� ����Ʈ�� ��
        for (int i =0;i<enemies.Length;i++)
        {
            EnemyPools[i] = new List<GameObject>();
        }
    }

    //Ư�� index�� GameObject�� ���� ���ų�, �����ϴ� �Լ�
    public GameObject GetEnemy(int index)
    {
        GameObject select = null;
        
        //��ü �˻� �� ��������
        foreach(GameObject item in EnemyPools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                return select;
            }
        }
        //�˻��� �ص� �ɸ��°� �����ٸ�, ��ü ����
        if (!select)
        {
            select = Instantiate(enemies[index], poolTransform);
            EnemyPools[index].Add(select);
            return select;
        }

        return select;
    }

}
