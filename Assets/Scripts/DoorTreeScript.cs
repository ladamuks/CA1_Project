using UnityEngine;

public class DoorTreeScript : MonoBehaviour
{
    [SerializeField] private PlayerScore playerScore;
    [SerializeField] private GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Update()
    {
        if (gm.totalScore == 0)
        {
            gm.NextLevel();
            Destroy(gameObject);
        }
    }
}
