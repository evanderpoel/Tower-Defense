using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{

    public GameObject target;
    public float speed = 20f;


    // Update is called once per frame
    void Update()
    {
        TrackEnemy();
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
