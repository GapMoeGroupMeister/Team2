using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private Transform _visualTrm;
    
    private InputManager _inputManager;
    private Rigidbody2D _rigidbody;
    
    private void Awake()
    {
        //Components
        _inputManager = InputManager.Instance;
        _rigidbody = GetComponent<Rigidbody2D>();
        _visualTrm = transform.Find("Visual");
        
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
    }
}
