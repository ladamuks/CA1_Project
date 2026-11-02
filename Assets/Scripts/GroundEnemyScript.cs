using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //got this code from: -https://www.youtube.com/watch?v=NZnQ8rw5xjc
    //-https://github.com/DevUrf/2D-Unity-Enemy-AI/blob/main/Enemy.cs

    [SerializeField] private float walkTime;
    [SerializeField] private float idleTime;
    [SerializeField] private PlayerScore score;
    private float elapsedTime;
    private int direction = 1;
    private bool isRunning = false;
    private Rigidbody2D rb;
    private Animator animator;

    public int health;
    private int points = 2;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetInteger("Direction", direction);
        animator.SetFloat("Move", 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning && elapsedTime < walkTime)
        {
            Vector2 position = rb.transform.position;
            position.x += direction * Time.deltaTime;
            rb.transform.position = position;
        }
        else if (!isRunning && elapsedTime > idleTime)
        {
            isRunning = true;
            elapsedTime = 0;
            direction *= -1;
            animator.SetInteger("Direction", direction);
            animator.SetFloat("Move", direction);
        }
        else if (isRunning && elapsedTime > walkTime)
        {
            isRunning = false;
            elapsedTime = 0;
            animator.SetFloat("Move", 0);
        }
        elapsedTime += Time.deltaTime;
    }

    public void TakeDamageEnemy(int damage) 
    {
        health -= damage;
        if (health <= 0) 
        {
            score.AddPoints(points);
            Destroy(gameObject);
        }
    }

}
