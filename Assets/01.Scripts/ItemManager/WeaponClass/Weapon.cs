using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected GameManager _gameManager;
    protected PlayerController _player;
    protected Transform _visualTrm;
    public GameObject _attackEffect;
    public float attackValue;
    public bool isAttack;
    private InputManager _inputManager;
    public Vector2 AttackDirection { get; private set; }
    
    protected virtual void Awake()
    {
        //Managements
        _gameManager = GameManager.Instance;
        _inputManager = _gameManager.InputManager;
        
        //Trm
        _visualTrm = transform.Find("Visual");
        _player = _gameManager.PlayerController;
        _inputManager.AttackDirectionEvent += HandleAttackDirection;
    }

    private void OnDisable()
    {
        _inputManager.AttackDirectionEvent -= HandleAttackDirection;
    }

    protected virtual void OnAttack()
    {
        isAttack = true;
        _attackEffect?.SetActive(true);
    }

    protected virtual void EndAttack()
    {
        isAttack = false;
        _attackEffect?.SetActive(false);
    }
    
    private void HandleAttackDirection(Vector2 dir)
    {
        AttackDirection = dir;
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
