using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = -30.0f;
    public int damage = 1; 
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        //get rigidbody component
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        
        rb.velocity = transform.right * speed * Time.deltaTime; // this line of code adds velocity and makes the gameobject move forward

    }

    // Detect any collision and triggers
    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if(other.gameObject.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage); // Run tthe TakeDamage function and apply damage to enemy
            Destroy(gameObject); // Destroy Projectile
        }

        if(other.gameObject.CompareTag("Player"))
    {
        // Change the direction of the projectile if it hits the player
        speed *= -1;
    }
        
    }

}
