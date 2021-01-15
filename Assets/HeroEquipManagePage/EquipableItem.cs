using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipableItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Canvas canvas;
    [SerializeField] EquipManager equipManager;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public GameObject lastSlot;
    public bool isEquipped;
    public string category;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        equipManager = GameObject.FindGameObjectWithTag("EquipManager").GetComponent<EquipManager>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("DragBegin");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("On Drag");
        transform.SetParent(canvas.transform);
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        RaycastResult hit = eventData.pointerCurrentRaycast;
        if (hit.gameObject == null || hit.gameObject.GetComponent<EquipArea>() == null)
        {
            if (isEquipped && hit.gameObject == equipManager.itemSlotsContent.transform.parent.gameObject)
                Unequip();
            else 
                SetPosition(lastSlot.GetComponent<RectTransform>());
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Down");
    }

    public void SetPosition(RectTransform slot)
    {
        rectTransform.position = slot.position;
        lastSlot = slot.gameObject;
        transform.SetParent(slot.transform);
    }

    public void Equip(RectTransform equipSlot)
    {
        isEquipped = true;
        SetPosition(equipSlot);
        equipManager.equipableItemList.Remove(this);
        equipManager.equippedItemList.Add(this);
        equipManager.SortSlots();
    }

    public void Unequip()
    {
        isEquipped = false;
        equipManager.equippedItemList.Remove(this);
        equipManager.equipableItemList.Add(this);
        equipManager.SortSlots();
    }
}
