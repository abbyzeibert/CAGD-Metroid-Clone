using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Abby Zeibert
 * 11/07/2025
 * rotates player arm in order to angle projectiles
 */

public class ArmRotate : MonoBehaviour
{
    //player orientation, 1 is right, -1 is left, 0 is not moving
    public int direction = 1;

    //used to fix issue of arm moving incorrectly when angled during a direction change
    //by resetting arm's z position when angled
    private float zPos = -0.581f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //angles arm 45 degrees up based on which way player is facing
        if (Input.GetKey("up"))
        {
            if(direction == -1)
            {
                transform.rotation = Quaternion.Euler(0, 0, -45);
            }
            else if(direction == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, -135);
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
        }
        //angles arm 45 degrees down based on which way player is facing
        else if (Input.GetKey("down"))
        {
            if (direction == -1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 45);
            }
            else if (direction == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 135);
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
        }
        //resets arm position to be flat when not holding aim buttons
        else
        {
            if(direction == 1)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if(direction == -1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
