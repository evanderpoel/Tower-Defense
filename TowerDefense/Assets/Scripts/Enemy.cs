using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    public ParticleSystem ps;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            DecreaseHealth(other.gameObject.GetComponent<BulletBehaviour>().damage);
            Destroy(other.gameObject);
        }
    }

    private void DecreaseHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Instantiate(ps, this.transform);
        ps.Play();
        Destroy(gameObject);
    }
}
