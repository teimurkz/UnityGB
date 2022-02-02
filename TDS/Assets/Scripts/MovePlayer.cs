using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _movement;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mousePosition;


    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        mousePosition =  cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
       rb.MovePosition(rb.position + _movement * _speed * Time.fixedDeltaTime);
       Vector2 lookDir = mousePosition - rb.position;
       float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
       rb.rotation = angle;
    }
}
