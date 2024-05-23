using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : Enemy
{
    private float movementSpeed = 2;
    private float rotationSpeed = 1000;
    private float enemyAwarenessDistance = 50;

    public Vector2 DirectionToPlayer { get; private set; }

    private Rigidbody2D playerRigidBody;
    private Transform playerTransform;
    public GameObject expPrefab;
    public Transform expDropPoint;

    private void Awake()
    {
        playerTransform = FindObjectOfType<Player>().transform;
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 enemyToPlayerVector = playerTransform.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= enemyAwarenessDistance)
        {
            RotateEnemy(true);
            SetVelocity();
        }
        else
        {
            RotateEnemy(false);
            SetVelocity();
        }

    }
    private void RotateEnemy(bool towardsPlayer)
    {
        if (towardsPlayer)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, DirectionToPlayer);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            playerRigidBody.SetRotation(rotation);
        }

    }
    private void SetVelocity()
    {
        if (DirectionToPlayer == Vector2.zero)
        {
            playerRigidBody.velocity = Vector2.zero;
        }
        else
        {
            playerRigidBody.velocity = transform.up * movementSpeed;
        }
    }

    void OnKilled()
    {
        Instantiate(expPrefab, expDropPoint.position, Quaternion.Euler(0, 0, 0));
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SmallExp")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Weapon")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            OnKilled();
        }
        if(collision.gameObject.tag == "Spirit")
        {
            Destroy(gameObject);
            OnKilled();
        }
    }
}
