using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]Rigidbody2D ridg;
    Vector3 vector;
    Animator animator;
    float speed;

    private void Awake()
    {
        ridg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Run(h,v);
    }

    void Run(float h, float v)
    {
        speed = PlayerObject.player.speed; // �츮�� �÷��̾� ������Ʈ�� ����� speed�� ����Ұ��̴�.
        vector.Set(h, v, 0);
        vector = vector.normalized * speed * Time.deltaTime;

        ridg.MovePosition(transform.position + vector);

        if (vector.x == 0 && vector.y == 0)
        {
            animator.SetBool("IsMoving", false);
        }
        else animator.SetBool("IsMoving", true);
    }
}
