using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class Player : UIScript
{
    public float movementSpeed = 10.0f;
    public Transform playerTransform;
    public Animator playerAnimator;
    public float currentPlayerHealth;
    public float maxPlayerHealth = 100;

    private float _damageInterval = 1.0f;
    private float _lastDamageTime;

    private void Start()
    {
        // Get transform of associated gameobject
        playerTransform = GetComponent<Transform>();
        currentPlayerHealth = maxPlayerHealth;
    }

    void Update()
    {
        float verticalMovement = 0.0f;
        float horizontalMovement = 0.0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalMovement = 1.0f;

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalMovement = -1.0f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalMovement = 1.0f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalMovement = -1.0f;
        }

        // Scaled movement in x and y directions
        float movementX = movementSpeed * horizontalMovement * Time.deltaTime;
        float movementY = movementSpeed * verticalMovement * Time.deltaTime;

        // Set animator params
        playerAnimator.SetFloat("DirectionY", verticalMovement);
        playerAnimator.SetFloat("DirectionX", horizontalMovement);

        // Stores the size (speed) of the vector
        float vectorMagnitude = Mathf.Sqrt(Mathf.Pow(horizontalMovement, 2) + Mathf.Pow(verticalMovement, 2));
        playerAnimator.SetFloat("MovementSpeed", vectorMagnitude);

        Vector2 movementDirection = new Vector2(movementX, movementY);
        playerTransform.Translate(movementDirection);
        

    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time > _lastDamageTime + _damageInterval)
        {
            TakeDamage(1);
            _lastDamageTime = Time.time;
        }
    }

    public void TakeDamage(int damage)
    {
        currentPlayerHealth -= damage;
    }
}
