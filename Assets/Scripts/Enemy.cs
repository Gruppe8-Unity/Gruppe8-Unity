using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rigidBody;

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;

    private Transform _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>().transform;

        _rigidBody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
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
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            _rigidBody.SetRotation(rotation);
        }

    }
    private void SetVelocity()
    {
        if (DirectionToPlayer == Vector2.zero)
        {
            _rigidBody.velocity = Vector2.zero;
        }
        else
        {
            _rigidBody.velocity = transform.up * _speed;
        }
    }

}
