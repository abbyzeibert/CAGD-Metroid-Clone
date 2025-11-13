using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Kafka Suenishi
 * 11/12/25
 * summons enemies between shooting projectiles
 */

public class Summon : MonoBehaviour
{

    public float enemySpawnRate = 5f;


    public GameObject ghostPrefab;
    public GameObject skeletonPrefab;
  
    public GameObject spawnPoint;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, enemySpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void SpawnEnemy()
    {
        int randnum = Random.Range(0, 10);
        if (randnum < 6)
            Instantiate(ghostPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        else if (randnum >= 6)
        Instantiate(skeletonPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

    }


}
