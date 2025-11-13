using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Kafka Suenishi
 * 11/10/25
 * makes enemy track and follow player if player gets within certain distance
 */

public class EnemyFollow : MonoBehaviour
{

   
    private Transform target;
    public float speed = 5.0f;
    public float range = 10f;


    // Start is called before the first frame update
    void Start()
    {
        //sets the target as the player
        target = GameObject.Find("Wizard!!").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //moves enemy towards player current position
        if (Vector3.Distance(transform.position, target.position) < range)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
