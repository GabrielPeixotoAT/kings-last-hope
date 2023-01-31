using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.Player;

namespace Menus.InGame
{
    public class ActiveStoreMenu : MonoBehaviour, IInteractMenu
    {
        private GameObject menu;

        void Start()
        {
            menu = GameObject.FindWithTag("StoreMenu");
            menu.SetActive(false);
        }

        public void ActiveMenu(bool active)
        {
            menu.SetActive(active);
        }

        public void CloseMenu()
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerControll>().InInteraction = false;
            menu.SetActive(false);
        }
    }
}