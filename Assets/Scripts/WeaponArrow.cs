using UnityEngine;

public class WeaponArrow : Weapon
{

    public float speed = 20f;
    public Rigidbody2D arrowRigidBody;
    public float arrowTimer = 5;
    
    void Start()
    {
        arrowRigidBody.velocity = transform.right * speed;
    }

    private void Update()
    {
        if(arrowTimer < 0)
        {
            Destroy(gameObject); // To keep arrows from existing forever.
        }
        arrowTimer -= Time.deltaTime;
    }

    //void OnTriggerEnter2D(Collider2D hitInfo)
    //{
    //    if (hitInfo.gameObject.tag == "Enemy")
    //    {
    //        Destroy(gameObject);
    //        Destroy(hitInfo.gameObject);
    //    }

    //}
    
}
