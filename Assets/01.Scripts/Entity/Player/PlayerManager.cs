using UnityEngine;
using System;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    [Header("Speed Value")]
    [SerializeField] protected float movespeed = 100f;
    [SerializeField] protected float increaseSpeed;
    [SerializeField] protected float acceleration = 3.4f;
    [SerializeField] protected float deceleration = 5.5f;

    [Space]

    [Header("Stamina Value")]
    [SerializeField] protected float currentStamina = 20f;
    [SerializeField] protected float fullStamina = 20f;
    [SerializeField] protected float cureStamina = 0.83f;

    private Rigidbody2D rb;
    private Vector3 moveDir;
    private HowMuchDefeat defValue;

    #region 프로퍼티
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

    public bool IsRun { get; set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        #region Get Component
        rb = GetComponent<Rigidbody2D>();
        #endregion

        #region Clamp
        increaseSpeed = Mathf.Clamp(increaseSpeed, 0f, 150f);
        currentStamina = Mathf.Clamp(currentStamina, 0, fullStamina);
        #endregion

        defValue = GetComponent<HowMuchDefeat>();
        if (defValue.defeat >= 4)
            movespeed = 100f + (defValue.defeat * 5);
    }

    private void Update()
    {
        rb.velocity = moveDir * (movespeed + increaseSpeed) * Time.deltaTime;

        #region run
        if (IsRun)
        {
            increaseSpeed -= fullStamina / deceleration * Time.deltaTime;

            if (currentStamina > 0)
            {
                increaseSpeed += currentStamina / acceleration * Time.deltaTime;
                currentStamina -= 0.996f * Time.deltaTime;
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
