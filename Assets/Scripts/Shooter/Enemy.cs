using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float stoppingDistance;

    NavMeshAgent agent;

    GameObject target;
    public float health = 100f;

    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < stoppingDistance)
        {
            animator.SetBool("IsMoving", false);
            StopEnemy();
            //target.GetComponent<CharacterStats>;
        }
        else
        {
            animator.SetBool("IsMoving", true);
            GoToTarget();
        }
        GoToTarget();
    }

    private void GoToTarget()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
    }

    private void StopEnemy()
    {
        agent.isStopped = true;
    }
    private void OnCollisionEnter(Collision coll)
    {
        
        if (coll.collider.CompareTag("Bullet")) {
            health -= 20f;
            if (health < 1)
            {
                Destroy(this);
            }
        }
    }
}
