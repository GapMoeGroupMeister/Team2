using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] protected HealthSytem PlayerHealth;
    protected float horizontal;
    protected float vertical;
    protected float movespeed = 5f;
    protected float currentStamina = 20f;
    protected float fullStamina = 20f;
    protected float increaseSpeed;
    protected float acceleration = 3.4f;
    protected float deceleration = 5.5f;
    protected float cureStamina = 0.83f;
    protected string tagValue;
    protected float fullHp = 20f;
    protected float currentHp = 20f;


    private void Awake()
    {
        PlayerHealth = GetComponent<HealthSytem>();
    }
}
