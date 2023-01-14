using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatControll : MonoBehaviour
{
    private PlayerControll playerControll;

    void Start()
    {
        playerControll = GameObject.FindWithTag("Player").GetComponent<PlayerControll>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerControll.enemyTarget)
        {
            playerControll.CombatAction(other);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == playerControll.enemyTarget)
        {
            playerControll.CombatAction(other);
        }
    }
}
