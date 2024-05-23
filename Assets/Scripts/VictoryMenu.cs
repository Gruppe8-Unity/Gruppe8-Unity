using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenuScroller : Menu
{
    public void ReturnToMainButton()
    {
        FindObjectOfType<AudioManager>().Play("MainMenuButton");
        StartCoroutine(ReturnToScene(0.4f, "StartMenu")); 
    }
}