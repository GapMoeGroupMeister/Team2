using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    protected bool isAttackAble = true;
    protected Vector2 box;

    Animator animator;

    private void Update()
    {
        PlayersAttack();
    }

    protected void PlayersAttack()
    {
        if (Input.GetMouseButton(0) && isAttackAble == true)
        {
            isAttackAble = false;
            //무기별로 있는 공격 메서드를 불러와서 ㄱㄱ
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
