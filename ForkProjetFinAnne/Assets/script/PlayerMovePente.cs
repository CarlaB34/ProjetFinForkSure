using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePente : MonoBehaviour
{
    CharacterController characterController;

    public float moveSpeed = 5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    //move de theo
    public bool isGrounded;
    private Vector3 moveDirection = Vector3.zero;
 

    void Start()
    {
      
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            moveDirection *= moveSpeed;


            //change profil
            //Vector3 moveProfil = new Vector3(0.0f, 0.0f, 0.0f);
            //transform.rotation = Quaternion.LookRotation(moveDirection);
            //transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);
            

            //jump
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
