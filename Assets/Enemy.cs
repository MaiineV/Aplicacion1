using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private Transform[] wayPoints;
    private int actualWaypoint = 0;

    // Update is called once per frame
    void Update()
    {
        FollowPath();
        Move(wayPoints[actualWaypoint].position);
    }

    private void FollowPath()
    {
        if (Vector3.Distance(wayPoints[actualWaypoint].position, transform.position) < .2f)
        {
            actualWaypoint++;

            if (actualWaypoint >= wayPoints.Length) actualWaypoint = 0;
        }
    }
}
