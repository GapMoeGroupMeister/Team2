using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DropItem : InteractionObject
{
    [SerializeField] float _jumpPower;
    [SerializeField] ItemSO itemData;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = itemData.itemImage;
    }

    private void Start()
    {
        transform.DOJump(transform.position, _jumpPower, 2, 1);
    }

    protected override void Interaction()
    {
        base.Interaction();

        if (makeInteraction == true)
        {
            PickedUp();
        }
    }
}
