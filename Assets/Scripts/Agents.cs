using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Agents : MonoBehaviour
{
    private NavMeshAgent agent;
    private Waypoints[] waypoint;

    // Generating a random waypoint range for the different agents
    private Waypoints RandomPoint => waypoint[Random.Range(0, waypoint.Length)];

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        //FindObjectsOfType gets every instance of this component in the scene
        waypoint = FindObjectsOfType<Waypoints>();

        // telling the agent to move to a random position in the waypoints in the scene
        agent.SetDestination(RandomPoint.Position);
    }

    // Update is called once per frame
    void Update()
    {
        // Locating how far the agent is from his objective
        if (!agent.pathPending && agent.remainingDistance == 0)
        {
            // Setting the next waypoint position or current position
            agent.SetDestination(RandomPoint.Position);
        }
    }
    // add a start and end for each door
}
