using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHealthAndTakeDamage : MonoBehaviour

{
    public float health;
    private ScoreManager sm;
    private EnemySpawner es;
    public float healthIncrease;
    public GameObject ShowDamage;
    public Transform DropHealth;
    public Transform DropKey;


    private void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
        es = FindObjectOfType<EnemySpawner>();
    }
    private void Update()
    {
        health += Time.deltaTime * healthIncrease;
        if (health <= 0)
        {
            sm.Kill();
            es.EnemyCounter--;
            Destroy(gameObject);
            if (Random.Range (0, 100) < 25) {
                Instantiate(DropHealth, new Vector3(transform.position.x, transform.position.y,transform.position.z), Quaternion.identity);
            }else if (Random.Range (0, 100) < 100)
            {
                Instantiate(DropKey, new Vector3(transform.position.x, transform.position.y,transform.position.z), Quaternion.identity);
            }
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




