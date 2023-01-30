using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltSpawner : MonoBehaviour
{

    public GameObject wepon;
    public Transform parent;

    public float atkSpeed;
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
        GameObject wepon = null;

        //��ü �˻� �� ��������
        foreach (GameObject item in pool)
        {
            if (!item.activeSelf)
            {
                wepon = item;
                wepon.SetActive(true);
                return wepon;
            }
        }
        //�˻��� �ص� �ɸ��°� �����ٸ�, ��ü ����
        if (!wepon)
        {
            wepon = Instantiate(this.wepon, parent);
            pool.Add(wepon);
            return wepon;
        }

        return wepon;
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(atkSpeed);
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
