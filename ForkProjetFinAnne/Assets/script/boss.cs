using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    Rigidbody rb;
    public float distance;
    public Transform target;
    //Rango de distancias  
    public float lookAtDistance = 15.0f;
    public float attackRange = 10.0f;
    public float moveSpeed = 5.0f;
    public float jumpForce = 2.0f;
    public Vector3 jump;
    public int jumpRangeMin = 6;
    public int jumpRangeMax = 5;
    public int jumpYSpeed = 50;
    public int jumpZSpeed = 10;

    public static int hp = 1; 
    public float damping = 6.0f;
    public bool grounded = false;

    public float maxSlope = 60; //grados limite de inclinacion de superficie desde la cual es posible saltar

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);

        if (distance < lookAtDistance)
        {
            lookAt();
        }

        if (distance < attackRange)
        {
            attack();
        }

        if (distance < jumpRangeMin && distance > jumpRangeMax)
        {
            Jump();
        }
    }


    void lookAt()
    {
        var rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    void attack()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (grounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }

    }
    //Detects ground till maxSlope and set grounded to true or false
    void OnCollisionStay(Collision collision)
    {
        //for (var contact  ContactPoint in collision.contacts)
        {
            //if (Vector3.Angle(contact.normal, Vector3.up) < maxSlope)  //si el angulo de contacto es menor que maxSlope
            grounded = true;                                       //setea grounded como true
        }
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))

        {
            //Destroy(gameObject);

            hp -= 1;

        }
        
    }
}
    


