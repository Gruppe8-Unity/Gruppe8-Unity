using UnityEngine;

public abstract class ScrollerController : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;

    private float offset;
    private Material mat;
    
    public void BeginScroll()
    {
        mat = GetComponent<Renderer>().material;
    }
    
    public void UpdateScroll()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
