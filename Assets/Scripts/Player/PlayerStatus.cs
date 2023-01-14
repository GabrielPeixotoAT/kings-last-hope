using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
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

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        Life -= damage;
        sliderLife.value = Life;
    }
}
