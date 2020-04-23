/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    Rigidbody rgb;
    public bool isGrounded;

    //public Transform feetPos;
    //public float checkRadius;
    //public LayerMask whatIsGround;

    //private float jumpTimeCounter;
    //public float jumpTime;
    //private bool isJumping;

    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    //void OnCollisionStay()
    //{
    //    isGrounded = true;
    //}
    private void Update()
    {
        //right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

        //left
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
        }

    //    isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
    //    //jump
    //    if (Input.GetKey(KeyCode.Space) && isGrounded)
    //    {
    //        rgb.AddForce(jump * jumpForce, ForceMode.Impulse);
    //        isGrounded = false;
    //    }

    //    if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
    //    {
    //        rgb.AddForce(jump * jumpForce, ForceMode.Impulse);
    //    }

    //    if (Input.GetKey(KeyCode.Space) && isJumping == true)
    //    {
    //        if (jumpTimeCounter > 0)
    //        {
    //            rgb.AddForce(jump * jumpForce, ForceMode.Impulse);
    //            jumpTimeCounter -= Time.deltaTime;
    //            isGrounded = false;
    //        }
    //        else
    //        {
    //            isJumping = false;
    //        }

    //    }

    //    if(Input.GetKeyUp(KeyCode.Space))
    //    {
    //        isJumping = false;
    //    }
    }
}*/
