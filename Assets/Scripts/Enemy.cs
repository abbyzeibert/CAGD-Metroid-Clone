using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Abby Zeibert
 * 11/06/2025
 * Handles basic enemy information
 */

public class Enemy : MonoBehaviour
{

    public int health = 1;
    public int damage = 5;
    
    private void Update()
    {
        //destroys the enemy when they are out of health
        if (health <= 0)
        {
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
