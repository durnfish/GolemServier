using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltSpawner : MonoBehaviour
{

    public GameObject wepon;
    public Transform parent;
    public float frequency;
    public int numProjectiles;

    List<GameObject> pool;

    private void Awake()
    {
        pool = new List<GameObject>();
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    public GameObject GetWepon()
    {
        GameObject select = null;

        //��ü �˻� �� ��������
        foreach (GameObject item in pool)
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
            select = Instantiate(wepon, parent);
            pool.Add(select);
            return select;
        }

        return select;
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(frequency);
            MakeWepon();

        }
    }

    void MakeWepon()
    {
        for (int i = 1; i <= numProjectiles; i++)
        {
            GameObject instanceObject = GetWepon();
        }
    }

}
