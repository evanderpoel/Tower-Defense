using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    
    public float speed = 20f;
    public float turretRadius = 10f;
    private Transform target;


    // Update is called once per frame
    void Update()
    {
        if (isEnemyInRange())
        {
            TrackEnemy();
        }
    }

    private bool isEnemyInRange()
    {
        Collider[] enemiesinRange = Physics.OverlapSphere(transform.position, turretRadius, 6);
        if (enemiesinRange.Length == 0)
        {
            return false;
        }
        float closestEnemyRange = float.MaxValue;
        foreach (var enemy in enemiesinRange)
        {
            float distanceBetween = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceBetween < closestEnemyRange)
            {
                target = enemy.transform;
                closestEnemyRange = distanceBetween;
            }
        }

        return true;
    }

    private void TrackEnemy()
    {
        Vector3 targetDirection = target.transform.position - transform.position;
        
        float singleStep = speed * Time.deltaTime;

        
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        
        Debug.DrawRay(transform.position, newDirection, Color.red);
        
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
