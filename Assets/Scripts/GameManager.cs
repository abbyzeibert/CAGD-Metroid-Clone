using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //todo: 
    //create enemy script with given health and damage variables

    private int playerHealth = 99;
    private int maxPlayerHealth = 99;

    public bool[] itemIDs = new bool[4];

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(GameObject toHurt, Collider other)
    {
        int damage = 0;

        if (other.CompareTag("PlayerProjectile"))
        {
            damage = other.GetComponent<Projectile>().damage;
        }
        else
        {
            damage = other.GetComponent<Enemy>().damage;
        }

        if (toHurt.CompareTag("Player"))
        {
            playerHealth -= damage;
        }
        else
        {
            toHurt.GetComponent<Enemy>().health -= damage;
        }
    }

    public void Heal(int amount)
    {
        if(playerHealth + amount > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }
        else
        {
            playerHealth += amount;
        }
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxPlayerHealth += amount;
        playerHealth = maxPlayerHealth;
    }

    public void ChangeScene(int scene, int door)
    {
        SceneManager.LoadScene(scene);
    }
}
