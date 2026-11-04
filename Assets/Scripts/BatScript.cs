using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class BatScript : MonoBehaviour
{
    public float flySpeed = 10f;
    public PlayerScript playerScript;
    private Rigidbody2D rb;
    private Vector2 move;
    private int direction = 1;
    private Animator animator;
    public Sprite batSprite;
    public Sprite playerSprite;
    private SpriteRenderer spriteRenderer;
    public bool isBat = false;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        gameObject.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        move = InputSystem.actions["Move"].ReadValue<Vector2>();

        if (move.x != 0 || move.y != 0)
        {
            if (move.x != 0) 
            {
                direction = move.x < 0 ? -1 : 1;
                animator.SetInteger("isLeft", direction);
            }
        }
        
    }

    public void TransformBat() 
    {
        transform.position = playerScript.transform.position; //gets the last position the player was at
        isBat = true;
        gameObject.SetActive(true);
        spriteRenderer.sprite = batSprite; //changes to the bat sprite

        animator.SetInteger("isLeft", direction);
    }

    public void TransformPlayer() 
    {
        isBat = false;
        gameObject.SetActive(false);
        playerScript.PlayerOut();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            TransformPlayer();
        }
    }

    public void Respawn()
    {
        transform.position = startPos;
    }

    void FixedUpdate()
    {
        Vector2 position = rb.transform.position;
        position.x += (move.x * flySpeed) * Time.fixedDeltaTime;
        position.y += (move.y * flySpeed) * Time.fixedDeltaTime;
        rb.transform.position = position;
    }
}