using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entities.Enemy;
using Menus.InGame;

namespace Entities.Player
{
    public class PlayerControll : MonoBehaviour
    {

        [Header("Movement")]
        public LayerMask LayerMaskMovement;
        public GameObject targetEllement;
        public GameObject invalidTargetEllement;
        public AudioClip footStepsAudioClip;

        [Header("Interact")]
        public LayerMask LayerMaskIntect;
        public GameObject intetactTarget;
        public bool InInteraction;

        private bool goToInteract;

        [Header("Combat")]
        public LayerMask LayerMaskEnemys;
        public GameObject enemyTarget;

        private bool goToAttack;

        private AudioSource audioSource;
        private NavMeshAgent navMeshAgent;
        private NavMeshPath meshPath;
        private Animator animator;
        private GameObject lastTargetEllement;

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

        public void CombatAction(Collider collider)
        {
            navMeshAgent.SetDestination(gameObject.transform.position);

            TurnToEnemy(collider);

            goToAttack = true;

            Attack();
        }

        public void InteractAction()
        {
            if (goToInteract)
            {
                intetactTarget.GetComponent<IInteractMenu>().ActiveMenu(true);
                StopPlayer();
                InInteraction = true;
                goToInteract = false;
            }
        }

        public void StopPlayer()
        {
            navMeshAgent.SetDestination(gameObject.transform.position);
        }

        public void DeliveryDamage()
        {
            GameObject player = GameObject.FindWithTag("Player");
            GameObject enemy = player.GetComponent<PlayerControll>().enemyTarget;

            if (enemy != null)
                enemy.GetComponent<EnemyStatus>().TakeDamage(player.GetComponent<PlayerStatus>().Damage);
            else
                player.GetComponent<PlayerControll>().animator.SetBool("Attack", false);
        }

        void TurnToEnemy(Collider collider)
        {
            var targetRotation = Quaternion.LookRotation(collider.transform.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
        }

        bool CheckIfEnemyIsLife()
        {
            return (this.enemyTarget == null) ?
                false : true;
        }

        void StopAttack()
        {
            PlayerControll player = GameObject.FindWithTag("Player").GetComponent<PlayerControll>();

            if (!player.CheckIfEnemyIsLife())
                player.animator.SetBool("Attack", false);
        }

        void Attack()
        {
            if (goToAttack)
            {
                if (!animator.GetBool("Attack"))
                    animator.SetBool("Attack", true);

                if (enemyTarget == null)
                    goToAttack = false;
            }
            else
            {
                if (animator.GetBool("Attack"))
                    animator.SetBool("Attack", false);
            }
        }

        
        void Movement()
        {
            if (!InInteraction)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit raycastHit;

                    if (Physics.Raycast(ray, out raycastHit, 100, LayerMaskEnemys))
                    {
                        if (lastTargetEllement != null)
                            Destroy(lastTargetEllement);

                        enemyTarget = raycastHit.transform.gameObject;
                        navMeshAgent.SetDestination(raycastHit.collider.transform.position);
                    }
                    else if (Physics.Raycast(ray, out raycastHit, 100, LayerMaskIntect))
                    {
                        goToInteract = true;
                        goToAttack = false;
                        Attack();
                        enemyTarget = null;

                        intetactTarget = raycastHit.transform.gameObject;

                        if (lastTargetEllement != null)
                            Destroy(lastTargetEllement);

                        navMeshAgent.SetDestination(raycastHit.collider.transform.position);
                    }
                    else if (Physics.Raycast(ray, out raycastHit, 100, LayerMaskMovement))
                    {
                        goToAttack = false;
                        Attack();
                        enemyTarget = null;

                        if (CalculateNewPath(raycastHit))
                        {
                            navMeshAgent.SetDestination(raycastHit.point);
                            lastTargetEllement = Instantiate(targetEllement, raycastHit.point, targetEllement.transform.rotation);
                        }
                        else
                        {
                            lastTargetEllement = Instantiate(invalidTargetEllement, raycastHit.point, invalidTargetEllement.transform.rotation);
                        }
                    }
                }
            }
        }

        bool CalculateNewPath(RaycastHit hit)
        {
            navMeshAgent.CalculatePath(hit.point, meshPath);
            return (meshPath.status != NavMeshPathStatus.PathComplete) ?
                false : true;
        }

        void SetAnimation()
        {
            if (navMeshAgent.remainingDistance > 0.5f)
            {
                if (!animator.GetBool("Walk")) // realizar testes de performace
                    animator.SetBool("Walk", true);
            }
            else
            {
                if (animator.GetBool("Walk"))
                    animator.SetBool("Walk", false);
            }
        }
    }
}
