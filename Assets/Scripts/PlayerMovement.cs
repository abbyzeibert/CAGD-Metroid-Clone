using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Abby Zeibert
 * 11/07/2025
 * Handles player's movement
 */

public class PlayerMovement : MonoBehaviour
{
    //movement variables
    public float speed = 10f;
    public float jumpForce = 10f;
    public int direction = 1;
    public int prevDirection = 1;
    public float wizardHeight = 1.5f;
    public float armMoveOnRotate = 1f;

    //timer variables
    public float coyoteTime = 0.2f;
    public float jumpTimer = 0.5f;

    //player state variables
    public bool grounded = false;
    public bool justJumped = false;

    //component variables
    public GameObject arm;
    public ArmRotate armScript;
    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        Jump();
        CheckForGround();
    }

    private void FixedUpdate()
    {
        //moves in FixedUpdate to prevent clipping through walls
        Move();
    }

    /// <summary>
    /// Handles moving player and what direction they're facing
    /// </summary>
    private void Move()
    {
        rb.MovePosition(transform.position + (speed * Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime));

        //gets direction of player from button pressed, 1 = right, -1 = left, 0 = standing still
        direction = (int)Input.GetAxisRaw("Horizontal");
        Turn();
    }

    /// <summary>
    /// Handles turning the player and updates required with that
    /// </summary>
    private void Turn()
    {
        //only turns the player if they're facing a different direction than they were previously and not standing still
        if(direction != 0 && direction != prevDirection)
        {
            //rotates the player, updates arm's rotation script, and moves arm to the front facing side of the body
            transform.Rotate(0, 180, 0);
            prevDirection = direction;
            armScript.direction = direction;
            arm.transform.Translate(0, 0, (armMoveOnRotate * direction));
        }
    }

    /// <summary>
    /// Handles player jumping and starts countdown before player can jump again
    /// </summary>
    private void Jump()
    {
        //only jumps when player is on the ground and has not just jumped
        if(Input.GetButtonDown("Jump") && grounded && !justJumped)
        {
            //checks current jump force from stored value in Game Manager since it can change
            jumpForce = GameObject.Find("Game Manager").GetComponent<GameManager>().jumpForce;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            justJumped = true;
            grounded = false;
            StartCoroutine("JustJumpedCountdown");
        }
    }

    /// <summary>
    /// Raycasts down to check if the player is touching the ground
    /// </summary>
    private void CheckForGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, wizardHeight))
        {
            if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Platform"))
            {
                grounded = true;
            }
            
        }
        //when player leaves ground, starts timer for when they can no longer jump
        else
        {
            StartCoroutine("CoyoteCountdown");
        }
    }

    /// <summary>
    /// Waits a short time before considering player no longer on the ground
    /// </summary>
    /// <returns></returns>
    IEnumerator CoyoteCountdown()
    {
        yield return new WaitForSeconds(coyoteTime);
        grounded = false;
    }

    /// <summary>
    /// Waits a short time before considering player to not have just jumped
    /// </summary>
    /// <returns></returns>
    IEnumerator JustJumpedCountdown()
    {
        yield return new WaitForSeconds(jumpTimer);
        justJumped = false;
    }
}
