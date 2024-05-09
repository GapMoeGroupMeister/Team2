using System.Collections;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public Rigidbody2D rigid;
    [SerializeField] protected float _speed;
    public float _damage;
    
    public Archers archers;
    
    void Start()
    {
        rigid.AddForce(archers.tlqk.normalized * _speed, ForceMode2D.Impulse);
        transform.right = archers.tlqk;
        StartCoroutine(Wait());
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
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
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
