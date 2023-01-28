using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menus.Ellements.Itens
{
    public class WeaponIten : ListIten
    {
        [Header("Weapon Attrs")]
        public float Damage;
        public float Range;
        public float Speed;

        protected override void SetAttrValues()
        {   
            AttrText.text = $"Damage: {Damage} Range: {Range} Speed: {Speed}";
        }
    }
}
