using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenuScroller : MonoBehaviour
{
    public void ReturnToMainButton()
    {
        FindObjectOfType<AudioManager>().Play("MainMenuButton");
        StartCoroutine(ReturnToMain(0.4f)); 
    }

    private IEnumerator ReturnToMain(float delayInSeconds)
    {
        yield return StartCoroutine(ShortDelay(delayInSeconds));
        SceneManager.LoadScene("StartMenu");
    }
    
    IEnumerator ShortDelay(float delayInSeconds)
    {
        float timer = 0f;
        float targetTime = delayInSeconds;

        while (timer < targetTime)
        {
            timer += Time.unscaledDeltaTime; 
            yield return null;
        }
    }
}