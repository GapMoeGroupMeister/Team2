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

    /* �ؾ��Ұ�
     * �� ���� �� �̵����� ���ϱ�
     * �÷��̾� �ϼ��Ǹ� Attack �ϼ��ϱ�
     * Dided �ϼ��ϱ�
     * Find �ϼ��ϱ�
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
            // �߰� ���� ��

            case EnemeyStatus.Attack:
                // �÷��̾ ��� �i�ƴٴ�
                tlqk = _playerTransform.position - transform.position;

                // �ü� ���� ����
                if (gameObject.tag == "Enemy_archers") // �±׷� ����
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

            // ���� ���� ��

            case EnemeyStatus.Recon:
                // �ڱ��߽� 20*20(�ӽ�) ũ���� ���� �� ���� �������� �����ؼ� ���ƴٴ�

                
                if (transform.position == ReconRange || Timer > 20f)
                {
                    ReconRange = new Vector2(Random.RandomRange(-10f, 10f), Random.RandomRange(-10f, 10f));
                }
                
                transform.position = Vector2.MoveTowards(transform.position, ReconRange, _speed);
                
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

    

    protected void Dided()
    {
        // �״� �ִϸ��̼�

        // �� ĳ���Ϳ� �ش��ϴ� ��ü ����
        // Instantiate()
        Destroy(gameObject);
    }

    protected void Attack()
    {

        if(Physics2D.Raycast(transform.position, tlqk.normalized, 1))
        {

        }
        
        // ���� �ִϸ��̼�

        // �÷��̾� ä�� �����ͼ� ���� ��Ű��
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
             //  ����    ������
    }
}