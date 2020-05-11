using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Pathfinding;


public class Enemi : MonoBehaviour
{
    #region tentative1
    /*private Transform Player;
    private float dist;

    public float moveSpeed;
    public float howclose; //distance

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player").transform;
    }

    private void Update()
    {
        dist = Vector3.Distance(Player.position, transform.position);

        if(dist <= howclose)
        {
            transform.LookAt(Player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }

        //for melee attack or explosive
        if(dist <= 1.5f)
        {
            //do damage or explode
        }
    }*/
    #endregion

    #region tentative2
    /* [SerializeField]
     Transform _destination;

     NavMeshAgent _navMeshAgent;

     private void Start()
     {
         _navMeshAgent = this.GetComponent<NavMeshAgent>();

         if(_navMeshAgent == null)
         {
             Debug.LogError("the nav mesh agent component is not attached to" + gameObject.name);
         }
         else
         {
             setDestination();
         }
     }

     private void setDestination()
     {
         if(_destination != null)
         {
             Vector3 targetVector = _destination.transform.position;
             _navMeshAgent.SetDestination(targetVector);
         }
     }*/
    #endregion

    public AIPath aIPath;

    void Update()
    {
        if(aIPath.desiredVelocity.y >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(aIPath.desiredVelocity.y <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
