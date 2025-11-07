using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Abby Zeibert
 * 11/07/2025
 * Handles projectile movement, damage, and destruction
 */

public class Projectile : MonoBehaviour
{
    public float speed = 15f;

    public int damage = 1;

    // Update is called once per frame
    void Update()
    {
        //moves the projectile forward
        transform.Translate(0, (speed * Time.deltaTime), 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //destroys the projectile if it hits a wall or floor
        if(other.CompareTag("Wall") || other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        //damages an enemy when it hits it
        else if (other.GetComponent<Enemy>())
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().Damage(other.gameObject, damage);
            Destroy(gameObject);
        }
        //destroys weak doors when it hits
        else if (other.CompareTag("WeakDoor"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        //uses projectile damage to determine if it can destroy strong doors
        else if (other.CompareTag("StrongDoor"))
        {
            if(damage > 1)
            {
                Destroy(other.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
