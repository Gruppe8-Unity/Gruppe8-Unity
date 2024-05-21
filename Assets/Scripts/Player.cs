using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public Transform playerTransform;

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
        Vector2 movementDirection = new Vector2(movementX, movementY);
        playerTransform.Translate(movementDirection);
    }
}
