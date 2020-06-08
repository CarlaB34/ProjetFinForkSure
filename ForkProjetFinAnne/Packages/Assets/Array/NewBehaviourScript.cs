using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    void Start()
    {
        // voici comment créer un tableau tous con
        int[] arrayToInvert = new int[5];
        arrayToInvert[0] = 4;
        arrayToInvert[1] = 1;
        arrayToInvert[2] = 5;
        arrayToInvert[3] = 8;
        arrayToInvert[4] = 2;
    }
    private void Invert (int[] arrayToInvert)

    {
        int[] arrayInverted = new int[arrayToInvert.Length];

        for (int i = 0; i < arrayToInvert.Length; i++)
        {
            int indexIntToInvert = (arrayToInvert.Length - 1) - i;
            arrayInverted[i] = arrayToInvert[(arrayToInvert.Length - 1) - i];
        }
        for (int i = 0;i < arrayToInvert.Length; i++)
            Debug.Log(arrayInverted[i]);
    }

}