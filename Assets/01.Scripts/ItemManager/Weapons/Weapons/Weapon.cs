using System;
using DG.Tweening;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Managements
    protected GameManager _gameManager;
    protected InputManager _inputManager;
    private UIManager _uiManager;
    private WeaponManager _weaponManager;

    [SerializeField] private int weaponIndex;

    protected float _defultRotate;
    public bool attackable;
    private bool _isAttack;
    
    protected PlayerController _player;
    protected Transform _visualTrm;
    public GameObject _attackEffect;
    public float attackValue;
    public Vector2 AttackDirection { get; private set; }

    protected virtual void OnEnable()
    {
        //Managements
        _gameManager = GameManager.Instance;
        _inputManager = _gameManager.InputManager;
        _uiManager = UIManager.Instance;
        _weaponManager = WeaponManager.Instance;
        
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
        attackable = false;
        _weaponManager.curAttackDelayTime[weaponIndex] = 0;
        if(_attackEffect != null) 
            _attackEffect.SetActive(true);
        _isAttack = true;
    }

    protected virtual void EndAttack()
    {
        if(_attackEffect != null) 
            _attackEffect.SetActive(false);
        _visualTrm.DORotate(new Vector3(0, 0, _defultRotate), _weaponManager.attackDelayTime[weaponIndex]);
        _isAttack = false;
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
