using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public float GetLife { get; set; }

    public bool ReciveDamage(float damage);
    public void Health(float damage);
}