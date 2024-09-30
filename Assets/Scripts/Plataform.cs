using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private int actualIndex;
    [SerializeField] private float speed;
    public Vector3 dir {  get; private set; }

    [SerializeField] private Rigidbody _rb;


    void Update()
    {
        dir = (waypoints[actualIndex].position - transform.position).normalized * speed;
        transform.position +=  dir * Time.deltaTime;

        if(Vector3.Distance(transform.position, waypoints[actualIndex].position) < .5f) 
        {
            actualIndex++;

            if (actualIndex >= waypoints.Length)
            {
                actualIndex = 0;
            }
        }
    }
}
