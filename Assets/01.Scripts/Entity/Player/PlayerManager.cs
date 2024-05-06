using UnityEngine;
using System;

public class PlayerManager : MonoSingleton<PlayerManager>
{


    [Header("Speed Value")]
    [SerializeField] protected float movespeed = 100f;
    [SerializeField] protected float increaseSpeed;
    [SerializeField] protected float acceleration = 12.8f;
    [SerializeField] protected float deceleration = 10.8f;

    [Space]

    [Header("Stamina Value")]
    [SerializeField] protected float currentStamina = 100f;
    [SerializeField] protected float fullStamina = 100f;
    [SerializeField] protected float cureStamina = 1;
    [SerializeField] protected float decreaseStamina = 1.8999f;

    private Rigidbody2D rb;
    private Vector3 moveDir;
    private bool isRun;

    #region Properties
    public Vector3 MoveDir
    {
        get => moveDir;
        set => moveDir = value;
    }

    public float MoveSpeed
    {
        get => movespeed;
        set => movespeed = value;
    }

    public float IncreaseSpeed
    {
        get => increaseSpeed;
        set => increaseSpeed = value;
    }

    public bool IsRun
    {
        get => isRun;
        set => isRun = value;
    }
    #endregion

    protected void Awake()
    {

        #region Get Component
        rb = GetComponent<Rigidbody2D>();
        #endregion

        #region Clamp
        increaseSpeed = Mathf.Clamp(increaseSpeed, 0f, 150f);
        currentStamina = Mathf.Clamp(currentStamina, 0, fullStamina);
        #endregion
    }

    private void Update()
    {
        rb.velocity = moveDir * (movespeed + increaseSpeed) * Time.deltaTime;

        #region run
        if (isRun)
        {
            increaseSpeed -= fullStamina / deceleration * Time.deltaTime;

            if (currentStamina > 0)
            {
                increaseSpeed += currentStamina / acceleration * Time.deltaTime;
                currentStamina -= decreaseStamina * Time.deltaTime;
            }
        }
        else
        {
            if (currentStamina < fullStamina)
            {
                currentStamina += cureStamina * Time.deltaTime;
            }

            if (currentStamina <= 0)
            {
                increaseSpeed = 0;
            }
        }
        #endregion
    }
}
