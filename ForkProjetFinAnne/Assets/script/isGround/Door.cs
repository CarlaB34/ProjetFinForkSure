using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private static int keyScore;
    private static int keyScore2;

    private void Update()
    {
        // recuperation de la variable Key dans PlayerController pour l'utiliser dans ce script
        keyScore = PlayerController.Key;
        keyScore2 = MovePlayer.Key;

    }

   //si porte entre en collision avec le player qui a ramassé une clé , elle se détruit
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && keyScore >0)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && keyScore2 > 0)
        {
            Destroy(gameObject);
        }
    }
}