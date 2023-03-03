using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    private ScoreManager scoreManager; // A variable to hole the reference to the scormanager
    public int scoreToGive;
    public ParticleSystem explosionParticle; // Store the particle System


    // Start is called before the first fram update
    void Start()
    {
           scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); //Reference scoreManager

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("LazerBolt"))
        {
            Destroy(gameObject); // Destroy this game object (UFO)
            Destroy(other.gameObject); //Destroy the other game object it hits
        }
        
    //Explosion();
    scoreManager.IncreaseScore(scoreToGive); // Increase Score
}     


    void Explosion()
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);
    }

}
