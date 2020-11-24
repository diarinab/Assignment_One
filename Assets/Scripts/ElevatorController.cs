using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float elevationSpeed = 1f;
    private int waypointIndex = 0;
    private float waypointRadius = 1;

    private void Update()
    {
        if (Vector3.Distance(waypoints[waypointIndex].transform.position, transform.position) < waypointRadius)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position,
            Time.deltaTime * elevationSpeed);
    }
}