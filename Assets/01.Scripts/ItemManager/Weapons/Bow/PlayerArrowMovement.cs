using System.Collections;
using UnityEngine;

public class PlayerArrowMovement : MonoBehaviour
{
    public Rigidbody2D rigid;
    [SerializeField] protected float _speed;
    public float _damage;
    private PlayerController _playerController;
    
    private bool isInit = false;

    public void Init(Vector3 playerPos)
    {
        Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerPos).normalized;

        rigid.AddForce(dir * _speed, ForceMode2D.Impulse);
        transform.right = dir;
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
