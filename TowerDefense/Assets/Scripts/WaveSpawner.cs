using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] 
    private GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWave(10));
    }


    private IEnumerator StartWave(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }
}
