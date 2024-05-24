public class VictorBackgroundScroller : ScrollerController
{
    void Start()
    {
        BeginScroll();
        FindObjectOfType<AudioManager>().Play("VictoryMenuSound");
    }
    
    void Update()
    {
        UpdateScroll();
    }
}
