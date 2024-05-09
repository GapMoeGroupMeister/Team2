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
        // �ݶ��̴� 2�� �Ἥ Ž����, �ǰݿ����� ���
        
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
