using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archers : Enemy
{
    private void Start()
    {
        _collider.size = new Vector2(_findDistance_x, _findDistance_y);
        _enemyStatus = EnemeyStatus.Recon;
    }
    private void FixedUpdate()
    {
        //IsDided();
        Move(_enemyStatus);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        // 콜라이더 2개 써서 탐지용, 피격용으로 사용
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("왜안돼 시발");
            _enemyStatus = EnemeyStatus.Attack;
            StopCoroutine(Wait());
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
