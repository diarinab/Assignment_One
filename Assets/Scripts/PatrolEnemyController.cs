using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyController : EnemyController
{
    [SerializeField] private Transform[] wayPoints = null;
    private int wayPointIndex = 0;

    protected override Vector3 GetNextDestiation()
    {
        Vector3 destination = wayPoints[wayPointIndex].position;

        wayPointIndex = (wayPointIndex + 1) % wayPoints.Length;

        return destination;
    }
}

