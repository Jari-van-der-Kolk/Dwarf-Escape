using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using JBehaviourTree;


public class Actor : MonoBehaviour
{
    internal Rigidbody2D rb;
    internal NavMeshAgent agent;
    internal Transform playerLocation;
    public float detectionDistance;

    private NavMeshPath navMeshPath;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();      
        agent = GetComponent<NavMeshAgent>();
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;

        navMeshPath = new NavMeshPath();
    }

    public void GoToLocation(Vector3 location)
    {
        agent.SetDestination(location);
    }

    
    public bool HasObjectInSight(Transform location)
    {
        var raycast = Physics2D.Raycast(transform.position, (location.position - transform.position).normalized * detectionDistance);
        var distance = Vector2.Distance(transform.position, location.position);
        Debug.DrawRay(transform.position, (location.position - transform.position).normalized * detectionDistance, Color.blue);

        if (distance < detectionDistance && raycast.collider != null && raycast.collider.CompareTag("Player"))
        {
            return true;
        }

        return false;
    }

    

    public Node.State HasReachedLocation(Vector2 target, float succesDistance)
    {
        if(Vector2.Distance(transform.position, target) < succesDistance)
        {
            return Node.State.Success;
        }

        return Node.State.Failure;
    }

    public Node.State SearchForRandomLocation(float searchRadius, ref Vector2 randomPosition)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * searchRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, searchRadius, 1))
        {
            finalPosition = hit.position;
        }

        if (!CheckPath(finalPosition))
        {
            SearchForRandomLocation(searchRadius, ref randomPosition);
            return Node.State.Running;
        }

        randomPosition = finalPosition;

        return Node.State.Success;
    }

    private bool CheckPath(Vector3 targetPosition)
    {
        agent.CalculatePath(targetPosition, navMeshPath);
        if (navMeshPath.status != NavMeshPathStatus.PathComplete)
            return false;
        else
            return true;
    }

}
