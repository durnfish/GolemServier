using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : Wepon
{
    [SerializeField] GameObject wepon;
    PlayerObject player;

    void OnEnable()
    {
        player = GameManager.instance.player;

        Vector2 position = SetPosition();
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();

        gameObject.transform.position = new Vector2(player.transform.position.x + position.x, player.transform.position.y + position.y);
        this.transform.rotation = Quaternion.Euler(0, 0, SetRotate(player.transform.position)); 

        rigid.AddForce(position * speed);
        rigid.velocity = Vector2.zero;

        StartCoroutine(SetDisable());
    }

    public Vector2 SetPosition()
    { 
        float positionX = Random.Range(-4, 4);
        float positionY = Random.Range(-4, 4);

        return new Vector2(positionX, positionY);
    }

    float SetRotate(Vector2 playerPosition)
    {
        float angleRad = Mathf.Atan2(playerPosition.y - this.transform.position.y, playerPosition.x - this.transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;
        return angleDeg;
    }

    IEnumerator SetDisable()
    {
        yield return new WaitForSeconds(GameManager.instance.player.atkFrequency);
        gameObject.SetActive(false);
    }
}
