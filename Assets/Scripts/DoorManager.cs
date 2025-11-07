using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Abby Zeibert
 * 11/06/2025
 * Holds door information for the scene
 */

public class DoorManager : MonoBehaviour
{
    //list of doors in the scene, used to correctly place player at the door they entered from
    public GameObject[] doorSpawns = new GameObject[1];

}
