using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NullSave.TOCK.Stats;

public class Human : MonoBehaviour
{
    public string code;//Human 구별 code
    public string _name;//Human 이름
    public string opponent;//적 tag입력
    public float hp;//체력
    public float damage;//공격력
    public float speed;//속도
    public float moveDistance;//이동 범위
    public float attackDistance;//공격 범위
    public Queue<Human> moveTarget = new Queue<Human>();//움직일 target 담아둠
    public Queue<Human> attackTarget = new Queue<Human>();//공격할 target 담아둠
    public GameObject design;//캐릭터 생김새
    public float attackTime;//임시
    public bool isAttack;//임시

    public SphereCollider moveTargetDistance;//이동범위 트리거
    public SphereCollider attackTargetDistance;//공격범위 트리거
   

    public void LoadDesign()//디자인 불러옴
    {
        GameObject characterDesign = Instantiate(design, transform.position, transform.rotation);
        characterDesign.transform.parent = gameObject.transform;
    }

    public virtual void UpdateStatus()
    {
        Debug.Log("캐릭터 업데이트");
    }

    /*public bool IsAttack()
    {

    }*/

    public void Attack()//공격
    {
        Human target = attackTarget.Peek();
        Vector3 distance = target.transform.position - transform.position;
        if (target.gameObject == null || !target.gameObject.activeInHierarchy || Vector3.Magnitude(distance) > attackTargetDistance.bounds.size.x)
            DeleteAttackTarget();
        else if (target.gameObject.activeInHierarchy && target.gameObject != null)
            StartCoroutine("AttackMotion");
    }

    public void Move()//움직임
    {
        float step = speed * Time.deltaTime;
        if (moveTarget.Count == 0)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (moveTarget.Count != 0)//움직임 큐에 있는 첫번째 요소로 이동하고 이동범위 벗어나거나 사라졌을 경우 Dequeue해줌
        {
            Human target = moveTarget.Peek();
            Vector3 distance = target.transform.position - transform.position;
            if (target.gameObject == null || !target.gameObject.activeInHierarchy || Vector3.Magnitude(distance) > moveTargetDistance.bounds.size.x)
            {
                DeleteMoveTarget();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), step);
            }
        }
        else return;
    }

    public void AddAttackTarget(GameObject enemy)//큐에다가 공격가능한 적을 넣어줌
    {
        if (enemy.CompareTag(opponent))
        {
            attackTarget.Enqueue(enemy.GetComponent<Human>());
        }
    }

    public void DeleteAttackTarget()//큐에서 공격대상 삭제해줌
    {
        attackTarget.Dequeue();
    }

    public void AddMoveTarget(GameObject enemy)//큐에다가 이동 대상 적을 넣어줌
    {
        if (enemy.CompareTag(opponent))
        {
            moveTarget.Enqueue(enemy.GetComponent<Human>());
        }
    }

    public void DeleteMoveTarget()//큐에서 이동대상 삭제해줌
    {
        moveTarget.Dequeue();
    }

    public void ChangeHP(float effectInt)
    {
        if (GetComponent<StatsCog>() != null)
            GetComponent<StatsCog>().healthStat += effectInt;
        else
            hp += effectInt;
        if (hp <= 0)
            gameObject.SetActive(false);
    }

    public IEnumerator AttackMotion()//공격
    {
        isAttack = true;
        if (attackTarget.Peek() != null)
        {
            if(GetComponent<StatsCog>()!=null)
                GetComponent<DamageDealer>().DealDamage(attackTarget.Peek().GetComponent<DamageReceiver>());
        }
        yield return new WaitForSeconds(attackTime);//후에 애니메이션 재생 여부로 교체할 겁니다.
        isAttack = false;
    }
}
