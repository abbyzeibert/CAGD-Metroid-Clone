using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int ID = 0;

    public GameObject newProjectile;

    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if(manager.itemIDs[ID])
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (ID)
            {
                case 0:
                    manager.Heal(50);
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
