using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Health health;

    private void Start()
    {
        health = GameObject.Find("Respawn1").GetComponent<Health>();
    }

    
}
