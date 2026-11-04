using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //code i used: -https://www.youtube.com/watch?v=KF3EVjOhN4c
    public int maxHealth = 100;
    public int health;
    [SerializeField] private GameManager gm;
    private Vector3 startPos; //keeps the original position of the player

    void Start()
    {
        startPos = transform.position; //saves the original position of player
        health = maxHealth;
        gm.UpdateHearts(health);
    }

    public void TakeDamagePlayer(int damage) 
    {
        health -= damage;
        gm.UpdateHearts(health);
    }

    public void Respawn() 
    {
        transform.position = startPos; //after timer runs out the player is transported back to original pos
    }

}
