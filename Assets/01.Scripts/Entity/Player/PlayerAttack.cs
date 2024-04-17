using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    protected bool isAttackAble = true;
    protected Transform trans;
    protected Vector2 box;

    Animator animator;

    private void Update()
    {
        PlayersAttack();
    }

    protected void PlayersAttack()
    {
        if (Input.GetMouseButtonDown(0) && isAttackAble)
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(trans.position, box, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.CompareTag("Enemy"))
                {
                    collider.gameObject.GetComponent<HealthSytem>()?.SetHP(1 /*µ¥¹ÌÁö*/);
                }
            }
            animator.SetTrigger("Attack1");
            isAttackAble = false;
            StartCoroutine(Attack1());

        }
        
    }
    IEnumerator Attack1()
    {
        yield return new WaitForSeconds(0.3f);
        isAttackAble = false;

    }

    protected void PlayerDefend()
    {
        if (Input.GetMouseButtonDown(1) && !isAttackAble)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Defend1();
            
        }
    }

    IEnumerator Defend1()
    {
        yield return new WaitForSeconds(0.3f);
        isAttackAble = false;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
