using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MailDB", menuName = "MailDB")]
public class MailDB : ScriptableObject
{
    public string title;
    public string contents;
    public List<string> items;
    public string addresser;
}
