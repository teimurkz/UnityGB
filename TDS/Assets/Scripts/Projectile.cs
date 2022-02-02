using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    
    public GameObject hitEffect;
    public float distance;
    public int damage;
    public LayerMask WhatIsSolid;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.position, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
        
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.up,distance,WhatIsSolid);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    hitInfo.collider.GetComponent<PlayerTakeDamage>().TakeDamage(damage);
                }
            }
            GameObject effect = Instantiate(hitEffect,transform.position, Quaternion.identity);
            Destroy(effect,0.1f); 
            Destroy(gameObject);
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    
}
