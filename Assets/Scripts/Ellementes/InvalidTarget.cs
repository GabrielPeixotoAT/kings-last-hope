using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvalidTarget : MonoBehaviour
{
    private float timer;

    void Start()
    {
        GameObject otherTarget = GameObject.FindWithTag("Target");
        if (otherTarget != gameObject)
        {
            Destroy(otherTarget);
        }
        Destroy(gameObject, 1.5f);
    }
}
