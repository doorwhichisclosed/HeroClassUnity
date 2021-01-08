using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MailPopupContents : MonoBehaviour
{
    public MailDB mailDB;
    public GameObject titleText;
    public GameObject contentsText;
    public List<GameObject> items;
    public bool isReceived = false;
    public bool isClicked = false;

    private void Awake()
    {
        contentsText.GetComponent<Text>().text = mailDB.contents + "\n\n" + mailDB.addresser;
        titleText.GetComponent<Text>().text = mailDB.title;
    }

    public void OnClicked()
    {
        if (!isClicked)
        {
            StretchingMail();
            for(int i = 0;i<gameObject.transform.parent.childCount;i++)
            {
                if(gameObject.transform.parent.GetChild(i).gameObject!=this.gameObject)
                {
                    gameObject.transform.parent.GetChild(i).gameObject.GetComponent<MailPopupContents>().FoldMail();
                }
            }
        }
        else if (isClicked && !isReceived)
        {
            ReceiveItem();
        }
    }

    public void StretchingMail()//메일 펴기
    {
        isClicked = true;
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(960, 520);
        contentsText.SetActive(true);
        for (int i = 0; i < mailDB.items.Count; i++)
        {
            items[i].SetActive(true);
        }
    }

    public void FoldMail()//메일 닫기
    {
        isClicked = false;
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(960, 120);
        contentsText.SetActive(false);
        for (int i = 0; i < mailDB.items.Count; i++)
        {
            items[i].SetActive(false);
        }
    }

    public void ReceiveItem()//아이템 받으면 색깔 변함
    {
        contentsText.GetComponent<Text>().color = new Color(0, 0, 0, 0.5f);
        titleText.GetComponent<Text>().color = new Color(0, 0, 0, 0.5f);
        for (int i = 0; i < mailDB.items.Count; i++)
        {
            items[i].GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
        }
        gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
        isReceived = true;
        //item 받는 이벤트 추가할 거임
    }
}
