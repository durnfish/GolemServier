using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float maxHp;
    public float currentHp;

    private void OnEnable()
    {
        currentHp = maxHp;
    }

    public void OnBattle(float damage)
    {
        currentHp -= damage;
        Debug.Log(currentHp);
        if (currentHp <= 0)
        {
            gameObject.SetActive(false);

            GameObject dropExp =  GameManager.instance.expPoolManager.GetExp();
            dropExp.transform.position = gameObject.transform.position;

            currentHp = maxHp;
        }
    }
}
