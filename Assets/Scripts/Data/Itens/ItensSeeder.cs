using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;
using Itens.PlayerItens;

namespace Data.Itens
{
    public class ItensSeeder : MonoBehaviour
    {
        void Awake()
        {
            GameItens.PlayerWeappons = new List<Weappon>()
            {
                new Weappon()
                {
                    Name = "Imperial Sword",
                    Value = 150,
                    SellValue = 90,
                    Weight = 1.5f,
                    Damage = 20,
                    Range = 90,
                    Speed = 0.6f
                },
                new Weappon()
                {
                    Name = "Nordic Great Sword",
                    Value = 230,
                    SellValue = 150,
                    Weight = 2.1f,
                    Damage = 31,
                    Range = 115,
                    Speed = 0.6f
                }

            };

            GameItens.PlayerArmors = new List<Armor>()
            {
                new Armor()
                {
                    Name = "Imperial Armor",
                    Value = 300,
                    SellValue = 210,
                    Weight = 4.7f,
                    FisicalProtection = 30,
                    MagicProtection = 0
                }

            };
        }
    }
}
