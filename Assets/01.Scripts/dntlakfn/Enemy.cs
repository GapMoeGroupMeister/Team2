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


    /* 해야할거
     * 맵 보고 적 이동범위 정하기
     * 플래이어 완성되면 Attack 완성하기
     * Dided 완성하기
     * Find 완성하기
     */




    private void Update()
    {
        Move(EnemeyStatus.Recon);
    }



    protected void Move(EnemeyStatus enemyStatus)
    {
        switch (enemyStatus) 
        {
            // 발견 했을 때

            case EnemeyStatus.Attack:
                // 플래이어를 계속 쫒아다님

                Vector2.MoveTowards(transform.position, new Vector2(Random.RandomRange(-10f, 10f), Random.RandomRange(-10f, 10f)), 10);
                if(transform.position == Player.transform.position)
                {

                }
                break;

            // 정찰 중일 때

            case EnemeyStatus.Recon:
                // 자기중심 20*20(임시) 크기의 구역을 랜덤으로 지정해서 돌아다님

                Vector2.MoveTowards(transform.position, new Vector2(Random.RandomRange(-10f, 10f), Random.RandomRange(-10f, 10f)), 10);
                break;

            // 소리가 들렸을 때

            case EnemeyStatus.Suspicious:
                // 현재 위치에서 소리가 난 위치로 이동, 3초동안 주변을 둘러봄

                Vector2.MoveTowards(transform.position, new Vector2(1, 1) , 10);
                break;                                 /*소리 난 쪽 위치*/






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
    }

    protected void Attack()
    {
        // 플래이어에 근접하면
        /*
         * if()
         * {
         * 
         * }
         */

        // 공격 애니메이션

        // 플래이어 채력 가져와서 감소 시키기
        /* 
         * Player._hp -= damage
         * 
         */
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 콜라이더 2개 써서 탐지 범위용, 피격용으로 사용

        if (collision.tag == "Player") 
        {
            _enemyStatus = EnemeyStatus.Attack;
        }
    }










    protected enum EnemeyStatus
    {
        Attack, Recon, Suspicious
             //  정찰    수상한
    }
}