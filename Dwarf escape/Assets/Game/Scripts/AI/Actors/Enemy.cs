using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Transform playerLocation;
    public float detectionDistance;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();      
        agent = GetComponent<NavMeshAgent>();
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void GoToObject(Transform location) => agent.SetDestination(location.position);

    public bool HasObjectInSight(Transform location, LayerMask objectMask)
    {
        var raycast = Physics2D.Raycast(transform.position, (location.position - transform.position).normalized, detectionDistance, objectMask);
        var color = Color.blue;
        if (raycast)
        {
            color = Color.green;
        }        
        Debug.DrawRay(transform.position, (location.position - transform.position).normalized * detectionDistance, color);

        return raycast;
    }
    public bool HasObjectInSight(Transform location, LayerMask objectMask, Action LostSigth)
    {
        bool ended = false;
        var raycast = Physics2D.Raycast(transform.position, (location.position - transform.position).normalized, detectionDistance, objectMask);
        var color = Color.blue;
        if (raycast)
        {
            color = Color.green;
        }
        Debug.DrawRay(transform.position, (location.position - transform.position).normalized * detectionDistance, color);



        return raycast;
    }


}
