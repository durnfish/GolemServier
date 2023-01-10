using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    [SerializeField] Transform poolTransform;
    //몬스터 2종류가 들어갈 자리
    [SerializeField] GameObject[] enemies;

    //리스트가 들어갈, 리스트 배열 풀
    List<GameObject>[] pools;

    private void Awake()
    {
        //몬스터 숫자 만큼의 리스트 배열 생성
        pools = new List<GameObject>[enemies.Length];

        //배열에 리스트가 들어감
        for (int i =0;i<enemies.Length;i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    //특정 index의 GameObject를 가져 오거나, 생성하는 함수
    public GameObject GetEnemy(int index)
    {
        GameObject select = null;
        
        //객체 검색 및 가져오기
        foreach(GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                return select;
            }
        }
        //검색을 해도 걸리는게 없었다면, 객체 생성
        if (!select)
        {
            select = Instantiate(enemies[index], poolTransform);
            pools[index].Add(select);
            return select;
        }

        return select;
    }

}
