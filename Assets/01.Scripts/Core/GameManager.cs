﻿using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [field:SerializeField]public PlayerController PlayerController { get; private set; }

}
