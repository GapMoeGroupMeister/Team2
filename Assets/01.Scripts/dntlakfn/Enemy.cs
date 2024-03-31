using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
    protected Rigidbody2D rigid;
    public GameObject Player;

    

    [SerializeField] protected float _speed;
    [SerializeField] protected int _hp;
    [SerializeField] protected int _defense;
    [SerializeField] protected int _damage;
    [SerializeField] protected float _attackDistance;
    [SerializeField] protected int _attackSpeed;
    [SerializeField] protected int _findDistance;

    [SerializeField] protected Transform _playerTransform;
    [SerializeField] protected EnemeyStatus _enemyStatus;
    [SerializeField] protected Vector3 tlqkf;



    /* 해야할거
     * 맵 보고 적 이동범위 정하기
     * 플래이어 완성되면 Attack 완성하기
     * Dided 완성하기
     * Find 완성하기
     */

    private void Start()
    {
        tlqkf = transform.position;
    }


    [System.Obsolete]
    protected void Move(EnemeyStatus enemyStatus)
    {
        switch (enemyStatus)
        {
            // 발견 했을 때

            case EnemeyStatus.Attack:
                // 플래이어를 계속 쫒아다님

                transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _speed);
                Debug.Log("됨");
                if (Vector2.Distance(transform.position, Player.transform.position) <= _attackDistance)
                {
                    Attack();
                }
                break;

            // 정찰 중일 때

            case EnemeyStatus.Recon:
                // 자기중심 20*20(임시) 크기의 구역 안 에서 랜덤으로 지정해서 돌아다님

                
                if (transform.position == tlqkf)
                {
                    tlqkf = new Vector2(Random.RandomRange(-10f, 10f), Random.RandomRange(-10f, 10f));
                }
                
                transform.position = Vector2.MoveTowards(transform.position, tlqkf, _speed);
                
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

    protected void Damaged(int damage)
    {
        // 깜빡깜빡 거리는 애니메이션

        int realDamage = (damage - (_defense / 2) < 0) ? 0 : damage - (_defense / 2);

        _hp -= realDamage;
        if (_hp < 0)
        {
            Dided();

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
        // 공격 애니메이션

        // 플래이어 채력 가져와서 감소 시키기
        /* 
         * Player._hp -= damage
         * 
         */
    }


   


    










    protected enum EnemeyStatus
    {
        Attack, Recon, Suspicious
             //  정찰    수상한
    }
}