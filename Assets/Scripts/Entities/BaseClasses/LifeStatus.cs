using UnityEngine;
using UnityEngine.UI;
using Entities.Interfaces.Status;

namespace Entities.BaseClasses
{
    public class LifeStatus : MonoBehaviour, ILifeStatus
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

            if (Life <= 0)
            {
                Life = 0;
                Die();
            }

            sliderLife.value = Life;
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}

