using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class boss : MonoBehaviour
{
    #region move
    /// <summary>The objects initial position.</summary>
    private Vector3 startPosition;
    /// <summary>The objects updated position for the next frame.</summary>
    private Vector3 newPosition;

    /// <summary>The speed at which the object moves.</summary>
    [SerializeField] private float speed = 3;
    /// <summary>The maximum distance the object may move in either y direction.</summary>
    [SerializeField] private int maxDistance = 1;
    #endregion


    //[SerializeField]
    //Transform _destination;

    //NavMeshAgent _navMeshAgent;
    void Start()
    {
        startPosition = transform.position;
        newPosition = transform.position;

        //_navMeshAgent = this.GetComponent<NavMeshAgent>();

        //if (_navMeshAgent == null)
        //{
        //    Debug.LogError("the nav mesh agent component is not attached to" + gameObject.name);
        //}
       

    }

    void Update()
    {
        newPosition.x = startPosition.x + (maxDistance * Mathf.Sin(Time.time * speed));
        transform.position = newPosition;


    }

    //player entre dasn la sphere trigger
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("player"))
        {
            Debug.Log("détecter");
            Debug.Log("je m'arrete");
            //speed = 0;
            

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        
        Debug.Log("je marche");
        if (other.CompareTag("player"))
        {
            // speed = 0;  
            //setDestination();
        }     
    }

    //private void setDestination()
    //{
    //    if (_destination != null)
    //    {
    //        Vector3 targetVector = _destination.transform.position;
    //        _navMeshAgent.SetDestination(targetVector);
    //    }
    //}
}
