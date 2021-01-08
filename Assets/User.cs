using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class User : MonoBehaviour
{
    public string userName;//유저 이름
    public int level;//레벨
    public float exp;//경험치
    public int gold;//골드
    public int diamond;//다이아몬드
    public int stamina;//스태미나
    public int maxStamina;//최대 스태미나
    public List<string> achievement;//업적
    public Text levelText, expText, goldText, diamondText, staminaText;//각각 담을 텍스트들
    public List<HeroInfo> heroList;//히어로 리스트


    private string heroSavePath;
    private string achievementSavePath;
    private string userInfoSavePath;//유저 정보 저장해놓을 위치

    private void Start()
    {
        heroSavePath = Application.persistentDataPath + "/MyHeroText.txt";
        achievementSavePath = Application.persistentDataPath + "/MyAchievement.txt";
        userInfoSavePath = Application.persistentDataPath + "/MyUserText.txt";//저장 위치
        LoadInformation();//정보 불러오기
        ChangeLevel(0);//처음 초기화 과정
        ChangeExp(0);
        ChangeStamina(0);
        ChangeDiamond(0);
        ChangeGold(0);
    }

    public void LoadInformation()//정보 불러오기
    {
        HeroInfoLoad();
        UserInfoLoad();
        AchievementInfoLoad();
    }

    public void SaveInformation()//정보 저장
    {
        HeroInfoSave();
        UserInfoSave();
        AchievementInfoSave();
    }

    public void ShowInformation(Text text, float newValue)//정보 시각적 업데이트
    {
        text.text = newValue.ToString();
        UserInfoSave();
        UserInfoLoad();
    }

    public void ShowInformation(Text text, int newValue)
    {
        text.text = newValue.ToString();
        UserInfoSave();
        UserInfoLoad();
    }

    public void ChangeLevel(int upper)//레벨 업데이트
    {
        level += upper;
        ShowInformation(levelText, level);
    }
    public void ChangeExp(float upper)//exp업데이트
    {
        exp += upper;
        ShowInformation(expText, exp);
    }

    public void ChangeGold(int upper)//골드 업데이트
    {
        gold += upper;
        ShowInformation(goldText, gold);
    }

    public void ChangeDiamond(int upper)//다이아몬드 업데이트
    {
        diamond += upper;
        ShowInformation(diamondText, diamond);
    }

    public void ChangeStamina(int upper)//스태미나 업데이트
    {
        stamina += upper;
        ShowInformation(staminaText, stamina);
    }

    public void UserInfoReset()//유저 정보 리셋
    {
        string jdata = JsonUtility.ToJson(new UserInfo("", 1, 0, 0, 0, 1));//현재 사용자 정보를 초기화합니다.
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
        string code = System.Convert.ToBase64String(bytes);

        File.WriteAllText(userInfoSavePath, code);
        UserInfoLoad();
    }

    public void UserInfoSave()//유저 정보 저장
    {
        string jdata = JsonUtility.ToJson(new UserInfo(name, level, exp, gold, diamond, stamina));//현재 사용자 정보를 암호화후 json형식으로 저장해줍니다.
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
        string code = System.Convert.ToBase64String(bytes);

        File.WriteAllText(userInfoSavePath, code);
    }

    public void UserInfoLoad()//유저 정보 불러오기
    {
        if (!File.Exists(userInfoSavePath)) { UserInfoReset(); return; }
        string code = File.ReadAllText(userInfoSavePath);//복호화 해서 불러와줍니다.

        byte[] bytes = System.Convert.FromBase64String(code);
        string jdata = System.Text.Encoding.UTF8.GetString(bytes);
        UserInfo loadedUserinfo = JsonUtility.FromJson<UserInfo>(jdata);
        userName = loadedUserinfo.name;//유저 정보를 불러온 후에 유정 정보를 업데이트 해줍니다.
        level = loadedUserinfo.level;
        exp = loadedUserinfo.exp;
        gold = loadedUserinfo.gold;
        diamond = loadedUserinfo.diamond;
        stamina = loadedUserinfo.stamina;
    }

    public void AchievementInfoSave()//유저 정보 저장
    {
        string jdata = JsonUtility.ToJson(new SavebleList<string>(achievement));//현재 사용자 정보를 암호화후 json형식으로 저장해줍니다.
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
        string code = System.Convert.ToBase64String(bytes);
        File.WriteAllText(achievementSavePath, code);
    }

    public void AchievementInfoLoad()//유저 정보 불러오기
    {
        if (!File.Exists(achievementSavePath)) { AchievementInfoSave(); return; }
        string code = File.ReadAllText(achievementSavePath);//복호화 해서 불러와줍니다.

        byte[] bytes = System.Convert.FromBase64String(code);
        string jdata = System.Text.Encoding.UTF8.GetString(bytes);
        SavebleList<string> loadedAchievement = JsonUtility.FromJson<SavebleList<string>>(jdata);
        achievement = loadedAchievement.save;
    }

    public void HeroInfoSave()//히어로 정보 저장
    {
        string jdata = JsonUtility.ToJson(new SavebleList<HeroInfo>(heroList));//현재 사용자 정보를 암호화후 json형식으로 저장해줍니다.
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
        string code = System.Convert.ToBase64String(bytes);

        File.WriteAllText(heroSavePath, code);
    }

    public void HeroInfoLoad()//히어로 정보 불러오기
    {
        if (!File.Exists(heroSavePath)) { HeroInfoSave(); return; }
        string code = File.ReadAllText(heroSavePath);//복호화 해서 불러와줍니다.

        byte[] bytes = System.Convert.FromBase64String(code);
        string jdata = System.Text.Encoding.UTF8.GetString(bytes);
        SavebleList<HeroInfo> loadedHeroInfo = JsonUtility.FromJson<SavebleList<HeroInfo>>(jdata);
        heroList = loadedHeroInfo.save;
    }
}
