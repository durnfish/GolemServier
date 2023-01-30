using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpSliderManager : MonoBehaviour
{
    [SerializeField] Slider expSlider;

    [HideInInspector]public float currentExp;

    private void Start()
    {
        currentExp = 0;
    }

    private void Update()
    {
        float expMax = expMax = GameManager.instance.player.expMax;

        expSlider.value = currentExp / expMax;
    }
}
