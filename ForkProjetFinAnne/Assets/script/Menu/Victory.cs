using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
    }
        void OnCollisionEnter(Collision collision)

    {


        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
