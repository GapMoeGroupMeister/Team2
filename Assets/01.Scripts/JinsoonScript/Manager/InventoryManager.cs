using UnityEngine;

public class InventoryManager : MonoSingleton<InventoryManager>
{
    public Vector2 slotSize;
    public Inventory curSelectingInventory;


    [HideInInspector]
    public Slot curSelectingSlot;

    [HideInInspector]
    public Item curSelectingItem;
    
}
