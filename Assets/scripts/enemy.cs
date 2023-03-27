using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent navAgent;
    public Transform[] points;
    public int pointCount;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, points.Length);
        navAgent.SetDestination(points[rand].position);
        anim.SetTrigger("Walk");
    }

    // Update is called once per frame
    void Update()
    {
        int rand = 160;
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            int newrand = Random.Range(0, points.Length);
            while (newrand == rand) { newrand = Random.Range(0, points.Length); }
            navAgent.SetDestination(points[newrand].position);
            ++pointCount;
            Debug.Log("Arrived! Point Count = " + pointCount);
            rand = newrand;
        }

        if (pointCount == 5 && !navAgent.isStopped)
        {
            navAgent.isStopped = true;
            anim.SetTrigger("Idle");
        }
    }
}
