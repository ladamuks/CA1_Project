using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private GameManager gm;

    //removes points that are collected in game
    public void RemovePoints(int amount) 
    {
        gm.UpdateScore(amount);
    }
}
