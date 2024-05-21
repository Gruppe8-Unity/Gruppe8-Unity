using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public Transform playerTransform;
    public Animator playerAnimator;

    private void Start()
    {
        // Get transform of associated gameobject
        playerTransform = GetComponent<Transform>();
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
}
