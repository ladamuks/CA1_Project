using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //code used: -https://www.youtube.com/watch?v=B40xBPXK97A
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Play() 
    {
        SceneManager.LoadScene("CA1_ProjectRecovery");
    }
}
