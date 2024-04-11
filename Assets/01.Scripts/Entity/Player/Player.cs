using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected float horizontal;
    protected float vertical;
    protected float movespeed = 5;
    protected float currentStamina = 20;
    protected float fullStamina = 20;
    protected float increaseSpeed;
    protected float acceleration = 3.4f;
    protected float deceleration = 5.5f;
    protected float cureStamina = 0.83f;
    protected string tagValue;
    protected float fullHp = 20;
    protected float currentHp = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
