using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "QuestDB", menuName = "QuestDB")]
public class QuestDB : ScriptableObject
{
    public string questTitle;
    public string questContents;
    public List<string> requiredItem;
}
