using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAxe : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D axeRigidBody;
    public Vector2 throwDirection = new Vector2(0.2f, 1f);
    void Start()
    {
        Vector2 normalizedDirection = throwDirection.normalized;
        axeRigidBody.velocity = normalizedDirection * speed;
    }
    


    
}
