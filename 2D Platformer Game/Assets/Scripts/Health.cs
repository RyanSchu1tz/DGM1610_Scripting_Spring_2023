using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // add the ui librart namespace

public class Health : MonoBehaviour
{

    public int maxHealth = 9;
    public int currentHealth;
    public int numberOfhearts; // number of hearts 
    public Image[] hearts; // numbr of hearts images in the ui
    public Sprite fullHeart; //full heart Sprite
    public Sprite emptyHeart; //empty heart sprite

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; //reset time back to real Time
        currentHealth = maxHealth; // set currentHealth to max Health
    }

    void update()
    {
        //currentHealth will not exceed max Health
        if(currentHealth > numberOfhearts)
        {
            currentHealth = numberOfhearts;
        }
        // populate hearts on Hub
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            
            if(i < numberOfhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public void TakeDamage(int dmgAmount)
    {
        currentHealth -= dmgAmount;
        Debug.Log("Player Health = "+ currentHealth);

        if(currentHealth <=0)
        {
            Debug.Log("You are dead! Game Over !");
            Time.timeScale = 0;
        }
    }

    public void AddHealth (int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
