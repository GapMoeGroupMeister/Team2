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
        
        // �ݶ��̴� 2�� �Ἥ Ž����, �ǰݿ����� ���
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�־ȵ� �ù�");
            _enemyStatus = EnemeyStatus.Attack;
            StopCoroutine(Wait());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(Wait());
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            ReconRange = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        _enemyStatus = EnemeyStatus.Recon;
    }
}
