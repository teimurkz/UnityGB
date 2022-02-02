using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float distance;
    public int damage;
    public LayerMask WhatIsSolid;
    public float speed;
    
    void OnCollisionEnter2D (Collision2D collision)
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.up,distance,WhatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyHealthAndTakeDamage>().TakeDamage(damage);
            }
        }
        GameObject effect = Instantiate(hitEffect,transform.position, Quaternion.identity);
        Destroy(effect,0.1f);
        Destroy(gameObject);

        }
    
}
