using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDistance : MonoBehaviour
{
    private Human human;
    private void Awake()
    {
        human = GetComponentInParent<Human>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Human>() != null)
            human.AddAttackTarget(other.gameObject);
    }
}
