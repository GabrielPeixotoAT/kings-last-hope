using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControll : MonoBehaviour
{

    [Header("Movement")]
    public LayerMask LayerMaskMovement;
    public GameObject targetEllement;
    public GameObject invalidTargetEllement;
    public AudioClip footStepsAudioClip;

    [Header("Interact")]
    public LayerMask LayerMaskIntect;

    private bool goToInteract;

    [Header("Combat")]
    public LayerMask LayerMaskEnemys;

    private GameObject enemyTarget;
    private bool goToAttack;

    private AudioSource audioSource;
    private NavMeshAgent navMeshAgent;
    private NavMeshPath meshPath;
    private Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        meshPath = new NavMeshPath();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();

        SetAnimation();
    }

    public void FootStepSound()
    {
        audioSource.PlayOneShot(footStepsAudioClip);
    }

    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit, 100, LayerMaskEnemys))
            {
                goToAttack = true;
                enemyTarget = raycastHit.transform.gameObject;
                navMeshAgent.SetDestination(raycastHit.collider.transform.position);
            }
            else if (Physics.Raycast(ray, out raycastHit, 100, LayerMaskIntect))
            {
                navMeshAgent.SetDestination(raycastHit.collider.transform.position + new Vector3(-1f, 0, 0));
            }
            else if (Physics.Raycast(ray, out raycastHit, 100, LayerMaskMovement))
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
