using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITestInterAction : MonoBehaviour
{
    public bool inActiveThis;
    public bool activeNext;
    public GameObject thisUI;
    public GameObject next;

    public void ButtonInteraction()
    {
        if (inActiveThis)
            thisUI.SetActive(false);
        if (activeNext)
            next.SetActive(true);
    }
}
