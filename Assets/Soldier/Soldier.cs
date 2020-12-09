using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Human
{

    public int level;//레벨
    public int exp;//경험치

    public List<SoldierDB> soldierDBList;//soldierDB list
    private void Awake()
    {
        moveTargetDistance = transform.GetChild(0).GetComponent<SphereCollider>();//공격범위 이동범위 트리거 받아옴
        attackTargetDistance = transform.GetChild(1).GetComponent<SphereCollider>();
        UpdateStatus();//초기화
        LoadDesign();//디자인 불러옴
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
        for(int i=0;i<soldierDBList.Count;i++)//맞는 코드 찾아서 업데이트
        {
            if(soldierDBList[i].Code==this.code)
            {
                hp = level * soldierDBList[i].LevelHP + soldierDBList[i].BaseHP;
                damage = level * soldierDBList[i].LevelDamage;
                speed = level * soldierDBList[i].LevelSpeed;
                design = soldierDBList[i].Character;
                moveTargetDistance.radius = soldierDBList[i].MoveDistance;
                attackTargetDistance.radius = soldierDBList[i].AttackDistance;
                moveDistance = soldierDBList[i].MoveDistance;
                attackDistance = soldierDBList[i].AttackDistance;
                break;
            }
        }
    }
}
