using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortingToggleButtonColorChange : MonoBehaviour
{
    private void Start()
    {
        OnValueChange();
    }

    public void OnValueChange()
    {
        Toggle toggle = GetComponent<Toggle>();
        if(toggle.isOn)
        {
            Image image = GetComponent<Image>();
            image.color = Color.gray;
        }
        else
        {
            Image image = GetComponent<Image>();
            image.color = Color.white;
        }
    }
}
