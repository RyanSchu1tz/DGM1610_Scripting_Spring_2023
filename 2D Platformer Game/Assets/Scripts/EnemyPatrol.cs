using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Enemy Move Stats")]
    public float speed; // how fast the enemy moves
    public float rayDistance; // how far the ray extends

    private bool isMovingRight = true; // is the enemy moving right

    public Transform groundDetection; // is the enemy touching ground


    // update
    void Update()
    {
        // Move the enemy to the right
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Raycasting 0 produce a ray from an origin point in a certain direction with a set distance
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDistance);

        if(groundInfo.collider == false)
        {
            if(isMovingRight == true)
            {
                //flip enemy at edge to move left
                transform.eulerAngles = new Vector3(0, -180, 0);
                isMovingRight = false;
            }
            else
            {
                // flip enemy at edge to move right
                transform.eulerAngles = new Vector3(0,0,0);
                isMovingRight = true;
            }
        }
    }

}
