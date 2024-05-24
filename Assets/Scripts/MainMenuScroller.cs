public class MainMenuScroller : ScrollerController
{
    void Start()
    {
        BeginScroll();
        FindObjectOfType<AudioManager>().Play("MenuSound");
    }
    
    void Update()
    {
        UpdateScroll();
    }
}
