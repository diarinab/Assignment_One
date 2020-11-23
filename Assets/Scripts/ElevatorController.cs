using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private float elevationSpeed = 10f;
    [SerializeField] private Transform[] wayPoints = null;
    
    private NavMeshAgent agent;
    private Vector3 startingPosition;
    
    private int wayPointIndex = 0;

    protected virtual Vector3 GetNextDestination()
    {
        Vector3 destination = wayPoints[wayPointIndex].position;

        wayPointIndex = (wayPointIndex + 1) % wayPoints.Length;

        return destination;
    }
    private void Start()
    {
        startingPosition = gameObject.transform.position;
    }
    
   
}
