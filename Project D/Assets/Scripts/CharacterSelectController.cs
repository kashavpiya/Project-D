using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectController : MonoBehaviour
{
 

    public void SelectCharacter()
    {
        int selectedChar =
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameManager.instance.CharIndex = selectedChar;

        StartCoroutine(DelaySelect());

        
    }

    IEnumerator DelaySelect()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Gameplay");
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
}
