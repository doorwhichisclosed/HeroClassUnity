using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavebleList<T>//skin list를 json으로 저장할려면 직렬화 해줄 필요가 있어서 만들어줌
{
    public SavebleList(List<T> _save) => save = _save;
    public List<T> save;
}

[System.Serializable]
public class Skin//skin 클래스, 영웅 코드, 스킨 코드, 스킨 이름, 사용가능한지, 이용되고 있는지를 간추려냄
{
    public Skin(string _heroCode, int _skinCode, string _skinName, bool _canUse, bool _isUsing)
    {
        code = _heroCode;
        skinCode = _skinCode;
        skinName = _skinName;
        canUse = _canUse;
        isUsing = _isUsing;
    }
    public string code;
    public int skinCode;
    public string skinName;
    public bool canUse;
    public bool isUsing;
}
[System.Serializable]
public class HeroInfo//히어로 레벨과 가지고 있는 지의 여부 저장
{
    public HeroInfo(string _heroCode, int _level, float _exp, List<string> _itmeList, List<string> _skinList)
    {
        code = _heroCode; 
        level = _level;
        exp = _exp;
        itemList = _itmeList;
        skinList = _skinList;
    }
    public string code;
    public string name;
    public int level;
    public float exp;
    public List<string> itemList;
    public List<string> skinList;
}

[System.Serializable]
public class UserInfo
{
    public UserInfo(string _name, int _level, float _exp, int _gold, int _diamond, int _stamina)
    {
        name = _name;
        level = _level;
        exp = _exp;
        gold = _gold;
        diamond = _diamond;
        stamina = _stamina;
    }
    public string name;
    public int level;
    public float exp;
    public int gold;
    public int diamond;
    public int stamina;
}

