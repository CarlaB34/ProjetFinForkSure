using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
//using Pathfinding;
using System;

public class EnemiController : MonoBehaviour
{


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

    #region tentative 5//enemy sol
    /*
        //facing
        // public GameObject enemyGraphic;

        bool facingRight = true;

        //attacking
        Rigidbody enemyRB;
        public GameObject bullet;
        public Transform bulletSpawn;
        public bool shoot = true;
        bool check = true;
        GameObject player;
        GameObject enemy;
        bool canShoot;
        float fireRate = 3f;
        float nextFire;
        float range = 10f;
        string playerDistance;

        // Use this for initialization
        void Start()
        {
            enemyRB = GetComponent<Rigidbody>();
            player = GameObject.FindGameObjectWithTag("player");
            enemy = GameObject.FindGameObjectWithTag("pike");
            Vector3.Distance(transform.position, player.transform.position);
        }

        // Update is called once per frame
        void Update()
        {

            //    if (Time.time > nextFlipChance) {

            //        if (Random.Range (0, 10) >= 5)
            //            nextFlipChance = Time.time + flipTime;
            //}


            //if (Time.time >= nextFire) {

            //    nextFire = Time.time + fireRate;
            //    fireGun();





        }
        void fireGun()
        {

            GameObject tempBullet;

            tempBullet = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;

            Rigidbody tempRB;
            tempRB = tempBullet.GetComponent<Rigidbody>();


            if (!facingRight)
            {
                tempRB.AddForce(player.transform.position - enemy.transform.position * 12f * Time.deltaTime, ForceMode.Impulse);

                Destroy(tempBullet, 12f);
            }

        }

        void OnTriggerEnter(Collider other)
        {

            if (Vector3.Distance(transform.position, player.transform.position) <= range)
            {


                if (Time.time >= nextFire)
                {

                    nextFire = Time.time + fireRate;
                    //return fireGun();
                    fireGun();

                }
            }
                /*GameObject tempBullet;



            }
            /*
            */


    //}
    //}



    //}


    //}

    #endregion

    #region tentative 6// enemy sol.2
    /*
        public float lookRadius = 10f;
        GameObject target;
        NavMeshAgent agent;


        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("player");

            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);

            if(distance <= lookRadius)
            {
                agent.SetDestination(target.transform.position);

                if(distance <= agent.stoppingDistance)
                {
                    //attack the target
                    FaceTarget();
                }
            }
        }

        void FaceTarget()
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookRadius);
        }
        */
    #endregion

    #region tentative 7//enemy sol.3
    /*public Transform target;
    public float speed= 2f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //make the enemy move towards the player
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(pos);
        transform.LookAt(target);
       
    }
    */
    #endregion


    [SerializeField]
    Transform player;

    //distance de suivie du player
    [SerializeField]
    float agroRange;

    /// <summary>The objects initial position.</summary>
    private Vector3 startPosition;
    /// <summary>The objects updated position for the next frame.</summary>
    private Vector3 newPosition;
    //distance ou l'enemi detect la pressence du player
    [SerializeField] private int maxDistance = 1;

    //jump
    public float jumpHeight;
    float jumpSpeed;
    Vector3 velocity;
    private float canJump = 0f;


    [SerializeField]
    float moveSpeed;

    Rigidbody rb;


    private void Start()
    {
        //comportement quand chase pas
        startPosition = transform.position;
        newPosition = transform.position;

        rb = GetComponent<Rigidbody>();

        jumpSpeed = Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight) + 0.1f;

    }

    private void Update()
    {

        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);



        if (distToPlayer < agroRange)
        {
            //code to chase player
            ChasePlayer();
        }
        else
        {
            //stop chasing player and move
            StopChasingPlayer();
        }
    }

    private void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            //enemy is to the left side of the player, so move right
            //avance seulement vers le player
            //rb.velocity = new Vector2(moveSpeed, 0);
            //saute quand le palyer est dans l'agro
            if (Time.time > canJump)
            {
                Debug.Log("le temps s'ecoule");
                //saute vers le player mais pas dessu, a la saute moutton
                rb.velocity = new Vector2(moveSpeed, 0);
                velocity = rb.velocity;
                velocity.y = jumpSpeed;
                rb.velocity = velocity;
                canJump = Time.time + 1.5f;    // whatever time a jump takes //la durée d'un saut
            }

        }
        else
        {

            //enemy is to the right side of the player, so move left
            //avance seulement vers le player
            //rb.velocity = new Vector2(-moveSpeed, 0);

            //saute quand le palyer est dans l'agro
            if (Time.time > canJump)
            {
                Debug.Log("le temps s'ecoule");
                rb.velocity = new Vector2(-moveSpeed, 0);
                velocity = rb.velocity;
                velocity.y = jumpSpeed;
                rb.velocity = velocity;
                canJump = Time.time + 1.5f;    // whatever time a jump takes
            }
        }
    }

    private void StopChasingPlayer()
    {
        //rb.velocity = new Vector2(0, 0);
        newPosition.x = startPosition.x + (maxDistance * Mathf.Sin(Time.time * moveSpeed));
        transform.position = newPosition;
    }

    //quand player plus dans la range, tp a la start postion et pas la nouvelle de la ou il est

    #region collision obstacle
    //l'enemi saute par dessus l'obstacle, applique une force en hauter pour eviter un petit obstable
    void OnCollisionEnter(Collision col)
    {

        Debug.Log("l'IA saute");
        switch (col.gameObject.tag)
        {
            case "wall":
                //rb.AddForce(Vector3.up * 700f);
                rb.AddForce(Vector3.up * 7f);
                //moveSpeed = 0;


                break;
        }


    }

    //l'enemi ne saute plus apres avoir franchi l'obstable, applique la meme force vers le bas
    private void OnCollisionExit(Collision col)
    {
        Debug.Log("l'IA Saute plus");
        switch (col.gameObject.tag)
        {
            case "ground":
                rb.AddForce(Vector3.down * 7f);
                // moveSpeed = 2;
                break;
        }
    }

    #endregion

}

