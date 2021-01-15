using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject itemSlotsContent;
    public List<EquipableItem> equipableItemList;
    public List<EquipableItem> equippedItemList;
    public int unequippedItemAmount;
    public GameObject equipSlot;
    public int tempItemNum;
    private void Start()
    {
        InitializeSlots();
    }

    public void InitializeSlots()
    {
        BasicSlot();
        for (int i = 0; i < tempItemNum; i++)
        {
            GameObject item = Instantiate(itemPrefab, transform, false);
            equipableItemList.Add(item.GetComponent<EquipableItem>());

            itemSlotsContent.transform.GetChild(i).gameObject.SetActive(true);
            item.GetComponent<EquipableItem>().SetPosition(itemSlotsContent.transform.GetChild(i).GetComponent<RectTransform>());
        }
        for (int j = 0; j < 20; j++)
        {
            if (j < 5)
                equipableItemList[j].category = "Weapon";
            else if (j < 10)
                equipableItemList[j].category = "Ring";
            else if (j < 15)
                equipableItemList[j].category = "Necklace";
            else if (j < 20)
                equipableItemList[j].category = "Orb";

        }
    }

    public void SortSlots()
    {
        for(int i =0;i<equipableItemList.Count;i++)
        {
            itemSlotsContent.transform.GetChild(i).gameObject.SetActive(true);
            equipableItemList[i].SetPosition(itemSlotsContent.transform.GetChild(i).GetComponent<RectTransform>());
        }
    }

    public void UnequipAll()
    {
        for(int i=0;i<4;i++)
        {
            if (equipSlot.transform.GetChild(i).childCount!=0)
                equipSlot.transform.GetChild(i).GetChild(0).GetComponent<EquipableItem>().Unequip();
        }
    }

    public void AutoEquip()
    {
        UnequipAll();
        List<EquipableItem> Weapons = new List<EquipableItem>();
        List<EquipableItem> Ring = new List<EquipableItem>();
        List<EquipableItem> Necklace = new List<EquipableItem>();
        List<EquipableItem> Orb = new List<EquipableItem>();
        for(int i=0;i<equipableItemList.Count;i++)
        {
            if(equipableItemList[i].category.Equals("Weapon"))
            {
                Weapons.Add(equipableItemList[i]);
            }
            else if (equipableItemList[i].category.Equals("Ring"))
            {
                Ring.Add(equipableItemList[i]);
            }
            else if (equipableItemList[i].category.Equals("Necklace"))
            {
                Necklace.Add(equipableItemList[i]);
            }
            else if (equipableItemList[i].category.Equals("Orb"))
            {
                Orb.Add(equipableItemList[i]);
            }
        }
        //대충 전투력 계산해줌
        //정렬해줌
        if(Weapons.Count!=0)
            equipSlot.GetComponent<EquipArea>().EquipItem(Weapons[0].gameObject);
        if (Ring.Count != 0)
            equipSlot.GetComponent<EquipArea>().EquipItem(Ring[0].gameObject);
        if (Necklace.Count != 0)
            equipSlot.GetComponent<EquipArea>().EquipItem(Necklace[0].gameObject);
        if(Orb.Count!=0)
            equipSlot.GetComponent<EquipArea>().EquipItem(Orb[0].gameObject);
    }

    void BasicSlot()
    {
        for (int i = 0; i < 20; i++)
        {
            itemSlotsContent.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
