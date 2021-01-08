using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailPageInteraction : MonoBehaviour
{
    public GameObject contents;

    public void OnClicked_BackGround()
    {
        for(int i =0;i<contents.transform.childCount;i++)
        {
            contents.transform.GetChild(i).GetComponent<MailPopupContents>().FoldMail();
        }
    }

    public void OnClicked_AllReceiveButton()
    {
        for (int i = 0; i < contents.transform.childCount; i++)
        {
            if (!contents.transform.GetChild(i).GetComponent<MailPopupContents>().isReceived)
                contents.transform.GetChild(i).GetComponent<MailPopupContents>().ReceiveItem();
        }
    }
}
