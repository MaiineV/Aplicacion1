using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour,IDamagable
{
    public float GetLife { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Health(float damage)
    {
        throw new System.NotImplementedException();
    }

    public bool ReciveDamage(float damage)
    {
        Destroy(gameObject);
        return true;
    }
}
