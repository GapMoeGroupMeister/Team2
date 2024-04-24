using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public Vector2 slotSize;


    [HideInInspector]
    public Slot curSelectingSlot;

    [HideInInspector]
    public Item curSelectingItem;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);

        Instance = this;
    }
}
