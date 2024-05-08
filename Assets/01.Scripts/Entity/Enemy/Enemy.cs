using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


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
    [SerializeField] protected HealthSytem EnemyHealth;
    //[SerializeField] protected Transform Owner;
    [SerializeField] protected EnemyHpUI HPSlider;
    [SerializeField] protected GameObject HPSlider_Pre;
    [SerializeField] GameObject _hpslider;
    [SerializeField] protected GameObject DropItem1;
    [SerializeField] protected GameObject DropItem2;
    
    
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

        
        EnemyHealth = GetComponent<HealthSytem>();
        _collider = GetComponentInChildren<BoxCollider2D>();
        Player = GameObject.Find("CombatPlayer");
        _playerTransform = GameObject.Find("CombatPlayer").transform;
        _hpslider = Instantiate(HPSlider_Pre, transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        HPSlider = _hpslider.GetComponent<EnemyHpUI>();
        EnemyHealth.HP = _maxHp;
        ReconRange = transform.position;
        //Owner = transform;
    }
    private void Update()
    {
        _hp = EnemyHealth.HP;
        HPSlider.healthSytem = EnemyHealth;
        HPSlider.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x + 1.5f, transform.position.y + 2f, 0));

        Timer += UnityEngine.Time.deltaTime;
        if (_hp <= 0)
        {
            Dided();
        }

    }

    
    protected void Move(EnemeyStatus enemyStatus)
    {
        switch (enemyStatus)
        {
            // 발견 했을 때

            case EnemeyStatus.Attack:
                
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

            // 정찰 중일 때

            case EnemeyStatus.Recon:
                // 자기중심 20*20(임시) 크기의 구역 안 에서 랜덤으로 지정해서 돌아다님

                
                if (transform.position == ReconRange || Timer > 20f)
                {
                    ReconRange = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
                    Timer = 0;
                }
                
                transform.position = Vector2.MoveTowards(transform.position, ReconRange, _speed);
                
                
                break;

            // 소리가 들렸을 때

            case EnemeyStatus.Suspicious:
                // 현재 위치에서 소리가 난 위치로 이동

                transform.position = Vector2.MoveTowards(transform.position, new Vector2(1, 1), _speed);
                                                                            /*소리 난 쪽 위치*/
                break;






        }

    }

    

    protected void Dided()
    {
        // 죽는 애니메이션

        // 적 캐릭터에 해당하는 시체 생성
        Instantiate(Random.Range(1,3) == 1 ? DropItem1 : DropItem2, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(_hpslider);
    }

    protected void Attack()
    {

        if(Physics2D.Raycast(transform.position, tlqk.normalized, _attackDistance))
        {
            Physics2D.Raycast(transform.position, tlqk.normalized, _attackDistance).collider.gameObject.GetComponent<HealthSytem>().HP -= 0;
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


    
    







    protected enum EnemeyStatus
    {
        Attack, Recon, Suspicious
             //  정찰    수상한
    }
}