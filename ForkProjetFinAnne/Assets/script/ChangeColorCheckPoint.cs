using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorCheckPoint : MonoBehaviour
{
    public Color redcolor;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            transform.GetComponent<Renderer>().material.color = redcolor;
        }
    }
}
