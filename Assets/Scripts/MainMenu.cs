using System.Collections;
using UnityEngine;

public class MainMenu : Menu
{
    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("PlaySound");
        StartCoroutine(ReturnToScene(0.4f, "SampleScene")); 
    }
    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("QuitSound");
        StartCoroutine(ExitGame(0.4f));  
        
    }
    private IEnumerator ExitGame(float delayInSeconds)
    {
        yield return StartCoroutine(ShortDelay(delayInSeconds));
        Application.Quit();
    }
}