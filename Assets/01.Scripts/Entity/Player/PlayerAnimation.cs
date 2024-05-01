using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sp;
    
    float before = 0;

    private void Awake()
    {

        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (transform.position.x - before < 0)
        {
            sp.flipX = true;
            

        }
        else
        {
            sp.flipX = false;
            
        }
        animator.SetFloat("MoveDir", Mathf.Clamp(transform.position.x - before, -1, 1));
        before = transform.position.x;
    }
}
