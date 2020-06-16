using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiwalljump : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //Note: we use colliders here, not collisions
        if (other.gameObject.name == "wall")
        {
            Debug.Log("Collided");
            
        }
    }
}
