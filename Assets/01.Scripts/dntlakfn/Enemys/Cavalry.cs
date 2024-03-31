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
        // �ݶ��̴� 2�� �Ἥ Ž����, �ǰݿ����� ���
        Debug.Log("��");
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
