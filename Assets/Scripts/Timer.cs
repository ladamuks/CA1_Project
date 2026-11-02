using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //code used: -https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/

    public float timeRemaining = 180f;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private GameManager gm;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private BatScript bat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else 
        {
            //when timer runs out the player will lose a life
            playerHealth.TakeDamagePlayer(40);

            if (playerHealth.health > 0)
            {
                playerHealth.Respawn();
                bat.Respawn();
            }

            //reset timer
            if (playerHealth.health > 20 && playerHealth.health < 100)
            {
                timeRemaining = 120f;
            }
            if (playerHealth.health > 0) 
            {
                timeRemaining = 60f;
            }
        }
    }

    void DisplayTime(float timeToDisplay) 
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
