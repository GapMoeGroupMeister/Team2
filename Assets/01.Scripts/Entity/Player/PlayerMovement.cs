using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private Transform _visualTrm;
    
    private InputManager _inputManager;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    private void OnEnable()
    {
        //Components
        if (_inputManager == null)
            _inputManager = InputManager.Instance;
        if (_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody2D>();
        if (_visualTrm == null)
            _visualTrm = transform.Find("Visual");
        if (_animator == null)
            _animator = _visualTrm.GetComponent<Animator>();
        
        //Move
        _inputManager.MoveEvent += HandleMoveEvent;
    }

    private void OnDisable()
    {
        _inputManager.MoveEvent -= HandleMoveEvent;
    }

    private void HandleMoveEvent(Vector2 dir)
    {
        _rigidbody.velocity = dir.normalized * _speed;
        if(Mathf.Approximately(dir.x, 0f) == false)
            _visualTrm.localScale = new Vector3((int)dir.x, 1, 1);
        _animator.SetFloat("MoveDir", dir.magnitude);
    }
}
