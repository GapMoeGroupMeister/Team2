using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region InventoryInformation

    public InventorySO inventorySO;
    public GameObject slotPf;
    private Transform slots;

    public string inventoryName { get; private set; }
    public Vector2Int inventorySize { get; private set; }

    #endregion

    public Slot[,] inventorySlots { get; private set; }

    private void Awake()
    {
        inventoryName = inventorySO.InventoryName;
        inventorySize = inventorySO.inventorySize;
        slots = transform.Find("Slots");

        inventorySlots = new Slot[inventorySize.x, inventorySize.y];

        for (int i = 0; i < inventorySize.y; i++)
        {
            for (int j = 0; j < inventorySize.x; j++)
            {
                Slot slot = Instantiate(slotPf, slots).GetComponent<Slot>();
                slot.SetOwner(this, new Vector2Int(j, i));
                inventorySlots[j, i] = slot;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="position">Position of item's bottom left</param>
    /// <param name="item"></param>
    public void SetItem(Vector2Int position, Item item)
    {
        inventorySlots[position.x, position.y].SetItem(item, true);
    }
}
