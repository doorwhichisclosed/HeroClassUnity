using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NullSave.TOCK.Stats;

public class Item : MonoBehaviour
{
    public string code;
    public string _name;
    public string category;
    public string grade;
    public int level;
    public float plusHP;
    public float plusDamage;
    public float plusSpeed;
    public Sprite thumbnail;

    public List<ItemDB> itemDB;

    private void Awake()
    {
        LoadItem();
    }

    public void SetCode(string input)
    {
        code = input;
    }

    public void UpdateStatus()//레벨에 따른 스탯 조정
    {
        for(int i=0;i<itemDB.Count;i++)
        {
            if(itemDB[i].Code==this.code)
            {
                this._name = itemDB[i].Name;
                this.grade = itemDB[i].Grade;
                this.category = itemDB[i].Category;
                this.plusHP = itemDB[i].BaseHP + itemDB[i].LevelHP * level;
                this.plusDamage = itemDB[i].BaseDamage + itemDB[i].LevelDamage * level;
                this.plusSpeed = itemDB[i].BaseSpeed + itemDB[i].LevelSpeed * level;
                break;
            }
        }
    }

    public void LoadDesign()//디자인을 불러옴
    {
        for(int i=0;i<itemDB.Count;i++)
        {
            if(itemDB[i].Code==this.code)
            {
                if (itemDB[i].Thumbnail != null)
                    this.thumbnail = itemDB[i].Thumbnail;
                break;
            }
        }
    }
    
    public void LoadItem()//아이템을 불러옴
    {
        UpdateStatus();
        LoadDesign();
    }

}
