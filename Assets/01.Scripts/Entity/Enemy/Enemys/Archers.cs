using UnityEngine;

public class Archers : Enemy
{
    [SerializeField] private ArrowMovement _arrow;
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            ReconRange = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        }
    }
    
    protected override void Attack_archers()
    {
        ArrowMovement arrow = Instantiate(_arrow, transform.position, Quaternion.identity);
        arrow.archers = this;
        tlqk = _playerTransform.position - transform.position;
    }
}
