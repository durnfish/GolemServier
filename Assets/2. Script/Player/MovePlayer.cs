using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]Rigidbody2D ridg;
    Vector3 vector;
    float speed;

    Animator animator;
    string animationState = "WalkState";
    enum States
    {
        idle = 0,
        left = 1,
        forward = 2,
        right = 3
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        ridg = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Run(h,v);
    }

    void Run(float h, float v)
    {
        speed = GameManager.instance.player.speed; // 우리는 플레이어 오브젝트에 선언된 speed를 사용할것이다.
        vector.Set(h, v, 0);
        vector = vector.normalized * speed * Time.deltaTime;

        ridg.MovePosition(transform.position + vector);

        if (h > 0)
        {
            animator.SetInteger(animationState, (int)States.right);
        }
        else if (h < 0)
        {
            animator.SetInteger(animationState, (int)States.left);
        }
        else if (h == 0 && v != 0)
        {
            animator.SetInteger(animationState, (int)States.forward);
        }
        else animator.SetInteger(animationState, (int)States.idle);
    }
}
