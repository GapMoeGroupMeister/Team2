using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feeler : Enemy
{
    private void Start()
    {
        _collider.size = new Vector2(_findDistance_x, _findDistance_y);
        _enemyStatus = EnemeyStatus.Recon;
    }

    private void FixedUpdate()
    {
        
        Move(_enemyStatus);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Wait());
        // 콜라이더 2개 써서 탐지용, 피격용으로 사용
        
        if (collision.gameObject.CompareTag("Player"))
        {
            _enemyStatus = EnemeyStatus.Attack;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            ReconRange = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        }
    }
}
