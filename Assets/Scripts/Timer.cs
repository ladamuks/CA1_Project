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

            //reset timer: timer goes down by 1 minute each death
            if (playerHealth.health > 20 && playerHealth.health < 100)
            {
                timeRemaining = 120f;
            }
            else
            {
                timeRemaining = 60f;
            }
        }
    }

    //displays the timer on screen in format
    void DisplayTime(float timeToDisplay) 
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
