using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Abby Zeibert
 * 11/12/2025
 * Handles basic enemy information
 */

public class Enemy : MonoBehaviour
{

    public int health = 1;
    public int damage = 5;

    public bool boss = false;
    public bool minion = false;
    
    private void Update()
    {
        //destroys the enemy when they are out of health
        if (health <= 0)
        {
            if (minion)
            {
                GameObject.Find("Game Manager").GetComponent<GameManager>().Damage(GameObject.Find("FinalBoss"), 50);
            }
            else if (boss)
            {
                GameObject.Find("Game Manager").GetComponent<GameManager>().ChangeScene(7,0);
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //damages the player when collided with, passes its damage value to the game manager
        if (other.GetComponent<PlayerMovement>())
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().Damage(other.gameObject, damage);
        }
    }

}
