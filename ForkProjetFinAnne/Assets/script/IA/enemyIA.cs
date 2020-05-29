using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyIA : MonoBehaviour
{

    public Transform target;
    public Transform enemy;

    public float speed = 400f;
    public float nextWaitpointDistance = 3f;

    Path path;
    int currentWaitPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    //Rigidbody2D rb;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
       // rb = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody>();

        InvokeRepeating("UpdatePath",0f, .5f);

    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }

    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaitPoint = 0;   
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
        }

        if(currentWaitPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        ///Vector2 direction = ((Vector2)path.vectorPath[currentWaitPoint] - rb.position).normalized;
        Vector2 direction = (path.vectorPath[currentWaitPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaitPoint]);

        if(distance < nextWaitpointDistance)
        {
            currentWaitPoint++;
        }

        if (force.x >= 0.01f)
        {
            enemy.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            enemy.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
