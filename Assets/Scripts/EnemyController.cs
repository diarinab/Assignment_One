using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject playerObject = null;
    [SerializeField] private float detectionRadius = 4f;

    [SerializeField] private Material aggressiveMat = null;
    [SerializeField] private Material calmMat = null;

    private NavMeshAgent agent;
    private Vector3 startingPosition;

    protected virtual Vector3 GetNextDestiation()
    {
        return startingPosition;
    }

    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        startingPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(playerObject.transform.position, gameObject.transform.position) < detectionRadius)
        {
            agent.GetComponent<Renderer>().material = aggressiveMat;
            agent.SetDestination(playerObject.transform.position);
            return;
        }

        //enemy is in idle state
        agent.GetComponent<Renderer>().material = calmMat;
        if(agent.remainingDistance < 0.5f)
            agent.SetDestination(GetNextDestiation());
    }
}
