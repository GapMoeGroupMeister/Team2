using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerManager playerManager;
    private Rigidbody2D rb;

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


    private void Awake()
    {
        #region GetComponent
        playerManager = GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody2D>();
        #endregion

        #region Action Add
        playerManager.OnMovement += Move;
        playerManager.OnRun += Run;
        #endregion

        #region Clamp
        increaseSpeed = Mathf.Clamp(increaseSpeed, 0f, 150f);
        currentStamina = Mathf.Clamp(currentStamina, 0, fullStamina);
        #endregion
    }

    private void OnDestroy()
    {
        playerManager.OnMovement -= Move;
        playerManager.OnRun -= Run;
    }

    private void Move(Vector3 moveDir)
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(horizontal, vertical, 0).normalized;

        rb.velocity = moveDir * (movespeed + increaseSpeed) * Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            increaseSpeed = 0;
        }
    }

    private void Run()
    {
        increaseSpeed -= fullStamina / deceleration * Time.deltaTime;

        if (currentStamina > 0)
        {
            increaseSpeed += currentStamina / acceleration * Time.deltaTime;
            currentStamina -= 0.996f * Time.deltaTime;
        }
        else if (currentStamina < fullStamina)
        {
            currentStamina += cureStamina * Time.deltaTime;
        }

        if (currentStamina <= 0)
        {
            increaseSpeed = 0;
        }
    }
}
