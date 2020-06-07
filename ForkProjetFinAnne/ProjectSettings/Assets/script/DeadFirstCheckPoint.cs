using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadFirstCheckPoint : MonoBehaviour
{
    public Vector3 respawnPosition;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "player")
        {
            col.transform.position = respawnPosition;
        }
    }
}
