using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosstheme : MonoBehaviour
{
    public AudioClip bossmusic;
    public AudioSource source;
    
    
    
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            source.PlayOneShot(bossmusic);
        }
        else
        {
            source.Stop();
        }
    }
}
