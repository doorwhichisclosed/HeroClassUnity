using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Hero Database", menuName = "Hero DataBase/Hero Database", order = int.MaxValue)]
public class HeroDB : ScriptableObject
{
    public Image CharacterImage;//캐럭터 이미지를 넣어주세요
    public string CharacterDescription;//캐릭터 설명을 입력해주세요
    public string Code;//캐릭터 코드를 입력해주세요
    public string Name;//캐릭터 이름을 입력해주세요
    public string LevelHP;//StatValue에 수식을 넣어야 작동합니다.
    public string LevelDamage;//레벨 당 오를 정도를 수식으로 입력해주세요(띄어쓰기 필수) StatValue에 수식을 넣어야 작동합니다.
    public string LevelSpeed;//StatValue에 수식을 넣어야 작동합니다.
    public GameObject Character;//캐릭터 내용물을 넣어주세요
    public string MoveDistance;//이동거리 입력해주세요
    public string AttackDistance;//공격거리 입력해주세요
}
