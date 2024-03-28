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


    /* �ؾ��Ұ�
     * �� ���� �� �̵����� ���ϱ�
     * �÷��̾� �ϼ��Ǹ� Attack �ϼ��ϱ�
     * Dided �ϼ��ϱ�
     * Find �ϼ��ϱ�
     */




    private void Update()
    {
        Move(EnemeyStatus.Recon);
    }



    protected void Move(EnemeyStatus enemyStatus)
    {
        switch (enemyStatus) 
        {
            // �߰� ���� ��

            case EnemeyStatus.Attack:
                // �÷��̾ ��� �i�ƴٴ�

                Vector2.MoveTowards(transform.position, new Vector2(Random.RandomRange(-10f, 10f), Random.RandomRange(-10f, 10f)), 10);
                if(transform.position == Player.transform.position)
                {

                }
                break;

            // ���� ���� ��

            case EnemeyStatus.Recon:
                // �ڱ��߽� 20*20(�ӽ�) ũ���� ������ �������� �����ؼ� ���ƴٴ�

                Vector2.MoveTowards(transform.position, new Vector2(Random.RandomRange(-10f, 10f), Random.RandomRange(-10f, 10f)), 10);
                break;

            // �Ҹ��� ����� ��

            case EnemeyStatus.Suspicious:
                // ���� ��ġ���� �Ҹ��� �� ��ġ�� �̵�, 3�ʵ��� �ֺ��� �ѷ���

                Vector2.MoveTowards(transform.position, new Vector2(1, 1) , 10);
                break;                                 /*�Ҹ� �� �� ��ġ*/






        }
        
    }

    protected void Damaged(int damage)
    {
        // �������� �Ÿ��� �ִϸ��̼�

        int realDamage = (damage - (_defense / 2) < 0) ? 0 : damage - (_defense / 2);

        _hp -= realDamage;
        if (_hp < 0)
        {
            Dided();

        }
    }

    protected void Dided()
    {
        // �״� �ִϸ��̼�

        // �� ĳ���Ϳ� �ش��ϴ� ��ü ����
        // Instantiate()
    }

    protected void Attack()
    {
        // �÷��̾ �����ϸ�
        /*
         * if()
         * {
         * 
         * }
         */

        // ���� �ִϸ��̼�

        // �÷��̾� ä�� �����ͼ� ���� ��Ű��
        /* 
         * Player._hp -= damage
         * 
         */
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ݶ��̴� 2�� �Ἥ Ž�� ������, �ǰݿ����� ���

        if (collision.tag == "Player") 
        {
            _enemyStatus = EnemeyStatus.Attack;
        }
    }










    protected enum EnemeyStatus
    {
        Attack, Recon, Suspicious
             //  ����    ������
    }
}