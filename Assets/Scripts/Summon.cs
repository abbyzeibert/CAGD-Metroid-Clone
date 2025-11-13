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
        
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("SpawnEnemy", 1, enemySpawnRate);
    }

    //ok so Boss hp = 100, for every spawned enemy defeated WITH A PROJECTILE 
    //boss hp -10



    private void SpawnEnemy()
    {
        int randnum = Random.Range(0, 12);
        if (randnum <= 3)
            Instantiate(ghostPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        else if (randnum > 3 && randnum <= 6)
        Instantiate(ghostPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

        if (skeletonPrefab.transform.position.y < -4)
        {
            Destroy(skeletonPrefab);
        }
    }


}
