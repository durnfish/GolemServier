using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colliderObject = collision.gameObject;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject colliderObject = collision.gameObject;

        if (colliderObject.tag.Equals("Wepon"))
        {
            OnBattle(colliderObject);
            colliderObject.SetActive(false);
        }
    }

    void OnBattle(GameObject gameObject)
    {
        float damage = gameObject.GetComponent<Wepon>().damage;
        Debug.Log("damage: " + damage);

        this.GetComponent<Target>().OnBattle(damage);
    }
}
