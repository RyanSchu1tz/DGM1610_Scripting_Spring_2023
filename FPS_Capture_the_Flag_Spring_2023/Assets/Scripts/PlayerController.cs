using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Stats")]
    public float moveSpeed;
    public float jumpForce;

    public int curHp;
    public int maxHP;

    [Header("Mouse Look")]
    public float lookSensitivity;
    public float maxLookX;
    public float minLookX;
    private float rotX;

    private Camera camera;
    private Rigidbody rb;                               //Player Rigidbody referance
    //private Weapon weapon;                              //Weapon reference

    void Awake()
    {
        //weapon = Getcomponet<Weapon>();
        curHp = maxHP;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Get Components
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
        
        /* Initialize the UI
        GameUI.instance.UpdateHealthBar(curHp, maxHp);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);  */
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // Move direction relative to the camera
        Vector3 dir = transform.right * x + transform.forward * z;

        dir.y = rb.velocity.y; 
        rb.velocity = dir;  //Apply force in relation to the camera
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }


    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
        {
            // Add force to Jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    //Applies Damage to the Player
    public void TakeDamage(int damage)
    {
        curHp -= damage;

        if(curHp <= 0)
            Die();

        //GameUI.Instance.UpdateHealthBar(curHp, maxHp);
    }

    // If player health is reduced to zero or below then run die()
    void Die()
    {
        //GameManager.Instance.LoseGame();
        Debug.Log("Player has died! Game Over!");
        Time.timeScale = 0;
    }
    public void GiveHealth(int amountToGive)
    {
        //curHp = mathf.Clamp(curHp + amountToGive, 0, maxHp);
        //GameUI.Instance.UpdateHealthBar(curHp, maxHp);
        Debug.Log("Player has been healed!");
    }

    public void GiveAmmo(int amountToGive)
    {
        //weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        //GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
        Debug.Log("Player has collected ammo!");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();

        /* Fire Button
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
              weapon.Shoot();
        } */


        // Jump Button
        if(Input.GetButtonDown("Jump"))
            Jump();

        /* Don't do anything is the game is pause
        if(GameManager.instance.gamePaused == true)
            return */
    }
}
