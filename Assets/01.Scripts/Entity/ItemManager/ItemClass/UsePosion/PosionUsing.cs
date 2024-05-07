using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosionUsing : MonoBehaviour
{
    [SerializeField] private int nowPosion = 2;
    [SerializeField] private bool canEat = true;
    private bool cooltimeDone = true;
    private bool coolDown = false;
    public float coolTime = 3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Posion"))
        {
            Destroy(collision.gameObject);
            nowPosion++;
        }
    }

    private void Update()
    {
        if (nowPosion <= 0)
        {
            canEat = false;
        }
        else if (nowPosion > 0)
        {
            canEat = true;
        }

        if (cooltimeDone == true)
        {
            if (canEat == true && Input.GetKeyDown(KeyCode.Space))
            {
                coolDown = true;
                nowPosion--;
            }
        }
        if (coolDown == true)
        {
            cooltimeDone = false;
            coolTime -= Time.deltaTime;
            if (coolTime <= 0)
            {
                cooltimeDone = true;
                coolTime = 3f;
                coolDown = false;
            }
        }
    }
}
