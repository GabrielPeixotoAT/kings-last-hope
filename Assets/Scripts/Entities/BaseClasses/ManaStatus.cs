using UnityEngine;
using UnityEngine.UI;
using Entities.Interfaces.Status;

namespace Entities.BaseClasses
{
    public class ManaStatus : MonoBehaviour, IManaStatus
    {
        [Header("Mana Status")]
        public float Mana;
        public float MaxMana;
        public Slider manaSlider;


        void Start()
        {
            manaSlider.maxValue = MaxMana;
            manaSlider.value = Mana;
        }

        public void UseMana(float used)
        {
            Mana -= used;
            manaSlider.value = Mana;
        }

        public void StealMana(float used)
        {
            Mana -= used;
            manaSlider.value = Mana;
        }
    }
}
