using Mono.Cecil;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerScript : MonoBehaviour
{
    public int speed = 2;
    public int health = 100;
    public BatScript batScript;
    private Vector2 move;
    private Rigidbody2D rb;
    private int direction = 1;
    private Animator animator;
    public float jumpHeight = 2.4f;
    private int jumpCount = 0;
    private bool canJump = true; //checks if the player can Jump
    private Vector2 lastPosition;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastPosition = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move = InputSystem.actions["Move"].ReadValue<Vector2>();

        //checks each jump frame, IsPressed is always true
        if (InputSystem.actions["Jump"].WasPressedThisFrame() && canJump)
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(new Vector2(0, Mathf.Sqrt(-2 * Physics2D.gravity.y * jumpHeight)), ForceMode2D.Impulse);
            jumpCount++;

            if (jumpCount >= 2)
            {
                canJump = false;
                batScript.TransformBat();
                gameObject.SetActive(false);
            }

            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        if (move.x != 0)
        {
            direction = move.x < 0 ? -1 : 1;
            animator.SetInteger("isLeft", direction);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    public void PlayerOut() 
    {
        transform.position = batScript.transform.position;
        gameObject.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            canJump = true;
            animator.SetBool("isJumping", false);
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rb.transform.position;
        position.x += (move.x * speed) * Time.fixedDeltaTime;
        rb.transform.position = position;
    }
}
