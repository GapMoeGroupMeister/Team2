using System;
using UnityEngine;

public class BloodEffectDrawSystem : MonoSingleton<BloodEffectDrawSystem>
{
    private MeshRenderer _meshRenderer;
    private MeshFilter _meshFilter;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshFilter = GetComponent<MeshFilter>();
    }
    
    
}
