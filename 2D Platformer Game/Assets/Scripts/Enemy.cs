using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        //Particles and Animations
    }

    // Update is called once per frame
    void Update()
    {
        if(health <- 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy has perished!");
        }
        
    }

    public void TakeDamage(int damage)
    {
        health -=  damage; //Damage is take out of health

        Debug.Log(damage + " Damage Taken!");
    }
}
