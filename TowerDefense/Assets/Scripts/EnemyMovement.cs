using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private int WayPointCount = 0;
    private float speed { get; set; }
    private Transform target;

    private Transform[] wayPoints;

    private void Start()
    {
        wayPoints = WayPointManager.WayPoints;
        target = wayPoints[WayPointCount];
        speed = 10;
    }

    private void Update()
    {
        if (isWayPointReached())
        {
            SetNextTarget();
        }
        Vector3 distanceToTarget = (target.position - transform.position).normalized;

        transform.Translate(distanceToTarget * speed * Time.deltaTime, Space.World);
    }

    private void SetNextTarget()
    {
        if (++WayPointCount < wayPoints.Length)
        {
            target = wayPoints[WayPointCount];
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private bool isWayPointReached()
    {
        return Vector3.Distance(transform.position, target.position) <= 0.4f;
    }

}
