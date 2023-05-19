using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private float timeToLive = 1;
    public float damage;
    private void Start()
    {
        StartCoroutine(TTL());
    }

    private IEnumerator TTL()
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }
}
