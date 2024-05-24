using UnityEngine;

public class BasicEnemy : Enemy
{
    public GameObject smallExpPrefab;
    
    private void Update()
    {
        DetermineEnemyRotation();
    }
    
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(collision.gameObject, 0.3f);
            FindObjectOfType<AudioManager>().Play("EnemyDeathSound");
            OnKilled(smallExpPrefab);
        }
        if(collision.gameObject.tag == "Spirit")
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("EnemyDeathSound");
            OnKilled(smallExpPrefab);
        }
        if(collision.gameObject.tag == "Axe")
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("EnemyDeathSound");
            OnKilled(smallExpPrefab);
        }
    }
}
