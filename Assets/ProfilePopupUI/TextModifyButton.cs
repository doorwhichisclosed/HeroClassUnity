using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextModifyButton : MonoBehaviour
{
    public GameObject inputFieldPopup;
    public InputField inputField;
    public Text inputText;
    public string textName;
    public bool isShowing = false;
    static int activatedPopupNum = 0;
    private void Start()
    {
        Hide();
    }

    public void Clicked()
    {
        if (!isShowing && activatedPopupNum == 0)
        {
            activatedPopupNum=1;
            isShowing = true;
            inputFieldPopup.SetActive(true);
        }
    }

    public void Submit()
    {
        inputText.text = inputField.text;
        Hide();
    }

    public void Hide()
    {
        activatedPopupNum = 0;
        isShowing = false;
        inputFieldPopup.SetActive(false);
    }

}
