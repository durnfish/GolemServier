using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpUpdate : MonoBehaviour
{
    public ImgsFillDynamic ImgsFD;

    private void Update()
    {
        float expCurrent = GameManager.instance.player.expCurrent;
        float expMax = GameManager.instance.player.expMax;

        this.ImgsFD.SetValue(expCurrent / expMax, false, 10f);
    }

}
