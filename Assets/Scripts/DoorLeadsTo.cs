using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLeadsTo : MonoBehaviour
{
    public int leadsToDoor = 0;
    public int leadsToScene = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().ChangeScene(leadsToScene, leadsToDoor);
        }
    }
}
