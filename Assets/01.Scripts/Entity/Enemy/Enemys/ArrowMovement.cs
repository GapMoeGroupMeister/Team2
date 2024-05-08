using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public Rigidbody2D rigid;
    public Transform owner;
    [SerializeField] protected float _speed;
    public float _damage;
    
    public Archers archers;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
        
        rigid.AddForce(archers.tlqk.normalized * _speed, ForceMode2D.Impulse);
        StartCoroutine(Wait());
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.TryGetComponent<HealthSystem>(out HealthSystem healthSystem))
            {
                healthSystem.HP -= _damage;
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
