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

        timer = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
