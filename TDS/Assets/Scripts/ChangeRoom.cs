using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public Vector3 camPos;
    public Vector3 playerChanchePos;
    private Camera cam;

    void Start()
    {
        cam = Camera.main.GetComponent<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position += playerChanchePos;
            cam.transform.position += camPos;
        }
    }
}