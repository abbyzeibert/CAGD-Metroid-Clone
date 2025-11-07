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
    public GameObject playerProjectile;

    public bool[] itemIDs = new bool[4];

    private DoorManager doors;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(GameObject toHurt, int damage)
    {
        if (toHurt.CompareTag("Player"))
        {
            playerHealth -= damage;
            if(playerHealth <= 0)
            {
                GameOver();
            }
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

    public void ChangeJumpForce(float amount)
    {
        player.GetComponent<PlayerMovement>().jumpForce = amount;
    }

    public void ChangeProjectile(GameObject newProjectile)
    {
        playerProjectile = newProjectile;
    }

    public void CollectItem(int ID)
    {
        itemIDs[ID] = true;
    }

    public void ChangeScene(int scene, int door)
    {
        SceneManager.LoadScene(scene);
        Debug.Log("Loaded Scene " + scene);
        StartCoroutine(WaitForSceneLoad(door));
    }

    public void GameOver()
    {
        player.SetActive(false);
    }

    IEnumerator WaitForSceneLoad(int door)
    {
        yield return new WaitForSeconds(0.05f);
        doors = GameObject.Find("Door Manager").GetComponent<DoorManager>();
        player = GameObject.Find("Wizard!!");

        player.transform.position = doors.doorSpawns[door].transform.position;
        Debug.Log("Moved player to " + player.transform.position);
    }
}
