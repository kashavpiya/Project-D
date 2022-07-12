using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public void goHome()
    {
        StartCoroutine(DelayButtonGoHome());

    }

    IEnumerator DelayButtonGoHome()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }

    public void retry()
    {
        StartCoroutine(DelayRetry());   
    }

    IEnumerator DelayRetry()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Gameplay");
    }
}
