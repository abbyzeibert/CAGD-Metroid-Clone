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
    }

    private void Fire()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }

    IEnumerator FireWait()
    {
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
    }
}
