using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Image[] images;
    [SerializeField] private MusicManager music;
    public int totalScore = 27 + 55 + 18;
    void Start()
    {
        levelText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        UpdateScore(0);
        UpdateLives(3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int amount)
    {
        totalScore -= amount;

        if (scoreText != null)
        {
            scoreText.text = totalScore.ToString();
        }
    }

    public void UpdateLives(int lives)
    {
        switch (lives)
        {
            case 0:
                images[0].enabled = false;
                images[1].enabled = false;
                images[2].enabled = false;
                break;
            case 1:
                images[0].enabled = false;
                images[1].enabled = false;
                images[2].enabled = true;
                break;
            case 2:
                images[0].enabled = false;
                images[1].enabled = true;
                images[2].enabled = true;
                break;
            case 3:
                images[0].enabled = true;
                images[1].enabled = true;
                images[2].enabled = true;
                break;
        }
    }

    public void GameOver() 
    {
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0f; //pauses the game
        music.StopPlaying();
    }

    public void NextLevel() 
    {
        levelText.gameObject.SetActive(true);
    }

    public void UpdateHearts(int health)
    {
        if (health > 60)
        {
            UpdateLives(3);
        }
        else if (health > 20)
        {
            UpdateLives(2);
        }
        else if (health > 0)
        {
            UpdateLives(1);
        }
        else 
        {
            UpdateLives(0);
            GameOver();
        }
    }
}