using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Menus.Ellements.Itens
{
    public class ListIten : MonoBehaviour
    {
        [Header("Iten Attrs")]
        public string ItenName;
        public int Price;
        public float Weight;
        public Sprite ItenIcon;

        [Header("UI Iten Attrs")]
        public TMP_Text TitleText;
        public TMP_Text AttrText;
        public TMP_Text PriceText;
        public Image IconImage;

        void Start()
        {
            SetInUIValues();
        }

        public void SetInUIValues()
        {
            SetMainValues();
            SetAttrValues();
        }

        void SetMainValues()
        {
            TitleText.text = ItenName;
            PriceText.text = Price.ToString();
            //IconImage.sprite = ItenIcon;
        }

        protected virtual void SetAttrValues()
        {
            AttrText.text = "Weight: " + Weight.ToString();
        }
    }
}

