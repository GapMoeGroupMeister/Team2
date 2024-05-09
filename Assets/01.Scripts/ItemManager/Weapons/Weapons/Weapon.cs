using DG.Tweening;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float _attackDelayTime = 0.5f;
    protected float _curAttackDelayTime = 0;

    protected float _defultRotate;
    
    protected GameManager _gameManager;
    protected PlayerController _player;
    protected Transform _visualTrm;
    public GameObject _attackEffect;
    public float attackValue;
    public bool isAttack = false;
    private InputManager _inputManager;
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
        if (_curAttackDelayTime < _attackDelayTime)
            isAttack = true;
        if(_attackEffect != null) 
            _attackEffect.SetActive(true);    
    }

    protected virtual void EndAttack()
    {
        isAttack = false;
        if(_attackEffect != null) 
            _attackEffect.SetActive(false);
        _curAttackDelayTime = 0;
        _visualTrm.DORotate(new Vector3(0, 0, _defultRotate), _attackDelayTime);
    }

    protected void Update()
    {
        _curAttackDelayTime += Time.deltaTime;
    }

    private void HandleAttackDirection(Vector2 dir)
    {
        AttackDirection = dir;
        dir = Quaternion.Euler(0, 45, 0) * dir;
        transform.up = dir;
    }
}
