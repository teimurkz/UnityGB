using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject granadePrefab;

    public float bulletForce = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Granade();
        }
    }

    void Shoot()
    {
        GameObject granade = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = granade.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void Granade()
    {
        GameObject granade = Instantiate(granadePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = granade.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}