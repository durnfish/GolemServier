using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropExpPoolManager : MonoBehaviour
{
    [SerializeField] GameObject expObject;
    [SerializeField] GameObject poolTransform;

    List<GameObject> expPool;

    private void Awake()
    {
        expPool = new List<GameObject>();
    }

    public GameObject GetExp()
    {
        GameObject exp = null;

        foreach(GameObject item in expPool)
        {
            if (!item.activeSelf)
            {
                exp = item;
                exp.SetActive(true);
                return exp;
            }
        }
        if (!exp)
        {
            exp = Instantiate(expObject, poolTransform.transform);
            expPool.Add(exp);
            return exp;
        }

        return exp;
    }
}
