
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float speed;

    public float timeBtwShots;
    public float startTimeBtwShots;


    public GameObject projectile;
    public  Transform target;
    public NavMeshAgent agent;

    public float dist;
    public float radius = 15;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
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
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
    }

  
}