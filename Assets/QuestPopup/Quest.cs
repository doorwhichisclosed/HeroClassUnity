using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Quest : MonoBehaviour
{
    public QuestDB questDB;
    public GameObject questTitle;
    public GameObject questContents;
    public List<GameObject> items;
    public Image questCheckImage;
    public GameObject questClearButton;
    public UnityEvent QuestCleared;
    public bool isCleared = false;
    public bool isClicked = false;
    private void Awake()
    {
        questTitle.GetComponent<Text>().text = "[퀘스트] " + questDB.questTitle;
        questContents.GetComponent<Text>().text = questDB.questContents;
    }

    public void OnClicked()
    {
        if(!isClicked)
        {
            StretchingQuest();
            for (int i = 0; i < gameObject.transform.parent.childCount; i++)
            {
                if (gameObject.transform.parent.GetChild(i).gameObject != this.gameObject)
                {
                    gameObject.transform.parent.GetChild(i).gameObject.GetComponent<Quest>().FoldQuest();
                }
            }
        }
        else if(isClicked)
        {
            FoldQuest();
        }
    }

    public void StretchingQuest()//퀘스트 펴기
    {
        isClicked = true;
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(960, 520);
        questContents.SetActive(true);
        questClearButton.SetActive(true);
        for (int i = 0; i < questDB.requiredItem.Count; i++)
        {
            items[i].SetActive(true);
        }
        //퀘스트 조건 만족하는 지 확인하고 제출 완료 버튼 활성화
    }

    public void FoldQuest()//퀘스트 닫기
    {
        isClicked = false;
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(960, 120);
        questContents.SetActive(false);
        questClearButton.SetActive(false);
        for (int i = 0; i < questDB.requiredItem.Count; i++)
        {
            items[i].SetActive(false);
        }
    }

    public void ClearQuest()//퀘스트 클리어
    {
        isCleared = true;
        questCheckImage.color = new Color(0, 0, 0, 1);
        questClearButton.GetComponent<Button>().interactable = false;
        QuestCleared.Invoke();
    }
}
