using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Menus.Ellements.Itens
{
    public class ListIten : MonoBehaviour
    {
        [Header("Iten Attrs")]
        public string ItenName;
        public int Price;
        public float Weight;

        [Header("UI Iten Attrs")]
        public TMP_Text TitleText;
        public TMP_Text AttrText;
        public TMP_Text PriceText;

        void Start()
        {
            SetInUIValues();
        }

        void SetInUIValues()
        {
            SetMainValues();
            SetAttrValues();
        }

        void SetMainValues()
        {
            TitleText.text = ItenName;
            PriceText.text = Price.ToString();
        }

        protected virtual void SetAttrValues()
        {
            AttrText.text = "Weight: " + Weight.ToString();
        }
    }
}

