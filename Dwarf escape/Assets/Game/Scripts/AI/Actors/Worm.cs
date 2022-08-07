using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JBehaviourTree;
using UnityEngine.AI;
using Blackboard;


public class Worm : Actor
{
    [SerializeField] LayerMask mask;
    [SerializeField] private float radius;

    private RootNode tree;
    private FallbackNode root;
    private ReactiveSequenceNode followPlayer;
    private SequenceNode wander;
    private ReactiveSequenceNode roam;
    private FunctionNode goToPlayer;
    private FunctionNode searchForLocation;
    private FunctionNode goToLocation;
    private FunctionNode inSight;
    private RandomWaitNode wait;
    private InverterNode inverter;

    private void Start()
    {
        CreateBT();

        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }
    private void CreateBT()
    {
        searchForLocation = new FunctionNode(SearchForRandomLocation);
        goToLocation = new FunctionNode(GoToLocation);
        wait = new RandomWaitNode(.5f, 4f);
        goToPlayer = new FunctionNode(GoToPlayer);
        inSight = new FunctionNode(HasPlayerInSight);
        inverter = new InverterNode(inSight);

        DebugLogNode foo = new DebugLogNode("1");
        DebugLogNode panda = new DebugLogNode("2");
        DebugLogNode poo = new DebugLogNode("3");

        wander = new SequenceNode(new List<Node>
        {
            searchForLocation, goToLocation, wait
        });

        roam = new ReactiveSequenceNode(new List<Node>
        {
            foo, inSight, wander
        });

        followPlayer = new ReactiveSequenceNode(new List<Node>
        {
            panda, inverter, goToPlayer  
        });

        root = new FallbackNode(new List<Node>
        {
           roam, followPlayer
        });

        tree = new RootNode(root);
    }

    void Update()
    {
        //Debug.Log(HasPlayerInSight() + " " + inverter.Update());
        tree.Update();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(target, .75f);
    }

}



/* if (Input.GetKeyUp(KeyCode.T))
{
SearchForRandomLocation(radius, ref targetPosition);
GoToLocation(targetPosition);
}

if (!HasObjectInSight(playerLocation))
return;

GoToLocation(playerLocation.position);*/