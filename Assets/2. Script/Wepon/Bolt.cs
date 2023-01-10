using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : Wepon
{
    PlayerObject player;
    void OnEnable()
    {
        player = GameManager.instance.player;

        Vector2 position = SetPosition();
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();


        gameObject.transform.position = new Vector2(player.transform.position.x + position.x, player.transform.position.y + position.y);
        rigid.AddForce(position * speed);
        rigid.velocity = Vector2.zero;
    }

    public Vector2 SetPosition()
    { 
        Rigidbody2D playrtPosioton = player.GetComponent<Rigidbody2D>();

        float positionX = Random.Range(-4, 4);
        float positionY = Random.Range(-4, 4);

        return new Vector2(positionX, positionY);
    }

}
