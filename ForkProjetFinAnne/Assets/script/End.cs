using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject Key2;
    public Vector3 spawnSpot2 = new Vector3(8.52f, 5.22f, -1.742f);

    void OnCollisionEnter(Collision collision) // ajouter 1 a la variable Key lorsqu'on touche la clé 
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameObject Sphere002 = (GameObject)Instantiate(Key2, new Vector3(-22.52f, 5.8f, -0.5636545f), transform.rotation);
        }
    }
}
