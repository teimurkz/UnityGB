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
    public float heal;
    private void FixedUpdate()
    {
        if (health > numOfhearts)
        {
            health = numOfhearts;
        }
        health += Time.deltaTime * heal;

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

            if (health < 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
            
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
