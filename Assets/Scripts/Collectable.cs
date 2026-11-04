using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private PlayerScore score;
    public int direction = 1;
    private float height = 1;
    private int points = 1;
    private float timePassed = 0;
    void Update()
    {
        Vector2 position = transform.position;
        position.y += (height * Time.deltaTime * direction);
        transform.position = position;

        timePassed += Time.deltaTime;
        if (timePassed > 2)
        {
            timePassed = 0;
            direction *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Bat"))
        {
            if (score != null) 
            { 
                score.RemovePoints(points); 
            }
            Destroy(gameObject);
        }
    }
}