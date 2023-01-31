using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menus.Ellements.Itens
{
    public class ArmorIten : ListIten
    {
        [Header("Armor Attrs")]
        public float ProtectFisical;
        public float ProtectMagic;

        protected override void SetAttrValues()
        {
            AttrText.text = $"Fisic Protection: {ProtectFisical} Magic Protecton: {ProtectMagic}";
        }
    }
}
