using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public void goHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void retry()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
