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
        StartCoroutine(DelayButtonPlayGame());
        
    }

    IEnumerator DelayButtonPlayGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("CharacterSelect");
    }
    

    public void goHome()
    {
        StartCoroutine(DelayButtonGoHome());
        
    }

    IEnumerator DelayButtonGoHome()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }

    public void exitGame()
    {
        StartCoroutine(DelayQuitting());
        
    }

    IEnumerator DelayQuitting()
    {
        yield return new WaitForSeconds(1);
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
