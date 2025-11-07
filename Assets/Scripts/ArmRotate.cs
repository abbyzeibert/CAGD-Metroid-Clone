using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotate : MonoBehaviour
{
    public int direction = 1;

    private float zPos = -0.581f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            if(direction == -1)
            {
                transform.rotation = Quaternion.Euler(0, 0, -45);
            }
            else if(direction == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, -135);
                transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
        }
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
