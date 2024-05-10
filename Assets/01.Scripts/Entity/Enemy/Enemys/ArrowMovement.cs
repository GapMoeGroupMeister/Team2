using System.Collections;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public Rigidbody2D rigid;
    [SerializeField] protected float _speed;
    public float _damage;
    
    public Archer archer;

    private bool isInit = false;
    
    public void Init()
    {
        rigid.AddForce(archer.OwnerToPlayerDirection * _speed, ForceMode2D.Impulse);
        transform.right = archer.OwnerToPlayerDirection;
        StartCoroutine(Wait());
        isInit = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInit == false) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.TryGetComponent(out DefaultHealthSystem healthSystem))
            {
                healthSystem.Hp -= _damage;
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
