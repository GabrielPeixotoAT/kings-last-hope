using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeStatus : MonoBehaviour, IKillable
{
    [Header("Life Status")]
    public float Life;
    public float MaxLife;
    public Slider sliderLife;


    void Start()
    {
        sliderLife.maxValue = MaxLife;
        sliderLife.value = Life;
    }

    public void TakeDamage(float damage)
    {
        Life -= damage;

        if (Life < 0)
            Life = 0;

        sliderLife.value = Life;
    }
}
