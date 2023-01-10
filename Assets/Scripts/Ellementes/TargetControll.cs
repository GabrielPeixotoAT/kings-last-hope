using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControll : MonoBehaviour
{
    private float timer;

    void Start()
    {
        GameObject otherTarget = GameObject.FindWithTag("Target");
        if (otherTarget != gameObject)
        {
            Destroy(otherTarget);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
