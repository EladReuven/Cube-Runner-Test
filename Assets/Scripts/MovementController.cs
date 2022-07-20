using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float force = 5;
    public float jumpForce = 10;
    float disToGround;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        disToGround = gameObject.GetComponent<Collider>().bounds.extents.y + 0.3f;
    }

    private void Update()
    {

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            MovementTest(new Vector3(0,0,1.5f));
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MovementTest(Vector3.left);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MovementTest(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            //gameObject.transform.position = transform.position + Vector3.up * jumpForce * Time.deltaTime;
            rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
        }
    }


    private void MovementTest(Vector3 dir)
    {


        //move by transform
        Vector3 newPos = transform.position + (dir * force * Time.deltaTime);
        //transform.position = newPos;


        //move with force
        //rb.AddForce(dir * force * Time.deltaTime);

        //rb.MovePosition(dir * force * Time.deltaTime + transform.position);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(gameObject.transform.position, -Vector3.up, disToGround);
    }
}
