using UnityEngine;

public class DeathMenuScroller : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;

    private float offset;
    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        FindObjectOfType<AudioManager>().Play("DeathMenuSound");
    }
    
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
