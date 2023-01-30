using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject colliderObject = collision.gameObject;
        
        if (colliderObject.tag.Equals("Player"))
        {
            GetExp();
            gameObject.SetActive(false);
        }
    }

    void GetExp()
    {
        float expMax = GameManager.instance.player.expMax;
        float expMulti = GameManager.instance.player.expMulti;

        GameManager.instance.expSlider.currentExp += 10 * expMulti;
        float currentExp = GameManager.instance.expSlider.currentExp;

        Debug.Log(currentExp);

        if (currentExp >= expMax)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        GameManager.instance.expSlider.currentExp = 0;
    }
}
