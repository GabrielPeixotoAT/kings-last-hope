using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.Player;

namespace Menus.InGame
{
    public class StoreMenu : MonoBehaviour, IInteractMenu
    {
        public GameObject Menu;

        public void ActiveMenu(bool active)
        {
            Menu.SetActive(active);
        }   

        public void CloseMenu()
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerControll>().InInteraction = false;
            Menu.SetActive(false);
        }
    }
}

