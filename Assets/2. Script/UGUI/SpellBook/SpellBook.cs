using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpellBook : MonoBehaviour
{
    [SerializeField] GameObject reward;

    float timeCheck;
    private void Awake()
    {
        reward.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool levelUpCheck = GameManager.instance.player.levelUpCheck;

        if (levelUpCheck)
        {
            timeCheck += Time.deltaTime;
            if (timeCheck >= 0.5f)
            {
                BookActive();
                timeCheck = 0;
            }
        }
    }

    void BookActive()
    {
        reward.SetActive(true);
        Time.timeScale = 0;
    }

    public void TakeSpell()
    {
        reward.SetActive(false);

        GameManager.instance.player.expCurrent -= GameManager.instance.player.expMax;
        GameManager.instance.player.expMax *= 1.3f;
        GameManager.instance.player.levelUpCheck = false;

        Debug.Log(GameManager.instance.player.levelUpCheck);

        Time.timeScale = 1;
    }
}
