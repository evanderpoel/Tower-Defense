
using System.Collections;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    
    public float speed = 20f;
    public float turretRadius = 10f;
    private Transform target;
    private Transform[] cannon;
    [SerializeField] private GameObject bullet;
    private bool firingRange = false;
    private bool enemyInRange = false;
    private Vector3 targetDirection;

    private void Start()
    {
        cannon = this.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyInRange())
        {
            enemyInRange = true;
            TrackEnemy();
            firingRange = true;
        }
        else
        {
            enemyInRange = false;
            firingRange = false;
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
        targetDirection = target.transform.position - transform.position;
        
        float singleStep = speed * Time.deltaTime;

        
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        
        Debug.DrawRay(transform.position, newDirection, Color.red);
        
        transform.rotation = Quaternion.LookRotation(newDirection);
        if (!firingRange)
        {
            StartCoroutine(Fire(singleStep));            
        }
    }

    private IEnumerator Fire(float singleStep)
    {
        yield return new WaitForSeconds(0.25f);
        while (enemyInRange)
        {
            foreach (var barrel in cannon)
            {
                Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                Instantiate(bullet, barrel.position, Quaternion.LookRotation(direction)).GetComponent<Rigidbody>().AddForce(direction*5000, ForceMode.Acceleration);
            }

            yield return new WaitForSeconds(0.5f);
        }

    }
}
