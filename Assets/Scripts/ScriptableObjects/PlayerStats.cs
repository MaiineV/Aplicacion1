using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float damage;
    public float life;
    public float speed;
}
