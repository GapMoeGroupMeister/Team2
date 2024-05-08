using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Weapon weapon { get; set; }
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    private bool _initComplete;
    public virtual void Init(Weapon weapon)
    {
        this.weapon = weapon;
        _rigidbody = GetComponent<Rigidbody2D>();
        _initComplete = true;
    }

    public void OnDisable()
    {
        _initComplete = false;
    }

    public virtual void OnAttack(Vector2 attackDir)
    {
        _rigidbody.velocity = weapon.AttackDirection * _speed;
    }
    
    private void Update()
    {
        if (_initComplete)
        {
            transform.rotation = Quaternion.LookRotation(weapon.AttackDirection);
        }
    }
}
