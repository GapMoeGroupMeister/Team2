using UnityEngine;
using System;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public Action<Vector3> OnMovement;
    public Action OnRun;

    private Vector3 moveDir;

    public Vector3 MoveDir => moveDir;

    private void Update()
    {
        OnMovement?.Invoke(moveDir);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            OnRun?.Invoke();
        }
    }
}
