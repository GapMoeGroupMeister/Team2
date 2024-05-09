using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IDragHandler
{
    #region ItemInformation

    [SerializeField] private ItemSO itemSO;
    public ItemSO ItemSO => itemSO;

    public string itemName { get; private set; }
    public string itemExplain { get; private set; }
    public Vector2Int itemSize { get; private set; }
    public int maxAmountInSlot { get; private set; }

    public GameObject itemSell { get; private set; }

    #endregion

    private Image image;
    private RectTransform itemRect;
    private Transform itemSellParent;
    private TextMeshProUGUI itemTxt;

    private bool isSelected = false;
    public int itemAmount = 1;
    public bool canPlace = true;

    public List<Slot> assignedSlotList = new List<Slot>();

    private Vector2 offset;
    private Vector2 sellSize;
    private Vector2Int selectedSell;

    public Vector2Int SelectedSell => selectedSell;
    public Vector2 SellSize => sellSize;


    private void Awake()
    {
        itemRect = GetComponent<RectTransform>();
        image = transform.Find("Visual").GetComponent<Image>();
        itemTxt = transform.Find("Visual/Amount").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && isSelected == true)
        {
            OnPointerUp();
            isSelected = false;
        }
    }

    public int AddItem(int amount)
    {
        int temp = itemAmount;
        itemAmount += amount;
        itemAmount = Mathf.Clamp(itemAmount, 0, maxAmountInSlot);
        return (itemAmount - temp);
    }

    public void SetAmount(int amount)
    {
        itemAmount = amount;
        itemTxt.SetText(amount.ToString());
    }

    public void SetPosition(Vector2 position)
    {
        itemRect.localPosition = position;
    }

    public void Init(ItemSO itemSO)
    {
        this.itemSO = itemSO;
        Debug.Log(itemSO.itemName);

        itemName = itemSO.itemName;
        itemExplain = itemSO.itemExplain;
        itemSize = itemSO.itemSize;
        maxAmountInSlot = itemSO.maxAmountInSlot;
        sellSize = InventoryManager.Instance.slotSize;

        itemRect.sizeDelta = new Vector2(sellSize.x * itemSize.x, sellSize.y * itemSize.y);
        RectTransform rect = image.GetComponent<RectTransform>();
        rect.sizeDelta = itemRect.sizeDelta;
        rect.anchoredPosition3D = new Vector3(itemRect.sizeDelta.x / 2, -itemRect.sizeDelta.y/2, 0);
        image.sprite = itemSO.itemImage;
    }


    #region PointerEventRegion

    public void OnPointerEnter(PointerEventData eventData)
    {
        itemRect.localScale = new Vector3(1.05f, 1.05f, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        itemRect.localScale = Vector3.one;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        InventoryManager.Instance.curSelectingItem = this;

        for (int i = 0; i < assignedSlotList.Count; i++)
        {
            assignedSlotList[i].assignedItem = null;
        }

        offset = (Vector2)Input.mousePosition - itemRect.anchoredPosition;
        FindSelectedSell();
        image.raycastTarget = false;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.6f);
        isSelected = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemRect.anchoredPosition = (Vector2)Input.mousePosition - offset;
    }

    public void OnPointerUp()
    {
        //현재 선택된 슬롯이 존재하고 Place할 수 있다면
        if (InventoryManager.Instance.curSelectingSlot != null
            && canPlace == true)
        {
            //선택을 해제해주고 위치를 옮기십시오
            InventoryManager.Instance.curSelectingSlot.Select(false, true);
        }
        else //그렇지 않다면
        {
            assignedSlotList[0].SetItem(this, true);    //이전 위치로 가십시오
        }

        InventoryManager.Instance.curSelectingItem = null;
        image.raycastTarget = true;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }

    #endregion

    private void FindSelectedSell()
    {
        Vector2 rect = (Vector2)Input.mousePosition - (itemRect.anchoredPosition + new Vector2(960, 550));

        if (itemSize.x % 2 == 0)
        {
            float min = (float)itemSize.x * -100 / 2;
            rect.x -= min;
            selectedSell.x = (int)(rect.x / 100);
        }
        else
        {
            float min = -50 + (float)(itemSize.x - 1) * -100 / 2;
            rect.x -= min;
            selectedSell.x = (int)(rect.x / 100);
        }

        if (itemSize.y % 2 == 0)
        {
            float min = (float)itemSize.y * -100 / 2;
            rect.y -= min;
            selectedSell.y = (int)(rect.y / 100);
        }
        else
        {
            float min = -50 + (float)(itemSize.y - 1) * -100 / 2;
            rect.y -= min;
            selectedSell.y = (int)(rect.y / 100);
        }
    }
}
