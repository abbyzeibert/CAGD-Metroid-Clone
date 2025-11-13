using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Abby Zeibert
 * 11/07/2025
 * Handles launching of projectiles from game objects
 */

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectile;

    //player variables
    public bool isPlayer = false;
    public float fireCooldown = 0.5f;
    public bool canFire = true;
    private float zPos = 0;

    //enemy variables
    public float fireTime = 2f;
    public float waitTime = 5f;



    // Start is called before the first frame update
    void Start()
    {
        //if not the player, fires on a fixed interval
        if (!isPlayer)
        {
            InvokeRepeating("Fire", waitTime, fireTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if script is on the player and cooldown has stopped, fires a projectile and starts cooldown
        if (isPlayer && Input.GetKey("space") && canFire)
        {
            Fire();
            canFire = false;
            StartCoroutine("FireWait");
        }
        //moves firing point to 0 on z axis to ensure projectiles are properly aligned, 
        //mainly for player to fix issue of firing point getting misaligned when turning
        transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
    }

    /// <summary>
    /// Fires a projectile with launcher's position and rotation
    /// </summary>
    private void Fire()
    {
        //if player is firing, checks Game Manager for projectile since it can change
        if (isPlayer)
        {
            projectile = GameObject.Find("Game Manager").GetComponent<GameManager>().playerProjectile;
        }
        Instantiate(projectile, transform.position, transform.rotation);
    }

    /// <summary>
    /// Waits a short time before allowing player to fire again
    /// </summary>
    /// <returns></returns>
    IEnumerator FireWait()
    {
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
    }
}
