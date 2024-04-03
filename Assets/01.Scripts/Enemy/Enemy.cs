using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected BoxCollider2D _collider;
    [SerializeField] protected GameObject Player;
    [SerializeField] protected GameObject Arrow;

    [SerializeField] protected float _speed;
    [SerializeField] protected int _hp;
    [SerializeField] protected int _defense;
    [SerializeField] protected int _damage;
    [SerializeField] protected float _attackDistance;
    [SerializeField] protected int _attackSpeed;
    [SerializeField] protected int _findDistance_x;
    [SerializeField] protected int _findDistance_y;

    [SerializeField] protected Transform _playerTransform;
    [SerializeField] protected EnemeyStatus _enemyStatus;
    [SerializeField] protected Vector3 ReconRange;
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
        _collider = GetComponent<BoxCollider2D>();
        Player = GameObject.Find("Player");
        _playerTransform = GameObject.Find("Player").transform;
    }
    private void Start()
    {

        ReconRange = transform.position;
    }

    private void Update()
    {
        Timer += UnityEngine.Time.deltaTime;
        if (_hp < 0)
        {
            Dided();
        }

    }

    [System.Obsolete]
    protected void Move(EnemeyStatus enemyStatus)
    {
        switch (enemyStatus)
        {
            // 발견 했을 때

            case EnemeyStatus.Attack:
                // 플래이어를 계속 쫒아다님
                tlqk = _playerTransform.position - transform.position;

                // 궁수 전용 공격
                if (gameObject.tag == "Enemy_archers") // 태그로 구별
                {
                    if (Timer >= _attackSpeed)
                    {
                        Timer = 0;
                        Attack_archers();
                    }
                    break;
                }
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
                    ReconRange = new Vector2(Random.RandomRange(-10f, 10f), Random.RandomRange(-10f, 10f));
                }
                
                transform.position = Vector2.MoveTowards(transform.position, ReconRange, _speed);
                
                Debug.Log("발");
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
        // Instantiate()
        Destroy(gameObject);
    }

    protected void Attack()
    {

        if(Physics2D.Raycast(transform.position, tlqk.normalized, 1))
        {

        }
        
        // 공격 애니메이션

        // 플래이어 채력 가져와서 감소 시키기
        /* 
         * if (Vector2.Distance(transform.position, Player.transform.position) <= _attackDistance)
            {
                Player._hp -= damage
            }
         * 
         * 
         */
    }

    protected void Attack_archers()
    {
        Instantiate(Arrow, transform.position, Quaternion.identity);
    }









    

    





    protected enum EnemeyStatus
    {
        Attack, Recon, Suspicious
             //  정찰    수상한
    }
}