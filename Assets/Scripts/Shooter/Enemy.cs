using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float stoppingDistance;

    NavMeshAgent agent;

    GameObject target;

    private Animator animator;
    private float health;


    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        health = 50;
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

    public void TakeDamage(int amount) {
        health -= amount;
        if (health <= 0f) {
            Die();
        }

    }
    void Die() {
        Destroy(gameObject);
    }
}
