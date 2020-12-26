using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item DataBase", menuName = "Item DataBase/Item Database", order = int.MaxValue)]

public class ItemDB : ScriptableObject
{
    public string Code;
    public string Name;
    public string Category;
    public string Grade;
    public float BaseHP;
    public float LevelHP;
    public float BaseDamage;
    public float LevelDamage;
    public float BaseSpeed;
    public float LevelSpeed;
    public Sprite Thumbnail;
}
