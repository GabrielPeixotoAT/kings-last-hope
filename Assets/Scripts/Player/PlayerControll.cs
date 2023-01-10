using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControll : MonoBehaviour
{
    public LayerMask LayerMaskElement;
    public GameObject targetEllement;

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit, 100, LayerMaskElement))
            {
                navMeshAgent.SetDestination(raycastHit.point);
                Instantiate(targetEllement, raycastHit.point, new Quaternion());
            }
        }
    }
}
