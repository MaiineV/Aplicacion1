using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum EnemyType 
{
    MELEE,
    RANGE,
    TANK,
    BOSS
}

public class Enemy : Entity, IDamagable
{

    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float detectionRange;
    [SerializeField] private LayerMask playerMask;
    private int actualWaypoint = 0;
    private EnemyData enemyData;
    private Transform target;

    public bool isSolid;

    [SerializeField] public EnemyType enemyType; 

    public float GetLife { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private void Awake()
    {
        enemyData = new EnemyData();
        enemyData.damage = Random.Range(10, 15);
        enemyData.skin = new Mesh();
        enemyData.attackType = "Melee";
    }

    void Update()
    {
        Collider[] result = Physics.OverlapSphere(transform.position, detectionRange, playerMask);

        if (result.Length > 0)
        {
            target = result[0].transform;
        }

        if (target != null)
        {
            Move(target.position);
        }
        else if (wayPoints.Length > 0)
        {
            FollowPath();
            Move(wayPoints[actualWaypoint].position);
        }
    }

    private void FollowPath()
    {
        if (Vector3.Distance(wayPoints[actualWaypoint].position, transform.position) < .2f)
        {
            actualWaypoint++;

            if (actualWaypoint >= wayPoints.Length) actualWaypoint = 0;
        }
    }

    public void SetWaypoints(Transform[] newWaypoints)
    {
        wayPoints = newWaypoints;
    }

    private void OnDrawGizmos()
    {
        if (isSolid)
        {
            Gizmos.DrawSphere(transform.position, detectionRange);
        }
        else
        {
            Gizmos.DrawWireSphere(transform.position, detectionRange);
        }
    }

    public bool ReciveDamage(float damage)
    {
        Debug.Log(life);
        life-=damage;

        Debug.Log(life);
        if (life <= 0)
        {
            Destroy(gameObject, .5f);
            return true;
        }
        
        return false;
    }

    public void Health(float damage)
    {
        throw new System.NotImplementedException();
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
