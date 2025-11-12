using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Abby Zeibert
 * 11/07/2025
 * Handles given item's ID and function
 */

public class Item : MonoBehaviour
{
    /// <summary>
    /// IMPORTANT: Each item instance needs its own unique ID, make sure to update Game Manager's 
    /// itemIDs array with more indexes if adding more
    /// </summary>
    public int ID = 0;

    /// <summary>
    /// amount to heal player, only used by health pack
    /// </summary>
    public int toHeal = 0;

    /// <summary>
    /// only used for projectile upgrades, can be NULL otherwise
    /// </summary>
    public GameObject newProjectile;

    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        //if item has already been collected, destroy it on start
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if(manager.itemIDs[ID])
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //when player collides with an item, determines its function by its item ID, collects it, and destroys it
        if (other.CompareTag("Player"))
        {
            switch (ID)
            {
                case 0:
                    manager.Heal(toHeal);
                    break;
                case 1:
                    manager.IncreaseMaxHealth(100);
                    break;
                case 2:
                    manager.ChangeProjectile(newProjectile);
                    break;
                case 3:
                    manager.ChangeJumpForce(20f);
                    break;
            }
            manager.CollectItem(ID);
            Destroy(gameObject);
        }
    }

}
