using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlyOneButtonPressed : MonoBehaviour
{
    public List<Button> buttons;

    private void Start()
    {
        buttons[0].interactable = false;   
    }
    public void OnButtonClicked(Button button)
    {
        for(int i=0;i<buttons.Count;i++)
        {
            if (buttons[i] == button)
            {
                button.interactable = false;
            }
            else
                buttons[i].interactable = true;
        }
    }
}
