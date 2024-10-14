using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float dmg;
    public float attackSpeed;
    public float range;
    [SerializeField] protected Player player;

    public virtual void Attack()
    {
        Debug.Log("pum");
    }
}
