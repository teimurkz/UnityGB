using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTakeDamage : MonoBehaviour
{
    public float health;
    public int numOfhearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite EmptyHeart;

    public GameObject KeyIcon;
    private bool KeyButtonPushed;


    private void FixedUpdate()
    {
        if (health > numOfhearts)
        {
            health = numOfhearts;
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }

            if (i < numOfhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

           
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (health < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void OnKeyButtonDown()
    {
        KeyButtonPushed = !KeyButtonPushed;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Door") && KeyButtonPushed && KeyIcon.activeInHierarchy)
        {
            KeyIcon.SetActive(false);
            other.gameObject.SetActive(false);
            KeyButtonPushed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Health"))
        {
            ChangeHealth(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Key"))
        {
            KeyIcon.SetActive(true);
            Destroy(other.gameObject);
        }

    }

    public void ChangeHealth(int healthValue)
    {
        health += healthValue;
    }
}
