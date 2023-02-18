using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); // Destroy self
        Destroy(other.gameObject); // Destroy object hit
    }
}
