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
    private SequenceNode wander;
    private SequenceNode followPlayer;
    private FunctionNode searchForLocation;
    private FunctionNode goToLocation;
    private FunctionNode reachedLocation;
    private WaitNode wait;

    BlackBoard blackboard;

    bool beer = false;

    private void Start()
    {
        blackboard = new BlackBoard();
        

        CreateBT();

        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }
    private void CreateBT()
    {
        searchForLocation = new FunctionNode(SearchForRandomLocation);
        goToLocation = new FunctionNode(GoToLocation);
        reachedLocation = new FunctionNode(HasReachedLocation);
        wait = new WaitNode(UnityEngine.Random.Range(.5f, 3f));

        WaitNode delay = new WaitNode(10000f);

        wander = new SequenceNode(new List<Node>
        {
            searchForLocation, goToLocation, reachedLocation, wait
        });


        CheckNode panda = new CheckNode(wander, ref beer);
        DebugLogNode foo = new DebugLogNode(beer.ToString());
        
        root = new FallbackNode(new List<Node>
        {
            panda, delay       
        });

        RepeatNode repeat = new RepeatNode(root);


        tree = new RootNode(repeat);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            beer = !beer;
        }
        tree.Update();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(target, .75f);
    }

    private bool ChangeTest()
    {
        beer = !beer;
        Debug.Log(beer);
        return beer;
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