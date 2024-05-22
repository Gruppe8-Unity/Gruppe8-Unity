using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpirit : Weapon
{
    
    public Rigidbody2D rb;
    
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Enemy")
        {
            Debug.Log(hitInfo.name);
            Destroy(hitInfo.gameObject);
        }
    }
    
}
