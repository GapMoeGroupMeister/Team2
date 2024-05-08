using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _scrollAmount;
    [SerializeField] private float _scrollSpeed;
    [SerializeField] private Vector3 moveDirection;

    private void Update()
    {
        transform.position += moveDirection * (_scrollSpeed * Time.deltaTime);
        
        if (transform.position.x <= -_scrollAmount)
        {
            transform.position = _target.position - moveDirection * _scrollAmount;
        }
    }
}
