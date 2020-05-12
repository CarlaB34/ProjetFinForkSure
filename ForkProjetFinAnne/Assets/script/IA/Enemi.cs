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

    #region tentative 3 Pathfinding//enemi
    /*public AIPath aIPath;

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
    }*/
    #endregion

    #region tentative 4//enemi(3)

    public int maxHealth = 40;

    public float speed;
    public float attackRange;
    public float attackDelay;
    public float chaseRange;
    public float bulletForce;
    private float lastAttackTime;
    private float distanceToTarget;

    public Transform target;
    public GameObject projectile;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (distanceToTarget < chaseRange)
        {
            Chase(target.position);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget < attackRange)
        {
            if (Time.time > lastAttackTime + attackDelay)
            {
                RaycastHit2D Hit = Physics2D.Raycast(transform.position, transform.up, attackRange, 1 << LayerMask.NameToLayer("Player"));
                if (Hit)
                {
                    Fire();
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    private void Chase(Vector3 target)
    {
        Vector3 targetDir = target - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;

        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

        rb.velocity = targetDir.normalized * speed;
    }

    private void Fire()
    {
        GameObject newBullet = Instantiate(projectile, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.up * bulletForce, ForceMode.Impulse);
    }


    #endregion
}
