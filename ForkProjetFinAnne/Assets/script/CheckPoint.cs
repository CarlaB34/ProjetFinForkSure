using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    DeadFirstCheckPoint deadFirstCheckPoint;

    private void Start()
    {
        deadFirstCheckPoint = GameObject.Find("deadFirstCheckPoint").GetComponent<DeadFirstCheckPoint>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "player")
        {
            deadFirstCheckPoint.respawnPosition = gameObject.transform.position;
        }
    }
}
