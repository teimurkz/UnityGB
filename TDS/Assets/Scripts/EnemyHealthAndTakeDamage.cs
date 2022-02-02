using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthAndTakeDamage : MonoBehaviour

{
    public float health;
    private ScoreManager sm;
    public float healthIncrease;
    public GameObject ShowDamage;


    private void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
    }
    private void Update()
    {
        health += Time.deltaTime * healthIncrease;
        if (health <= 0)
        {
            sm.Kill();
            Destroy(gameObject);
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        Vector2 damagePos = new Vector2(transform.position.x, transform.position.y + 4f);
        GameObject delete  = Instantiate(ShowDamage , damagePos,Quaternion.identity);
        Destroy(delete,1f);
        ShowDamage.GetComponentInChildren<ShowDamage>().damage = damage;
    }

}
