using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 25;

    public float xRange = 35;

    public Transform blaster;
    public GameObject lazerBolt;
    // public Transform blasterL;
    // public GameObject lazerBoltL;
    // public Transform blasterR;
    // public GameObject lazerBoltR;
    // bool powerL = true;
    // bool powerR = true;
    private AudioSource blasterAudio;
    public AudioClip laserBlast;

    void Start()
    {
        // get audiosource component
        blasterAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set Horizantal Input to recive values form keyboard
        horizontalInput = Input.GetAxis("Horizontal");

        // Moves player left and right
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        // keep player with in bounds 
        //Left side
        if(transform.position.x < -xRange )
        {
            transform.position = new Vector3(-xRange,transform.position.y, transform.position.z);
        }
        // (Right side)
        if(transform.position.x > xRange )
        {
            transform.position = new Vector3(xRange,transform.position.y, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
        blasterAudio.PlayOneShot(laserBlast,1.0f);
        //create laserBolt at the blaster transform position mainting the objects rotation
            Instantiate(lazerBolt, blaster.position, lazerBolt.transform.rotation);
        }

         /* if(powerL = true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
            Instantiate(lazerBolt, blasterL.position, lazerBoltL.Transform.rotation);
            }
        }
        if(powerR = true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
            Instantiate(lazerBolt, blasterR.position, lazerBoltR.Transform.rotation);
            }
        */
    }

    // Delete any object with a trigger that hits the player
     private void OntriggerEnter(Collider other)
     {
        Destroy(other.gameObject);
     }
} 