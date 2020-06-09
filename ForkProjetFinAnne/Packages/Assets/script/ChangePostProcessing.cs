using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePostProcessing : MonoBehaviour
{
    public GameObject PostProcessing1, PostProcessing2, PostProcessing3;

    //variable contains wich PostProcessing is on and active
    int WichPostProcessingIsOn = 1;

    public void Start()
    {
        //anable first process and disable another one
        PostProcessing1.gameObject.SetActive(true);
        PostProcessing2.gameObject.SetActive(false);
        PostProcessing3.gameObject.SetActive(false);

    }

    public void Update()
    {
        //stiwh with touch
        if (Input.GetKeyDown(KeyCode.H))
        {
            SwitchProcessing();
        }
    }
    //public methode to switch PostProcessing by pressing UI Button
    public void SwitchProcessing()
    {
       
        switch (WichPostProcessingIsOn)
        {
            //if the first PostProcessing is on
            case 1:
                //then the second PostProcessing is on now
                WichPostProcessingIsOn = 2;

                //disable the first one and anable the second one
                PostProcessing1.gameObject.SetActive(false);
                PostProcessing3.gameObject.SetActive(false);
                PostProcessing2.gameObject.SetActive(true);
                break;

            //if the second PostProcessing is on
           case 2:
                //then the first PostProcessing is on now
                WichPostProcessingIsOn = 3;

                //disable the first one and anable the second one
                PostProcessing1.gameObject.SetActive(false);
                PostProcessing2.gameObject.SetActive(false);
                PostProcessing3.gameObject.SetActive(true);
                break;

            //if the second PostProcessing is on
            case 3:
                //then the first PostProcessing is on now
                WichPostProcessingIsOn = 1;

                //disable the first one and anable the second one
                PostProcessing1.gameObject.SetActive(true);
                PostProcessing2.gameObject.SetActive(false);
                PostProcessing3.gameObject.SetActive(false);
                break;
               
        }
    }
}
