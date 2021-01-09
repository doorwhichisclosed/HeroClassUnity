using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortByCondition : MonoBehaviour
{
    public Transform characterButtonCanvas;
    [Header("ByCategory")]
    public Toggle hero;
    public Toggle soldier;
    [Header("ByStar")]
    public Toggle oneStar;
    public Toggle twoStar;
    public Toggle threeStar;
    public Toggle fourStar;
    public Toggle fiveStar;
    [Header("ByJob")]
    public Toggle warrior;
    public Toggle crossBow;
    public Toggle arrow;
    public Toggle healer;
    public Toggle defenser;
    public Toggle lance;
    public Toggle mage;
    public Toggle dealer;
    [Header("ByStat")]
    public Toggle level;
    public Toggle defense;
    public Toggle attack;
    public Toggle proficiency;
    public Toggle hp;
    public Toggle upDown;
    [Header("BySkill")]
    public Toggle bleed;
    public Toggle stun;
    public Toggle freeze;
    public Toggle curse;
    public Toggle poison;
    public Toggle slow;
    public Toggle shield;
    public Toggle aggro;
    public Toggle silence;
    public Toggle heal;
    public Toggle shieldBreak;
    public Toggle defenseBuf;
    public Toggle speedBuf;
    public Toggle attackBuf;
    public Toggle wound;

    public List<Toggle> allCategory;

    public void OnClicked()
    {
        SortByCategory();
        SortByStar();
        SortByStat();
        gameObject.SetActive(false);
    }

    public void OnClickedInit()
    {
        for (int i = 0; i < allCategory.Count; i++)
            allCategory[i].isOn = false;
        OnClicked();
    }

    public void SortByCategory()
    {
        for (int i = 0; i < characterButtonCanvas.childCount; i++)
        {
            if (hero.isOn)
            {
                if (characterButtonCanvas.GetChild(i).GetComponent<HeroManageButton>()._tag.Equals("Hero"))
                {
                    Debug.Log("True");
                    characterButtonCanvas.GetChild(i).gameObject.SetActive(true);
                }
                else characterButtonCanvas.GetChild(i).gameObject.SetActive(false);

            }
            else if (soldier.isOn)
            {

                if (characterButtonCanvas.GetChild(i).GetComponent<HeroManageButton>()._tag.Equals("Soldier"))
                    characterButtonCanvas.GetChild(i).gameObject.SetActive(true);
                else characterButtonCanvas.GetChild(i).gameObject.SetActive(false);

            }
            else
                characterButtonCanvas.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void SortByStar()
    {
        bool[] checkStar = new bool[5] { oneStar.isOn, twoStar.isOn, threeStar.isOn, fourStar.isOn, fiveStar.isOn };
        if (!oneStar.isOn&&!twoStar.isOn&&!threeStar.isOn&&!fourStar.isOn&!fiveStar.isOn)
        {
            Debug.Log("It's true");
        }
        else
        {
            for (int i = 0; i < characterButtonCanvas.childCount; i++)
            {
                if (checkStar[characterButtonCanvas.GetChild(i).gameObject.GetComponent<HeroManageButton>().tempGrade - 1] == false)
                    characterButtonCanvas.GetChild(i).gameObject.SetActive(false);
            }
        }

    }

    public void SortByJob()
    {
        //Not Defined
    }

    public void SortByStat()
    {
        int upOrDown = upDown.isOn ? 1 : -1;
        List<Transform> sortList = new List<Transform>();
        for (int i = 0; i < characterButtonCanvas.childCount; i++)
            sortList.Add(characterButtonCanvas.GetChild(i));
        if (level.isOn)
        {
            sortList.Sort((Transform a, Transform b) => a.GetComponent<HeroManageButton>().tempLevel.CompareTo(b.GetComponent<HeroManageButton>().tempLevel) * upOrDown);
        }
        if(defense.isOn)
        {
            sortList.Sort((Transform a, Transform b) => a.GetComponent<HeroManageButton>().tempLevel.CompareTo(b.GetComponent<HeroManageButton>().tempDefense) * upOrDown);
        }
        if (attack.isOn)
        {
            sortList.Sort((Transform a, Transform b) => a.GetComponent<HeroManageButton>().tempLevel.CompareTo(b.GetComponent<HeroManageButton>().tempAttack) * upOrDown);
        }
        if (proficiency.isOn)
        {
            sortList.Sort((Transform a, Transform b) => a.GetComponent<HeroManageButton>().tempLevel.CompareTo(b.GetComponent<HeroManageButton>().tempProficiency) * upOrDown);
        }
        if (hp.isOn)
        {
            sortList.Sort((Transform a, Transform b) => a.GetComponent<HeroManageButton>().tempLevel.CompareTo(b.GetComponent<HeroManageButton>().tempHp) * upOrDown);
        }
        for (int i=0;i<sortList.Count;i++)
        {
            sortList[i].SetSiblingIndex(i);
        }

    }

    public void SortBySkill()
    {
        //Not defined
    }


}
