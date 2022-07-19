using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour {

    public Transform goal;
    private NavMeshAgent agent;

    private void Start() {

        goal = GameObject.FindGameObjectWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update () {
        
        agent.SetDestination(goal.position);
    }
}