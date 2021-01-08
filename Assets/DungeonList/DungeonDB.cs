using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DungeonDB", menuName = "DungeonDB")]
public class DungeonDB : ScriptableObject
{
    public string dungeonTitle;
    public string dungeonText;
    public string dungeonContent;//던전 세부 사항들
}
