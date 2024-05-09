using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using HealthSystem = Crogen.HealthSystem.HealthSystem;


public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected BoxCollider2D _collider;
    [SerializeField] protected GameObject Player;
    

    [SerializeField] protected float _speed;
    [SerializeField] protected int _defense;
    [SerializeField] protected int _damage;
    [SerializeField] protected float _attackDistance;
    [SerializeField] protected int _attackSpeed;
    [SerializeField] protected int _findDistance_x;
    [SerializeField] protected int _findDistance_y;
    [SerializeField] protected Transform _playerTransform;
    [SerializeField] protected EnemeyStatus _enemyStatus;
    [SerializeField] protected Vector3 ReconRange;
    [SerializeField] protected DefaultHealthSystem EnemyHealth;
    //[SerializeField] protected Transform Owner;
    [SerializeField] protected EnemyHpUI HPSlider;
    [SerializeField] protected EnemyHpUI HPSlider_Pre;
    
    [SerializeField] protected DropItem dropItem;
    
    public Vector2 tlqk;

    float Timer;

    /* �ؾ��Ұ�
     * �� ���� �� �̵����� ���ϱ�
     * �÷��̾� �ϼ��Ǹ� Attack �ϼ��ϱ�
     * Dided �ϼ��ϱ�
     * Find �ϼ��ϱ�
     */

    private void Awake()
    {
        EnemyHealth = GetComponent<DefaultHealthSystem>();
        _collider = GetComponentInChildren<BoxCollider2D>();
        Player = GameManager.Instance.PlayerController.gameObject;
        _playerTransform = GameManager.Instance.PlayerController.transform;
        HPSlider = Instantiate(HPSlider_Pre, transform);
        HPSlider.transform.localPosition = new Vector3(0, 1, 0);
        HPSlider.Init(EnemyHealth);
        ReconRange = transform.position;
        //Owner = transform;
        
        EnemyHealth.hpChangeEvent.AddListener(Dided);
    }

    private void Update()
    {
        Timer += Time.deltaTime;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(gameObject.activeSelf)
            StartCoroutine(Wait());
    }

    
    protected void Move(EnemeyStatus enemyStatus)
    {
        switch (enemyStatus)
        {
            case EnemeyStatus.Attack: // �߰� ���� ��
                StartCoroutine(ReconCoroutine());
                break;
            case EnemeyStatus.Recon: // ���� ���� ��
                // �ڱ��߽� 20*20(�ӽ�) ũ���� ���� �� ���� �������� �����ؼ� ���ƴٴ�
                if (transform.position == ReconRange || Timer > 20f)
                {
                    ReconRange = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
                    Timer = 0;
                }
                transform.position = Vector2.MoveTowards(transform.position, ReconRange, _speed);
                break;
            case EnemeyStatus.Suspicious: // �Ҹ��� ����� ��
                // ���� ��ġ���� �Ҹ��� �� ��ġ�� �̵�
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(1, 1), _speed);
                break;
        }

    }

    private IEnumerator ReconCoroutine()
    {
        tlqk = _playerTransform.position - transform.position;
        // �ü� ���� ����
        if (gameObject.CompareTag("Enemy_archers")) // �±׷� ����
        {
            if (Timer >= _attackSpeed)
            {
                Timer = 0;
                Attack_archers();
            }
        }
        // �÷��̾ ��� �i�ƴٴ�
        if (Vector2.Distance(transform.position, Player.transform.position) <= _attackDistance)
        {
            if (Timer >= _attackSpeed)
            {
                Timer = 0;
                Attack();
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _speed * 2);
        yield return new WaitUntil(() => Vector2.Distance(transform.position, _playerTransform.position) > _attackDistance);
        transform.position = transform.position;
        yield return new WaitForSeconds(0.5f);
        transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _speed * 2);
    }

    

    protected void Dided()
    {
        // �״� �ִϸ��̼�

        // �� ĳ���Ϳ� �ش��ϴ� ��ü ����
        Instantiate(dropItem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    protected void Attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, tlqk.normalized, _attackDistance);
        if(hit.transform != null)
        {
            if (hit.transform.TryGetComponent(out DefaultHealthSystem healthSystem))
            {
                healthSystem.Hp -= _damage;
            }
        }
        
        // ���� �ִϸ��̼�
    }

    protected virtual void Attack_archers()
    {
        // ���� �ִϸ��̼�
    }

    protected IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        _enemyStatus = EnemeyStatus.Recon;
    }

    protected enum EnemeyStatus
    {
        Attack, Recon, Suspicious
             //  ����    ������
    }
}