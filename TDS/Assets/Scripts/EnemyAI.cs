using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float speed;

    public float timeBtwShots;
    public float StartTimeBtwShots;


    public GameObject projectile;
    private Transform target;
    private NavMeshAgent agent;

    public float dist;
    public float radius = 15;




    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        dist = Vector3.Distance(target.transform.position, transform.position);


        if (dist > radius)
        {
            agent.SetDestination(transform.position);
        }

        if (dist < radius)
        {
            agent.SetDestination(target.position);
        }

        if (timeBtwShots <= 0 && dist < radius)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = StartTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
      
    }
}