using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Rigidbody2D rigid;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _hp;
    [SerializeField] protected int _defense;
    [SerializeField] protected float _damage;
    [SerializeField] protected Transform _playerTransform;




    protected void Move()
    {
        
    }

    protected void Damaged()
    {

    }

    protected void Attack()
    {

    }

    protected enum EnemeyStatus
    {

    }
}