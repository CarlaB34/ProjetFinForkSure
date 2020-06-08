using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPcollectible : MonoBehaviour
{
    public GameObject PostProcessing1;
    public GameObject PostProcessing2;

    public GameObject collectible;
    public GameObject collectible2;

    public void Start()
    {
        //anable first process and disable another one
        PostProcessing1.gameObject.SetActive(false);
        PostProcessing2.gameObject.SetActive(false);
    }

    //la clé se detruit quand on passe dessus 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (collectible)
            {
                Debug.Log("je suis le collectible 1 et je suis détruit");
                Destroy(gameObject);

                Debug.Log("je suis bleu");
                //quand player entre en collision avec collectible alors postProcess2 s'active
                PostProcessing1.gameObject.SetActive(true);
                PostProcessing2.gameObject.SetActive(false);

            }

            else if (collectible2)
            {
                Debug.Log("je suis le collectible 2 et je suis détruit");
                Destroy(gameObject);

                Debug.Log("je suis rose");
                PostProcessing1.gameObject.SetActive(false);
                PostProcessing2.gameObject.SetActive(true);

            }

        }
    }
}
//marche quand collectible 2 est en premier puis collectible 1, enversement sans le else