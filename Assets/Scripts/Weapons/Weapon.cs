using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class Weapon : MonoBehaviour
{
    [SerializeField] public WeaponData weaponData;
    [SerializeField] protected Player player;

    public WeaponType type;

    public static Weapon operator +(Weapon a, Weapon b)
    {
        var weaponData = new WeaponData() 
        { 
            dmg = a.weaponData.dmg + b.weaponData.dmg,
            attackSpeed = a.weaponData.attackSpeed + b.weaponData.attackSpeed,
            range = a.weaponData.range + b.weaponData.range,
        };

        a.weaponData = weaponData;

        return a;
    }

    public virtual void Attack()
    {
        Debug.Log("pum");
    }

    public void UpdateMesh()
    {
        Debug.Log("cambie mesh");
    }
}

[Serializable]
public class WeaponData
{
    public float dmg;
    public float attackSpeed;
    public float range;
    public Mesh mesh;
    public Material material;
}
