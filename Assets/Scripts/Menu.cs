using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Menu : MonoBehaviour
{
    public IEnumerator ReturnToScene(float delayInSeconds, string scene)
    {
        yield return StartCoroutine(ShortDelay(delayInSeconds));
        SceneManager.LoadScene(scene);
    }
    
    public IEnumerator ShortDelay(float delayInSeconds)
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
