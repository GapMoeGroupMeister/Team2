using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Inventory")]
public class InventorySO : ScriptableObject
{
    [Header("Must Be English")]
    public string InventoryName;

    public Vector2Int inventorySize;
}
