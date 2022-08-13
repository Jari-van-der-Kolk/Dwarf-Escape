using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JBehaviourTree;
using Blackboard;

public class Worm : Actor
{
    [SerializeField] LayerMask mask;
    [SerializeField] private float radius;

    private RootNode tree;
    private SequenceNode lostPlayer;
    private FallbackStarNode root;
    private ReactiveSequenceNode followPlayer;
    private SequenceNode wander;
    private ReactiveSequenceNode trackPlayer;
    private ReactiveSequenceNode roam;
    private FunctionNode goToPlayer;
    private FunctionNode targetPlayer;
    private FunctionNode searchForLocation;
    private FunctionNode goToLocation;
    private FunctionNode inSight;
    private RandomWaitNode waitOnPosition;
    private InverterNode invertInSight;
    private InverterNode invertFollowPlayerTime;

    private RepeatOverTimeNode followPlayerTime;

    private InverterNode reachedLocation;

    DebugLogNode panda;

    bool foo = false;

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
        waitOnPosition = new RandomWaitNode(.5f, 4f);
        goToPlayer = new FunctionNode(GoToPlayer);
        targetPlayer = new FunctionNode(TargetPlayer);
        inSight = new FunctionNode(HasPlayerInSight);
        invertInSight = new InverterNode(inSight);


        wander = new SequenceNode(new List<Node>
        {
            searchForLocation, goToLocation, waitOnPosition
        });

        roam = new ReactiveSequenceNode(new List<Node>
        {
            inSight, wander
        });

        followPlayer = new ReactiveSequenceNode(new List<Node>
        {
            invertInSight, goToPlayer  
        });

        reachedLocation = new InverterNode(goToLocation);
        followPlayerTime = new RepeatOverTimeNode(targetPlayer, 4f);
        invertFollowPlayerTime = new InverterNode(followPlayerTime);

        lostPlayer = new SequenceNode(new List<Node>
        {
            followPlayerTime, goToLocation   
        }, true);

        trackPlayer = new ReactiveSequenceNode(new List<Node>
        {
            inSight, reachedLocation, lostPlayer 
        });

        root = new FallbackStarNode(new List<Node>   
        {
            roam, followPlayer, trackPlayer 
        });

        tree = new RootNode(root);
    }

    void Update()
    {
        tree.Update();
        //Debug.Log(inSight.state);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(target, .75f);
    }

    private Node.State ReturnFailure()
    {
        Debug.Log("failure node running" + " " + foo);
        if (foo)
        {
            return Node.State.Success;
        }
        return Node.State.Failure;
    }
}


