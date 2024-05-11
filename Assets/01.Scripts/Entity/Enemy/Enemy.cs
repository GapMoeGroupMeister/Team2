using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _attackRange = 5f;
    [SerializeField] public int _damage;
    [SerializeField] protected DefaultHealthSystem EnemyHealth;
    [SerializeField] protected float _attackDelay = 5f;
    protected float _curAttackDelay = 0;
    [SerializeField] protected Transform _playerTransform;
    
    [SerializeField] protected EnemyHpUI HPSlider;
    [SerializeField] protected EnemyHpUI HPSlider_Pre;
    
    [SerializeField] protected DropItem dropItem;
    [SerializeField] protected ParticleSystem _deadEffect;
    private NavMeshAgent _agent;
    protected AudioSource _dieSound;

    public Vector2 OwnerToPlayerDirection { get; private set; }
    protected event Action _attackEvent; 
    
    
    protected virtual void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        EnemyHealth = GetComponent<DefaultHealthSystem>();
        
        _playerTransform = GameManager.Instance.PlayerController.transform;
        
        HPSlider = Instantiate(HPSlider_Pre, transform);
        HPSlider.transform.localPosition = new Vector3(0, 1, 0);
        HPSlider.Init(EnemyHealth);
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        
        _dieSound = GetComponent<AudioSource>();
        EnemyHealth.dieEvent.AddListener(HandleDieEvent);
        EnemyHealth.hpChangeEvent.AddListener(HandleHpChangeEvent);
        InputManager.Instance.MoveEvent += HandleFollowPlayer;
    }
    private void Update()
    {
        OwnerToPlayerDirection = (_playerTransform.position - transform.position).normalized;
        _curAttackDelay += Time.deltaTime;
    }

    private void HandleHpChangeEvent()
    {
        HPSlider.transform.Find("Anchor").transform.localScale = new Vector3(EnemyHealth.Hp / EnemyHealth.maxHp, 1, 1);
    }
    
    private void HandleFollowPlayer(Vector2 vec)
    {
        _agent.destination = _playerTransform.position;
        float distance = Vector2.Distance(_playerTransform.position, transform.position);
        if (distance < _attackRange && _curAttackDelay > _attackDelay)
        {
            _curAttackDelay = 0;
            _attackEvent?.Invoke();
        }
    }

    private void HandleDieEvent()
    {
        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine()
    {
        InputManager.Instance.MoveEvent -= HandleFollowPlayer;
        _dieSound.Play();
        Instantiate(dropItem, transform.position, Quaternion.identity);
        ParticleSystem ps = Instantiate(_deadEffect, transform.position, Quaternion.identity);
        ps.Play();
        yield return new WaitUntil(() => !_dieSound.isPlaying);
        Destroy(gameObject);
    }
}