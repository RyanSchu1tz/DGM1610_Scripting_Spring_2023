using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth = 10;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; //reset time back to real Time
        currentHealth = maxHealth; // set currentHealth to max Health
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
