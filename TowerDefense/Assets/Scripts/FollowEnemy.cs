using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    
    public float speed = 20f;
    public float turretRadius = 10f;
    private Transform target;
    private Transform[] cannon;
    [SerializeField] private GameObject bullet;

    private void Start()
    {
        cannon = this.GetComponentsInChildren<Transform>();
    }

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
        Collider[] enemiesinRange = Physics.OverlapSphere(transform.position, turretRadius, LayerMask.GetMask("Enemy"));
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
        StartCoroutine(Fire(newDirection));
    }

    private IEnumerator Fire(Vector3 direction)
    {
        foreach (var barrel in cannon)
        {
            Instantiate(bullet, barrel.position, Quaternion.LookRotation(direction)).GetComponent<Rigidbody>().AddForce(direction*5000, ForceMode.Acceleration);
        }

        yield return new WaitForSeconds(1);
    }

    private void destroyAfterTTL(GameObject bullet)
    {
        
    }
}
