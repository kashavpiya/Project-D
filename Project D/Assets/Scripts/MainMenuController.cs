using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private float highScoreCount;
    public Text highScoreText;

    public void PlayGame()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    

    public void goHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        {
            if (PlayerPrefs.HasKey("HighScore"))
            {
                highScoreCount = PlayerPrefs.GetFloat("HighScore");
            }
        }
    }

    void Update()
    {
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
    }
    
}
