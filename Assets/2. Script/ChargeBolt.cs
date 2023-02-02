using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBolt : MonoBehaviour
{
    Animator anim;
    [SerializeField] Rigidbody rigid;
    float time;
    bool fireFlag;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        time = 0;
        fireFlag = true;
    }

    private void FixedUpdate()
    {
        Transform playerPos = GameManager.instance.player.transform;

        if (fireFlag)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            time += Time.deltaTime;

            if (time < 3f)
            {
                Debug.Log(time);
                this.transform.position = new Vector2(playerPos.position.x + h * 1.1f, playerPos.position.y + v * 1.1f);
                this.transform.rotation = Quaternion.Euler(0, 0, SetRotate(playerPos.position) + 180);
            }
            else if (time >= 3)
            {
                anim.SetTrigger("Fire");
                Vector2 force = new Vector2(h, v);
                fireFlag = false;
                Move(force);
            }
        }

    }
    void Move(Vector2 vector)
    {
        this.transform.localScale = new Vector2(5, 4);
        rigid.AddForce(vector * 1000);
    }

        float SetRotate(Vector2 playerPosition)
        {
            float angleRad = Mathf.Atan2(playerPosition.y - this.transform.position.y, playerPosition.x - this.transform.position.x);
            float angleDeg = (180 / Mathf.PI) * angleRad;
            return angleDeg;
        }
    }
