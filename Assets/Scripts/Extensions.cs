using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static void UpdateMesh(this Weapon[] weapons, Mesh newMesh)
    {
        foreach (var weapon in weapons)
        {
            weapon.UpdateMesh();
        }
    }

    public static float GetTotalDamage(this Weapon[] weapons)
    {
        var total = 0f;

        foreach (var weapon in weapons)
        {
            total += weapon.weaponData.dmg;
        }

        return total;
    }

    public static int GetRandomExponential(this int number)
    {
        int counter = number;
        while (true)
        {
            counter *= counter;
            var chance = Random.Range(0, 100);

            if (chance < 10)
                break;
        }

        return counter;
    }
}
