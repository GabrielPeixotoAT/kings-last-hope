using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entities.BaseClasses;

namespace Entities.Player
{
    public class PlayerStatus : MonoBehaviour
    {
        public GameObject StatusObject;

        [Header("Combat Status")]
        public float Damage;


        LifeStatus lifeStatus;
        ManaStatus manaStatus;

        void Start()
        {
            lifeStatus = StatusObject.GetComponent<LifeStatus>();
            manaStatus = StatusObject.GetComponent<ManaStatus>();
        }
    }
}

