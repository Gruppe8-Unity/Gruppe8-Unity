using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAxe : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D axeRigidBody;
    public Vector2 throwDirection = new Vector2(0.2f, 1f);
    public float axeLifeTime = 5f;
    
    void Start()
    {
        DetermineAxeVelocity();
    }

    void Update()
    {
        DetermineIfAxeDestroy();
        DecrementAxeLifeTime();
    }

    void DetermineAxeVelocity()
    {
        Vector2 normalizedDirection = DetermineAxeDirectionNormalized();
        axeRigidBody.velocity = normalizedDirection * speed;
    }

    Vector2 DetermineAxeDirectionNormalized()
    {
        return throwDirection.normalized;
    }

    void DetermineIfAxeDestroy()
    {
        if (axeLifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    void DecrementAxeLifeTime()
    {
        axeLifeTime -= Time.deltaTime;
    }
    
}
