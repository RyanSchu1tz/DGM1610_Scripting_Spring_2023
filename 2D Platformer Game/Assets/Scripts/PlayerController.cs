using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player Stats
    [Header("Player Stats")]
    public float speed; // how fast the player is going to move
    public float jumpForce; // How high the player will jump
    private float moveInput; // get move input value

    // Player Rigidbody
    [Header("Rigidbody Component")]
    private Rigidbody2D rb;
    private bool isFacingRight = true;

    //Player jump
    [Header("Player Jump Settings")]
    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public bool doubleJump;

    [Header("Animations")]
    private Animator playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        //Get rigidnody component reference
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>(); 
    }

    // Fixed Update is called a fixed or set number of frames. ...
    void FixedUpdate()
    {
        if(moveInput > 0 || moveInput < 0)
        {
            playerAnim.SetBool("isWalking", true);
        }
        else
        {
            playerAnim.SetBool("isWalking", false);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); // Define what is ground and when on ground

        moveInput = Input.GetAxis("Horizontal"); // Get the Horizontal keybinding, return value of -1 to 1
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        // if the player is moving right but facing left flip the player right
        if(!isFacingRight && moveInput > 0)
        {
            FlipPlayer();
        }
        // If the player is moving left but facing right flip the player left
        else if(isFacingRight && moveInput < 0)
        {
            FlipPlayer();
        }

    }

    void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale; //Local variable that stores local sclae value
        scaler.x *= -1; //  Flip the sprite graphic
        transform.localScale = scaler;

    }

    // Update is called once per frame. ...

    void Update()
    {   
        if(isGrounded)
        {
            doubleJump = true;
        }

        if(Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
            rb.velocity = Vector2.up * jumpForce; // makes the player jumo
            doubleJump = false;
            playerAnim.SetTrigger("Jump_Trig");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;// Apply jumpForce to player making the player jump
            playerAnim.SetTrigger("Jump_Trig");
        }
    }

}
