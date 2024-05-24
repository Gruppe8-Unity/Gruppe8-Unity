public class VictoryMenuScroller : Menu
{
    public void ReturnToMainButton()
    {
        FindObjectOfType<AudioManager>().Play("MainMenuButton");
        StartCoroutine(ReturnToScene(0.4f, "StartMenu")); 
    }
}