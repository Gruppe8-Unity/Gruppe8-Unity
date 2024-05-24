using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Transform expDropPoint;
    public Vector2 DirectionToPlayer { get; private set; }
    
    private float movementSpeed = 2;
    private float rotationSpeed = 1000;
    private float enemyAwarenessDistance = 50;
    private Rigidbody2D playerRigidBody;
    private Transform playerTransform;
    
    private void Awake()
    {
        playerTransform = FindObjectOfType<Player>().transform;
        playerRigidBody = GetComponent<Rigidbody2D>();
    }
    
    public void OnKilled(GameObject expPrefab)
    {
        Instantiate(expPrefab, expDropPoint.position, Quaternion.Euler(0, 0, 0));
    }
    
    public void DetermineEnemyRotation()
    {
        Vector2 enemyToPlayerVector = playerTransform.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= enemyAwarenessDistance)
        {
            RotateEnemy();
        }
        SetVelocity();
    }
    
    public void RotateEnemy()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, DirectionToPlayer);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        playerRigidBody.SetRotation(rotation);
    }
    public void SetVelocity()
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
}
