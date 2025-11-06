using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 1;
    public int damage = 5;
    
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().Damage(other.gameObject, damage);
        }
    }

}
