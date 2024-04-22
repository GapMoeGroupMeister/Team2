using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected Transform owner;
    [SerializeField] protected float _speed;
    
    Archers archers;
    // Start is called before the first frame update

    private void Awake()
    {
        owner = GameObject.Find("Archers").transform;
        archers = owner.GetComponent<Archers>();
    }
    void Start()
    {
        
        rigid.AddForce(archers.tlqk.normalized * _speed, ForceMode2D.Impulse);
        StartCoroutine(Wait());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
