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



    /* �ؾ��Ұ�
     * �� ���� �� �̵����� ���ϱ�
     * �÷��̾� �ϼ��Ǹ� Attack �ϼ��ϱ�
     * Dided �ϼ��ϱ�
     * Find �ϼ��ϱ�
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
            // �߰� ���� ��

            case EnemeyStatus.Attack:
                // �÷��̾ ��� �i�ƴٴ�

                transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _speed);
                Debug.Log("��");
                if (Vector2.Distance(transform.position, Player.transform.position) <= _attackDistance)
                {
                    Attack();
                }
                break;

            // ���� ���� ��

            case EnemeyStatus.Recon:
                // �ڱ��߽� 20*20(�ӽ�) ũ���� ���� �� ���� �������� �����ؼ� ���ƴٴ�

                
                if (transform.position == tlqkf)
                {
                    tlqkf = new Vector2(Random.RandomRange(-10f, 10f), Random.RandomRange(-10f, 10f));
                }
                
                transform.position = Vector2.MoveTowards(transform.position, tlqkf, _speed);
                
                Debug.Log("��");
                break;

            // �Ҹ��� ����� ��

            case EnemeyStatus.Suspicious:
                // ���� ��ġ���� �Ҹ��� �� ��ġ�� �̵�

                transform.position = Vector2.MoveTowards(transform.position, new Vector2(1, 1), _speed);
                                      /*�Ҹ� �� �� ��ġ*/
                break;






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
        Destroy(gameObject);
    }

    protected void Attack()
    {
        // ���� �ִϸ��̼�

        // �÷��̾� ä�� �����ͼ� ���� ��Ű��
        /* 
         * Player._hp -= damage
         * 
         */
    }


   


    










    protected enum EnemeyStatus
    {
        Attack, Recon, Suspicious
             //  ����    ������
    }
}