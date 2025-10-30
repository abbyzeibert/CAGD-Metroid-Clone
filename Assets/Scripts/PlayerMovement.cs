using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//todo:
//remove collider from wizard parts and replace with single collider on parent


public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public int direction = 1;
    public int prevDirection = 1;
    public float wizardHeight = 1.5f;

    public float coyoteTime = 0.2f;
    public float jumpTimer = 0.2f;

    public bool grounded = false;
    public bool justJumped = false;

    public float armMoveOnRotate = 1f;
    public GameObject arm;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        CheckForGround();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position += speed * Vector3.left * Input.GetAxis("Horizontal") * Time.deltaTime;

        direction = (int)Input.GetAxisRaw("Horizontal");
        Turn();
    }

    private void Turn()
    {
        if(direction != 0 && direction != prevDirection)
        {
            transform.Rotate(0, 180, 0);
            prevDirection = direction;
            arm.transform.Translate(0, 0, (armMoveOnRotate * direction));
        }
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && grounded && !justJumped)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            justJumped = true;
            grounded = false;
            StartCoroutine("JustJumpedCountdown");
        }
    }

    private void CheckForGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, wizardHeight))
        {
            Debug.Log("Hit Something:" + hit.collider.gameObject.name);
            if (hit.collider.CompareTag("Ground"))
            {
                Debug.Log("Found ground");
                grounded = true;
            }
            
        }
        else
        {
            StartCoroutine("CoyoteCountdown");
        }
    }

    IEnumerator CoyoteCountdown()
    {
        yield return new WaitForSeconds(coyoteTime);
        grounded = false;
    }

    IEnumerator JustJumpedCountdown()
    {
        yield return new WaitForSeconds(jumpTimer);
        justJumped = false;
    }
}
