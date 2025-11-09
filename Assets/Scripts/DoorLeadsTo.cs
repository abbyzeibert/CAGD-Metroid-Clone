using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Abby Zeibert
 * 11/07/2025
 * Holds information for scene changes
 */

public class DoorLeadsTo : MonoBehaviour
{
    /// <summary>
    /// Set to the index of its corresponding door in the next scene's Door Manager
    /// </summary>
    public int leadsToDoor = 0;

    /// <summary>
    /// Set to the index of the scene this door leads to as shown in Build Settings
    /// </summary>
    public int leadsToScene = 0;

    /// <summary>
    /// Set to where the player will spawn when coming through this door, make sure it is NOT overlapping the door's collider
    /// </summary>
    public Vector3 spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        //When player enters collider, pass information to Game Manager to change scene correctly
        if (other.CompareTag("Player"))
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().ChangeScene(leadsToScene, leadsToDoor);
        }
    }
}
