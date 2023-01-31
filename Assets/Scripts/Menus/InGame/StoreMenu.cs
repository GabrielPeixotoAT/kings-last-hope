using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Itens;
using Itens.PlayerItens;
using Menus.Ellements.Itens;

namespace Menus.InGame
{
    public class StoreMenu : MonoBehaviour
    {
        public GridLayoutGroup grid;

        public GameObject weapponItenPrefab;
        public GameObject ArmorItenPrefab;

        void Start()
        {
            FillBuyWeaponsList();
        }

        void FillBuyWeaponsList()
        {   
            foreach (Weappon weappon in GameItens.PlayerWeappons)
            {
                WeaponIten itemHUD = Instantiate(weapponItenPrefab, grid.transform).GetComponent<WeaponIten>();
                itemHUD = ConvertWeapponToUI(weappon);
                itemHUD.SetInUIValues();
            }
        }

        void FillBuyArmorsList()
        {
            foreach (Armor armor in GameItens.PlayerArmors)
            {
                
            }
        }

        WeaponIten ConvertWeapponToUI(Weappon item)
        {
            if (item != null)
            {
                return new WeaponIten()
                {
                    ItenName = item.Name,
                    Price = item.Value,
                    Weight = item.Weight,
                    ItenIcon = item.Icon,
                    Damage = item.Damage,
                    Range = item.Range,
                    Speed = item.Speed
                };
            }

            return null;
        }
    }
}

