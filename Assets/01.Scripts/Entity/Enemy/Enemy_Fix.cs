// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public abstract class Enemy_Fix : MonoBehaviour
// {
//     
//     protected float _speed;
//     protected float _attackDamage;
//     protected bool _isAttack;
//     protected bool _isDead;
//     
//     [SerializeField] protected EnemyStatus _enemyStatus;
//     protected Vector2 _findDistance;
//     protected Vector2 _targetPosition;
//     protected Transform _playerTransform;
//     protected DefaultHealthSystem EnemyHealth;
//     
//     [SerializeField] protected EnemyHpUI HPSlider;
//     [SerializeField] protected DropItem dropItem;
//     [SerializeField] protected float _maxHp;
//     [SerializeField] protected float _currentHp;
//     
//     protected void Awake()
//     {
//         EnemyHealth = GetComponent<DefaultHealthSystem>();
//         _playerTransform = GameManager.Instance.PlayerController.transform;
//         HPSlider = Instantiate(HPSlider, transform);
//         HPSlider.transform.localPosition = new Vector3(0, 1, 0);
//         HPSlider.Init(EnemyHealth);
//         EnemyHealth.HP = _maxHp;
//     }
//     
//     protected void Update()
//     {
//         if (_isDead) return;
//         _currentHp = EnemyHealth.HP;
//         if (_currentHp <= 0)
//         {
//             _enemyStatus = EnemyStatus.Dead;
//             _isDead = true;
//         }
//         Move();
//     }
//     
//     protected void Move()
//     {
//         switch (_enemyStatus)
//         {
//             case EnemyStatus.Attack:
//                 Attack();
//                 break;
//             case EnemyStatus.Recon:
//                 Recon();
//                 break;
//             case EnemyStatus.Suspicious:
//                 Suspicious();
//                 break;
//             case EnemyStatus.Dead:
//                 Dead();
//                 break;
//         }
//     }
//
//     protected abstract void Attack();
//     
//     protected abstract void Recon();
//     
//     protected abstract void Suspicious();
//     
//     protected abstract void Dead();
//
//     protected enum EnemyStatus
//     {
//         Attack, Recon, Suspicious, Dead
//              //  정찰    수상한
//     }
// }
