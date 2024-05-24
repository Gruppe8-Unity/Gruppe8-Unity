public class DeathMenuScroller : ScrollerController
{
    void Start()
    {
        BeginScroll();
        FindObjectOfType<AudioManager>().Play("DeathMenuSound");
    }
    
    void Update()
    {
        UpdateScroll();
    }
}
