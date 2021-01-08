using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dungeon : MonoBehaviour
{
    public bool isClicked = false;
    public Text dungeonTitle;
    public Text dungeonText;
    public GameObject dungeonSpecific;
    public DungeonDB dungeonDB;

    private void Awake()
    {
        UpdateDungeon();
    }

    public void OnClicked()
    {
        if (!isClicked)
            StretchingDungeon();
        else
            FoldDungeon();
    }
    public void StretchingDungeon()//던전 펴기
    {
        isClicked = true;
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(1260, 1180);
        dungeonSpecific.SetActive(true);
        for(int i = 0;i<dungeonSpecific.transform.childCount;i++)
        {
            dungeonSpecific.transform.GetChild(i).GetComponent<DungeonInfo>().UpdateDungeonInfo();
        }
    }

    public void FoldDungeon()
    {
        isClicked = false;
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(1260, 340);
        dungeonSpecific.SetActive(false);
    }

    public void UpdateDungeon()//던전 정보 업데이트
    {
        dungeonTitle.text = dungeonDB.dungeonTitle;
        dungeonText.text = dungeonDB.dungeonText;
    }
}
