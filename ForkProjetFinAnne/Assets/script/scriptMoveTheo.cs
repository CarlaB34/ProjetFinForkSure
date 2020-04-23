using UnityEngine;
using System.Collections;

public class scriptMoveTheo : MonoBehaviour
{
    //Movement
    public float speed;

    float moveVelocity;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;
    //Grounded Vars

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    //void OnCollisionExit()
    //{
    //    isGrounded = false;
    //}
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && rb.velocity.y <= 0)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }


        moveVelocity = 0;

        //Left Right Movement
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += Vector3.right * -moveVelocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * -moveVelocity * Time.deltaTime;
        }

      //  GetComponent<Rigidbody>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody>().velocity.y);


    }


}