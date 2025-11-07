using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Abby Zeibert
 * 11/07/2025
 * Handles player information between scenes, game-wide functions, and UI
 */

public class GameManager : MonoBehaviour
{
    //player variables
    private int playerHealth = 99;
    private int maxPlayerHealth = 99;
    public int jumpForce = 10;
    public GameObject playerProjectile;

    //item ID array, true means item has been collected already
    public bool[] itemIDs = new bool[4];

    //object variables, used to find relavent objects after a scene transition
    private DoorManager doors;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        //makes manager and its data persist between scenes
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// General damage function
    /// </summary>
    /// <param name="toHurt"> Entity to apply damage to </param>
    /// <param name="damage"> How much damage to apply </param>
    public void Damage(GameObject toHurt, int damage)
    {
        //if player is being hurt, decrease health and check for gameover
        if (toHurt.CompareTag("Player"))
        {
            playerHealth -= damage;
            if(playerHealth <= 0)
            {
                GameOver();
            }
        }
        //only other thing that can be damaged are enemies, updates their script with damage taken
        else
        {
            toHurt.GetComponent<Enemy>().health -= damage;
        }
    }

    /// <summary>
    /// Heals the player
    /// </summary>
    /// <param name="amount"> How much health to restore </param>
    public void Heal(int amount)
    {
        //if amount healed would be above max, set to max, else add full amount to playerHealth
        if(playerHealth + amount > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }
        else
        {
            playerHealth += amount;
        }
    }

    /// <summary>
    /// Increases the maximum health of the player
    /// </summary>
    /// <param name="amount"> How much max health should be increased by </param>
    public void IncreaseMaxHealth(int amount)
    {
        //increases the max health, then heals the player to that new amount
        maxPlayerHealth += amount;
        playerHealth = maxPlayerHealth;
    }

    /// <summary>
    /// Changes the force applied to the player when they jump
    /// </summary>
    /// <param name="amount"> What the jump force should be set to </param>
    public void ChangeJumpForce(float amount)
    {
        player.GetComponent<PlayerMovement>().jumpForce = amount;
    }
    
    /// <summary>
    /// Changes the projectile that the player fires
    /// </summary>
    /// <param name="newProjectile"> Prefab of the projectile to change to </param>
    public void ChangeProjectile(GameObject newProjectile)
    {
        playerProjectile = newProjectile;
    }

    /// <summary>
    /// Basic item collect to prevent respawning already collected items on scene transitions
    /// </summary>
    /// <param name="ID"> Item ID of the item collected </param>
    public void CollectItem(int ID)
    {
        itemIDs[ID] = true;
    }

    /// <summary>
    /// Base scene transition function, loads new scene, then starts coroutine for spawn position
    /// </summary>
    /// <param name="scene"> Scene index in Build Settings to transition to </param>
    /// <param name="door"> Door index in next scene's Door Manager to spawn from </param>
    public void ChangeScene(int scene, int door)
    {
        SceneManager.LoadScene(scene);
        Debug.Log("Loaded Scene " + scene);
        StartCoroutine(WaitForSceneLoad(door));
    }

    /// <summary>
    /// Game Over function, currently only disables the player when they have no health
    /// </summary>
    public void GameOver()
    {
        player.SetActive(false);
    }

    /// <summary>
    /// Coroutine to handle spawn location on transitioning scenes, needed to ensure
    ///  Door Manager and Player are loaded before trying to access them
    /// </summary>
    /// <param name="door"> Door index in next scene's Door Manager to spawn from </param>
    /// <returns></returns>
    IEnumerator WaitForSceneLoad(int door)
    {
        //once scene is loaded, finds Door Manager and Player in scene
        yield return new WaitForSeconds(0.05f);
        doors = GameObject.Find("Door Manager").GetComponent<DoorManager>();
        player = GameObject.Find("Wizard!!");

        //moves player to given door's spawn position
        player.transform.position = doors.doorSpawns[door].transform.position;
    }
}
