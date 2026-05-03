using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float provokeRange = 5f;
    [SerializeField] float speed = 1f;
    Animator anim;
    NavMeshAgent agent;
    EnemyHealth health;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        CheckHealth();
        SeekAndDestroy();
    }

    private void CheckHealth()
    {
        if (health.IsDead)
        {
            enabled = false;
            agent.enabled = false;
        }
    }

    private void SeekAndDestroy()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget(distanceToTarget);
        }
        else if (distanceToTarget <= provokeRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget(float distanceToTarget)
    {
        FaceTarget();
        if (distanceToTarget >= agent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= agent.stoppingDistance)
        {
            AttackTarget();
        }
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
    }
    private void ChaseTarget()
    {
        agent.SetDestination(target.position);
        anim.SetTrigger("Move");
    }

    private void AttackTarget()
    {
        anim.SetTrigger("Attack");
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, provokeRange);
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }
}
