using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PickupType
    {
        Health,
        Ammo

    }

public class PickUp : MonoBehaviour
{
    public PickupType type;
    public int healthAmount;
    public int ammoAmount;

    [Header("Bobbing Motion")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHight;
    private bool bobbingUp;
    private Vector3 startPos;
    // Get audio for PickUp
    public AudioClip pickupSFX;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }



    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

          switch(type)
          {
                case PickupType.Health:
                player.GiveHealth(healthAmount);
                break;

                case PickupType.Ammo:
                player.GiveAmmo(ammoAmount);
                break;

                default:
                print("Type not accepted");
                break;
          }

          //Reference Audio Source to play sound effect
          //other.GetComponent<AudioSource>().PlayOneShot(pickupSFX);

          //Destroy PickUp
          Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Rotates the pickup around the y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHight / 2, 0) : new Vector3(0, -bobHight / 2, 0));

        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

        if(transform.position == startPos + offset)
            bobbingUp = !bobbingUp;
    }
}
