using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroManageButton : MonoBehaviour
{
    public string _tag="Hero";//히어로랑 솔져 구분
    public HeroDB heroDB;
    public SoldierDB soldierDB;
    public Image heroImage;
    public Image classImage;
    public List<Sprite> classSprites;//추후에 병사와 히어로에 직업 추가해야할듯
    public List<GameObject> stars;
    public int tempGrade;//추후 병사와 히어로에 별 갯수 추가해야할듯
    public int tempLevel;
    public int tempAttack;
    public int tempDefense;
    public int tempProficiency;
    public int tempHp;
    public List<GameObject> specificPageStars;
    public Text specificNameText;
    public Text specificCharaterStatText;

    public GameObject heroSpecificPage;

    public void SetUp()
    {
        if (_tag == "Hero")
        {
            heroImage.sprite = heroDB.CharacterImage;
        }
        else
        {
            GetComponent<Image>().color = Color.gray;
            heroImage.sprite = soldierDB.CharacterImage;
        }

        for(int i=0;i<5;i++)//레벨에 따른 별 표시
        {
            if (i < tempGrade)
                stars[i].SetActive(true);
            else
                stars[i].SetActive(false);
        }
        //if문으로 hero나 soldierDB의 클래스에 따라서 classSprite 지정해줌
        
    }

    public void OnClicked()
    {
        heroSpecificPage.SetActive(true);
        for (int i = 0; i < 5; i++)//레벨에 따른 별 표시
        {
            if (i < tempGrade)
                specificPageStars[i].SetActive(true);
            else
                specificPageStars[i].SetActive(false);
        }
        if (_tag == "Hero")
        {
            specificNameText.text = heroDB.Name;
        }
        else
        {
            specificNameText.text = soldierDB.name;
        }
        specificCharaterStatText.text = "레벨: " + tempLevel + "\n공격력: " + tempAttack + "\n방어력: " + tempDefense + "\n체력: " + tempHp;
        //이제 선택한 오브젝트에 대한 설명들 넣어줌
    }

    private void Start()
    {
        SetUp();
    }


}
