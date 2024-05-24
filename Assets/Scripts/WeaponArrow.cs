using UnityEngine;

public class WeaponArrow : Weapon
{

    public float speed = 20f;
    public Rigidbody2D arrowRigidBody;
    public float arrowTimer = 5f;
    
    void Start()
    {
        arrowRigidBody.velocity = transform.right * speed;
    }

    private void Update()
    {
        DetermineWeaponDestroy(arrowTimer);
        arrowTimer = DecrementWeaponLifeTime(arrowTimer);
    }
    
}
