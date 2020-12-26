using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NullSave.TOCK.Stats;

public class TestWeapon : MonoBehaviour
{
    public StatModifier statModifier;
    float i;
    private void Start()
    {
        StartCoroutine("DamageAddTest");
    }

    private void Update()
    {

    }

    IEnumerator DamageAddTest()
    {
        GetComponent<StatsCog>().FindStat(statModifier.affectedStat).AddModifier(statModifier);
        yield return new WaitForSeconds(5f);
        GetComponent<StatsCog>().FindStat(statModifier.affectedStat).RemoveModifier(statModifier);
    }
}
