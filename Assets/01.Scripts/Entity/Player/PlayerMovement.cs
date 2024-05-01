using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerManager playerManager;
    
    private void Awake()
    {
        playerManager = PlayerManager.Instance;
    }

    private void OnMovement(InputValue value)
    {
        playerManager.MoveDir = value.Get<Vector3>();
    }

    private void OnRun(InputValue value)
    {
        if (value.isPressed)
        {
            playerManager.IsRun = true;
        }
        else
        {
            playerManager.IsRun = false;
        }
    }
}
