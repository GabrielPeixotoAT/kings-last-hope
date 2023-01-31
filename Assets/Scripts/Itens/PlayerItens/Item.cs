using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itens.PlayerItens
{
    public abstract class Item : MonoBehaviour
    {
        public string Name;
        public int Value;
        public int SellValue;
        public float Weight;
        public Sprite Icon;
    }
}

