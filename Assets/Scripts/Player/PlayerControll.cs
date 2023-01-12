using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControll : MonoBehaviour
{
    public LayerMask LayerMaskElement;
    public GameObject targetEllement;
    public GameObject invalidTargetEllement;

    private NavMeshAgent navMeshAgent;
    private NavMeshPath meshPath;
    private Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        meshPath = new NavMeshPath();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit, 100, LayerMaskElement))
            {
                if (CalculateNewPath(raycastHit))
                {
                    navMeshAgent.SetDestination(raycastHit.point);
                    Instantiate(targetEllement, raycastHit.point, targetEllement.transform.rotation);
                }
                else
                {   
                    Instantiate(invalidTargetEllement, raycastHit.point, invalidTargetEllement.transform.rotation);
                }
            }
        }

        SetAnimation();
    }

    bool CalculateNewPath(RaycastHit hit)
    {
        navMeshAgent.CalculatePath(hit.point, meshPath);
        print("New path calculated");
        if (meshPath.status != NavMeshPathStatus.PathComplete)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void SetAnimation()
    {
        if (navMeshAgent.remainingDistance > 0.5f)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
}
