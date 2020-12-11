using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NullSave.TOCK.Stats;

public class Soldier : Human
{

    public int level;//레벨
    public int exp;//경험치

    public List<SoldierDB> soldierDBList;//soldierDB list

    private StatsCog statsCog;
    private StatValue damageStat, hPStat, speedStat, damageAreaStat, moveAreaStat, levelStat;//StatValues
    private void Awake()
    {
        moveTargetDistance = transform.GetChild(0).GetComponent<SphereCollider>();//공격범위 이동범위 트리거 받아옴
        attackTargetDistance = transform.GetChild(1).GetComponent<SphereCollider>();
        statsCog = GetComponent<StatsCog>();
        FindStats();
        UpdateStatus();//status업데이트
        LoadDesign();//design불러옴
        AddValueChangedToStatValue();
    }

    private void Update()
    {
        if (attackTarget.Count != 0 && !isAttack)//공격큐에 무언가가 있다면 공격함
        {
            Attack();
        }
        else if (attackTarget.Count == 0 && !isAttack)//없으면 움직임
        {
            Move();
        }
        else
            return;
    }


    public override void UpdateStatus()//status 업데이트
    {
        for (int i = 0; i < soldierDBList.Count; i++)
        {
            if (soldierDBList[i].Code == this.code)
            {
                SoldierDB thisHero = soldierDBList[i];
                hPStat.value = thisHero.LevelHP;
                damageStat.value = thisHero.LevelDamage;
                damageAreaStat.value = thisHero.AttackDistance;
                moveAreaStat.value = thisHero.MoveDistance;
                speedStat.value = thisHero.LevelSpeed;
                this.design = thisHero.Character;
                levelStat.SetValue(level);
                break;
            }
        }
        speed = speedStat.CurrentValue;
        damage = damageStat.CurrentValue;
        hp = hPStat.CurrentValue;
        attackDistance = damageAreaStat.CurrentValue;
        moveDistance = moveAreaStat.CurrentValue;
        moveTargetDistance.radius = moveAreaStat.CurrentValue;
        attackTargetDistance.radius = damageAreaStat.CurrentValue;
    }

    #region ManagingStatValueEvents

    public void FindStats()
    {
        levelStat = statsCog.FindStat("Level");
        damageStat = statsCog.FindStat("Damage");
        hPStat = statsCog.FindStat("HP");
        speedStat = statsCog.FindStat("Speed");
        damageAreaStat = statsCog.FindStat("DamageArea");
        moveAreaStat = statsCog.FindStat("MoveArea");
    }
    public void OnLevelValueChanged(float oldValue, float newValue)
    {
        level = (int)levelStat.CurrentValue;
    }

    public void OnDamageValueChanged(float oldValue, float newValue)
    {
        damage = damageStat.CurrentValue;
    }

    public void OnDamageAreaValueChanged(float oldValue, float newValue)
    {
        attackDistance = damageAreaStat.CurrentValue;
    }

    public void OnMoveAreaChanged(float oldValue, float newValue)
    {
        moveDistance = moveAreaStat.CurrentValue;
    }

    public void OnHPlValueChanged(float oldValue, float newValue)
    {
        hp = hPStat.CurrentValue;
    }

    public void OnSpeedValueChanged(float oldValue, float newValue)
    {
        speed = speedStat.CurrentValue;
    }

    public void AddValueChangedToStatValue()
    {
        levelStat.onValueChanged.AddListener(OnLevelValueChanged);
        damageStat.onValueChanged.AddListener(OnDamageValueChanged);
        damageAreaStat.onValueChanged.AddListener(OnDamageAreaValueChanged);
        moveAreaStat.onValueChanged.AddListener(OnMoveAreaChanged);
        hPStat.onValueChanged.AddListener(OnHPlValueChanged);
        speedStat.onValueChanged.AddListener(OnSpeedValueChanged);
    }
    #endregion
}
