using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectile;

    public bool isPlayer = false;
    public float fireCooldown = 0.5f;
    public bool canFire = true;

    public float fireTime = 2f;
    public float waitTime = 5f;

    private float zPos = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (!isPlayer)
        {
            InvokeRepeating("Fire", waitTime, fireTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer && Input.GetKeyDown("space") && canFire)
        {
            Fire();
            canFire = false;
            StartCoroutine("FireWait");
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
    }

    private void Fire()
    {
        projectile = GameObject.Find("Game Manager").GetComponent<GameManager>().playerProjectile;
        Instantiate(projectile, transform.position, transform.rotation);
    }

    IEnumerator FireWait()
    {
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
    }
}
