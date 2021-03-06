
using UnityEngine;

public class Granade : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;
    public float countdown;
    bool hasExploded = false;
    public GameObject explotionEffect;
    void Start()
    {
        countdown = delay;
        
    }
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }

        
    }

 
    void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
            GameObject effect = Instantiate(explotionEffect, transform.position, transform.rotation);
            Destroy(effect,0.1f);
            Destroy(gameObject);
        }
    }
}
