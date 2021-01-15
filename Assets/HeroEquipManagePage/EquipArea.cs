using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipArea : MonoBehaviour, IDropHandler
{
    public EquipManager equipManager;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag);
        GameObject item = eventData.pointerDrag;
        EquipItem(item);

    }
    public void ChangeSlotItem(int i, GameObject item)
    {
        if (equipManager.equipSlot.transform.GetChild(i).childCount!=0)
            equipManager.equipSlot.transform.GetChild(i).GetChild(0).GetComponent<EquipableItem>().Unequip();
        item.GetComponent<EquipableItem>().Equip(equipManager.equipSlot.transform.GetChild(i).GetComponent<RectTransform>());
    }
    public void EquipItem(GameObject item)
    {
        if (item.GetComponent<EquipableItem>() != null)
        {
            if (item.GetComponent<EquipableItem>().category.Equals("Weapon"))
            {
                ChangeSlotItem(0, item);
            }
            else if (item.GetComponent<EquipableItem>().category.Equals("Ring"))
            {
                ChangeSlotItem(1, item);
            }
            else if (item.GetComponent<EquipableItem>().category.Equals("Necklace"))
            {
                ChangeSlotItem(2, item);
            }
            else if (item.GetComponent<EquipableItem>().category.Equals("Orb"))
            {
                ChangeSlotItem(3, item);
            }
        }
    }
}

