using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected BoxCollider2D _collider;
    [SerializeField] protected GameObject Player;
    [SerializeField] protected GameObject _arrow;

    [SerializeField] protected float _speed;
    [SerializeField] protected float _maxHp;
    [SerializeField] protected float _hp;
    [SerializeField] protected int _defense;
    [SerializeField] protected int _damage;
    [SerializeField] protected float _attackDistance;
    [SerializeField] protected int _attackSpeed;
    [SerializeField] protected int _findDistance_x;
    [SerializeField] protected int _findDistance_y;
    [SerializeField] protected Transform _playerTransform;
    [SerializeField] protected EnemeyStatus _enemyStatus;
    [SerializeField] protected Vector3 ReconRange;
    [SerializeField] protected HealthSystem EnemyHealth;
    //[SerializeField] protected Transform Owner;
    [SerializeField] protected EnemyHpUI HPSlider;
    [SerializeField] protected EnemyHpUI HPSlider_Pre;
    
    public Vector2 tlqk;

    float Timer;

    /* 해야할거
     * 맵 보고 적 이동범위 정하기
     * 플래이어 완성되면 Attack 완성하기
     * Dided 완성하기
     * Find 완성하기
     */

    private void Awake()
    {
        EnemyHealth = GetComponent<HealthSystem>();
        _collider = GetComponentInChildren<BoxCollider2D>();
        Player = GameObject.Find("CombatPlayer");
        _playerTransform = GameObject.Find("CombatPlayer").transform;
        HPSlider = Instantiate(HPSlider_Pre, transform);
        HPSlider.transform.localPosition = new Vector3(0, 1, 0);
        HPSlider.Init(EnemyHealth);
        EnemyHealth.HP = _maxHp;
        ReconRange = transform.position;
        //Owner = transform;
    }

    private void Update()
    {
        _hp = EnemyHealth.HP;
        Timer += Time.deltaTime;
        if (_hp < 0)
        {
            Dided();
        }

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
            case EnemeyStatus.Attack: // 발견 했을 때
                tlqk = _playerTransform.position - transform.position;
                // 궁수 전용 공격
                if (gameObject.CompareTag("Enemy_archers")) // 태그로 구별
                {
                    if (Timer >= _attackSpeed)
                    {
                        Timer = 0;
                        Attack_archers();
                    }
                    break;
                }
                // 플래이어를 계속 쫒아다님
                transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _speed * 2);
                if (Vector2.Distance(transform.position, Player.transform.position) <= _attackDistance)
                {
                    if (Timer >= _attackSpeed)
                    {
                        Timer = 0;
                        Attack();
                    }
                }
                break;
            case EnemeyStatus.Recon: // 정찰 중일 때
                // 자기중심 20*20(임시) 크기의 구역 안 에서 랜덤으로 지정해서 돌아다님
                if (transform.position == ReconRange || Timer > 20f)
                {
                    ReconRange = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
                    Timer = 0;
                }
                transform.position = Vector2.MoveTowards(transform.position, ReconRange, _speed);
                break;
            case EnemeyStatus.Suspicious: // 소리가 들렸을 때
                // 현재 위치에서 소리가 난 위치로 이동
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(1, 1), _speed);
                break;
        }

    }

    

    protected void Dided()
    {
        // 죽는 애니메이션

        // 적 캐릭터에 해당하는 시체 생성
        // Instantiate()
        Destroy(gameObject);
    }

    protected void Attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, tlqk.normalized, _attackDistance);
        if(hit.transform != null)
        {
            if (hit.transform.TryGetComponent<HealthSystem>(out HealthSystem healthSystem))
            {
                healthSystem.HP -= 0;
            }
        }
        
        // 공격 애니메이션
    }

    protected void Attack_archers()
    {
        GameObject arrow = Instantiate(_arrow, transform.position, Quaternion.identity);
        arrow.GetComponent<ArrowMovement>()._damage = _damage;
        arrow.GetComponent<ArrowMovement>().archers = GetComponent<Archers>();
        arrow.GetComponent<ArrowMovement>().owner = transform;
    }

    protected IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        _enemyStatus = EnemeyStatus.Recon;
    }

    protected enum EnemeyStatus
    {
        Attack, Recon, Suspicious
             //  정찰    수상한
    }
}