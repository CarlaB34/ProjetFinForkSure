using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomBoss : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            SceneManager.LoadScene("LoadingScene4");

        }
    }
}
