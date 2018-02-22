﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    public GameObject target;
    public bool heroTag;
    
	// Use this for initialization
	void Start ()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, maxMovementSpeed);
	}

    float maxMovementSpeed = 100;
    float fleeDistance = 15.0f;
    float seekDistance = 15.0f;

    float catchUpDistance = 17;

    int fleeWeighing = 11;
    int seekWeighing = 10;

    Vector3 currentVelocity;

    void Update ()
    {
        currentVelocity = transform.GetComponent<Rigidbody>().velocity;

        var totalForce = (
                            ((FleeForce()*fleeWeighing) +(SeekForce()*seekWeighing)).normalized) 
                            + HeuristicForce()
                            + JiggleForce();


        totalForce = AdjustForceForDesiredVelocity(totalForce);
        transform.GetComponent<Rigidbody>().AddForce(totalForce);
    }

    Vector3 AdjustForceForDesiredVelocity(Vector3 forcePreAdjusting)
    {
        Vector3 desired = forcePreAdjusting * maxMovementSpeed;
        var adjustedForce = desired - currentVelocity;

        return adjustedForce;
    }

    Vector3 HeuristicForce()
    {
        if (!heroTag && transform.position.z + catchUpDistance < target.transform.position.z)
        {
            return new Vector3(0, 0, 1);
        }
        else if (!heroTag && transform.position.z > target.transform.position.z)
        {
            return new Vector3(0, 0, -0.5f);
        }

        return Vector3.zero;
    }

    Vector3 JiggleForce()
    {
        return new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
    }

    Vector3 SeekForce()
    {
        Vector3 toTarget = target.transform.position - transform.position;

        if(toTarget.magnitude > seekDistance)
        {
            toTarget.Normalize();
            Vector3 desired = toTarget * maxMovementSpeed;
            return desired - currentVelocity;
        }

        return Vector3.zero;
    }

    Vector3 FleeForce()
    {
        Vector3 totalFleeForce = new Vector3();

        if(!heroTag)
        {
            foreach (var go in GameObject.FindGameObjectsWithTag("XWing"))
            {
                var theTarget = go;

                Vector3 toTarget = theTarget.transform.position - transform.position;
                if (toTarget.magnitude < fleeDistance)
                {
                    toTarget.Normalize();
                    Vector3 desired = toTarget * maxMovementSpeed;
                    totalFleeForce += (currentVelocity - desired);
                }
            }
        }

        return totalFleeForce;
    }
}