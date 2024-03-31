using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavalry : Enemy
{
    private void Start()
    {
        _enemyStatus = EnemeyStatus.Recon;
    }

    [System.Obsolete]
    private void FixedUpdate()
    {
        
        Move(_enemyStatus);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopCoroutine("Wait");
        // 콜라이더 2개 써서 탐지용, 피격용으로 사용
        Debug.Log("됨");
        if (collision.gameObject.tag == "Player")
        {
            _enemyStatus = EnemeyStatus.Attack;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine("Wait");
    }

    [System.Obsolete]

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!(collision.gameObject.tag == "Player"))
        {
            tlqkf = new Vector2(Random.RandomRange(-10f, 10f), Random.RandomRange(-10f, 10f));
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        _enemyStatus = EnemeyStatus.Recon;
    }
}
