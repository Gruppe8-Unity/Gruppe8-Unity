using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArrow : Weapon
{

    public float speed = 20f;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Enemy")
        {
            Debug.Log(hitInfo.name);
            Destroy(gameObject);
            Destroy(hitInfo.gameObject);
        }

    }
    
}
