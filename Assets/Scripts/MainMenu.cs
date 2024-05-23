using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("PlaySound");
        StartCoroutine(PlayGameWithDelay(0.4f)); 
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("QuitSound");
        StartCoroutine(QuitGameWithDelay(0.4f));  
    }
    
    IEnumerator PlayGameWithDelay(float delayInSeconds)
    {
        yield return StartCoroutine(ShortDelay(delayInSeconds));
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator QuitGameWithDelay(float delayInSeconds)
    {
        yield return StartCoroutine(ShortDelay(delayInSeconds));
        Application.Quit();
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