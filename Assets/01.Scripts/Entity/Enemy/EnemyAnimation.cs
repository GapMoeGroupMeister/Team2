using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sp;
    [SerializeField] protected Collider2D _collider;
    float before = 0;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(transform.position.x - before < 0)
        {
            sp.flipX = true;
            _collider.offset = new Vector2(-3, 0);

        }
        else
        {
            sp.flipX = false;
            _collider.offset = new Vector2(3, 0);
        }
        animator.SetFloat("MoveDir", Mathf.Clamp(transform.position.x - before, -1, 1));
        before = transform.position.x;
    }
}
