using System;
using DG.Tweening;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float _attackDelayTime = 0.5f;
    private float _curAttackDelayTime = 0;

    protected float _defultRotate;
    protected bool _attackable;
    private bool _isAttack;
    protected GameManager _gameManager;
    protected PlayerController _player;
    protected Transform _visualTrm;
    public GameObject _attackEffect;
    public float attackValue;
    protected InputManager _inputManager;
    public Vector2 AttackDirection { get; private set; }

    protected virtual void OnEnable()
    {
        //Managements
        _gameManager = GameManager.Instance;
        _inputManager = _gameManager.InputManager;
        
        //Trm
        _visualTrm = transform.Find("Visual");
        _defultRotate = _visualTrm.eulerAngles.z;
        _player = _gameManager.PlayerController;
        _inputManager.AttackDirectionEvent += HandleAttackDirection;
        _inputManager.AttackEvent += OnAttack;
    }

    private void OnDisable()
    {
        _inputManager.AttackDirectionEvent -= HandleAttackDirection;
        _inputManager.AttackEvent -= OnAttack;
    }

    protected virtual void OnAttack()
    {
        _attackable = false;
        _curAttackDelayTime = 0;
        if(_attackEffect != null) 
            _attackEffect.SetActive(true);
        _isAttack = true;
    }

    protected virtual void EndAttack()
    {
        if(_attackEffect != null) 
            _attackEffect.SetActive(false);
        _visualTrm.DORotate(new Vector3(0, 0, _defultRotate), _attackDelayTime);
        _isAttack = false;
    }

    protected void Update()
    {
        if (!_attackable)
        {
            _curAttackDelayTime += Time.deltaTime;
            _attackable = _curAttackDelayTime > _attackDelayTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isAttack) return;
        if(other.TryGetComponent(out DefaultHealthSystem healthSystem))
        {
            healthSystem.Hp -= attackValue;
        }
    }

    protected void HandleAttackDirection(Vector2 dir)
    {
        AttackDirection = dir;
        dir = Quaternion.Euler(0, 45, 0) * dir;
        transform.up = dir;
    }
}
