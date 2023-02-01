using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject colliderObject = collision.gameObject;

        if (colliderObject.tag.Equals("Wepon"))
        {
            OnBattle(colliderObject);

            Animator animation = colliderObject.GetComponent<Wepon>().hitEffect;
            //animation.SetBool("Hit", true);
            if (EndCheck(animation))
            {
                Debug.Log("Hit");
            }
            //colliderObject.SetActive(false);
        }
    }

    void OnBattle(GameObject gameObject)
    {
        float atkMulti = GameManager.instance.player.atkPointMulti;
        
        // �÷��̾� ���ݷ� ����� ����Ͽ� ������ ����
        float damage = gameObject.GetComponent<Wepon>().damage * atkMulti;

            this.GetComponent<Target>().OnBattle(damage);
    }

    bool EndCheck(Animator animator)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hit") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            return true;
        }

        return false;
    }
}
