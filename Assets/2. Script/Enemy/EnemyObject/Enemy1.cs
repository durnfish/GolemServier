using System.Collections;
using UnityEngine;


public class Enemy1 : Target
{
    public EnemyObject enemy1;
    [SerializeField] Rigidbody2D rigid;

    Rigidbody2D target;

    IEnumerator UpdatePath()
    {
        float refreshRate = 0.01f;
        while (target != null)
        {
            Vector2 dirVector = target.position - rigid.position;
            Vector2 nextVector = dirVector.normalized * enemy1.speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + nextVector);
            rigid.velocity = Vector2.zero;

            yield return new WaitForSeconds(refreshRate);
        }
    }
    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        StartCoroutine(UpdatePath());
    }
}
