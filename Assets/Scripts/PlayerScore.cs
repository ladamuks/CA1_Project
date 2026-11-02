using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerScore : MonoBehaviour
{

    [SerializeField] private GameManager gm;
    public void AddPoints(int amount) 
    {
        gm.UpdateScore(amount);
    }
}
