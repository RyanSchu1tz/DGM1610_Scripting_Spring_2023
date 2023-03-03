using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBounds =30.0f;
    public float lowerBounds = -20.0f;
    public ScoreManager scoreManager; // Reference the score manager so that we can update the score
    private DetectCollision detectCollision;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); // Getting the component scoremanager.
        detectCollision = GetComponent<DetectCollision>(); // Getting the component DetectCollision
    }


    void Awake()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBounds)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < lowerBounds)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
            //Time.timescale = 0;
        }
    }
}
