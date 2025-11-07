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
    /*                                                                                              *
     *                                          ! IMPORTANT !                                       *
     *                                                                                              *
     *  Leads to Door: Set to the index of its corresponding door in the next scene's Door Manager  *
     *                                                                                              *
     *  Leads to Scene: Set to the index of the scene this door leads to as shown in Build Settings *
     *                                                                                              *
     *  IN SCENE: the object with this script should have its collider where the door is and its    *
     *              pivot point where the player will respawn when coming back through              *
     *                                                                                              *
     *                  DO NOT PUT THE PIVOT POINT AND COLLIDER IN THE SAME SPOT                    *
     *                                                                                              *
     */

    public int leadsToDoor = 0;
    public int leadsToScene = 0;

    private void OnTriggerEnter(Collider other)
    {
        //When player enters collider, pass information to Game Manager to change scene correctly
        if (other.CompareTag("Player"))
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().ChangeScene(leadsToScene, leadsToDoor);
        }
    }
}
