using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JBehaviourTree;


public class Worm : Actor
{
    [SerializeField] LayerMask mask;
    [SerializeField] private float radius;
    Vector2 targetPosition;

    private RootNode tree;
    private FallbackNode root;
    private SequenceNode wander;
    private SequenceNode followPlayer;
    private FunctionNode searchForLoction;
    private FunctionNode goToLocation;
    private FunctionNode reachedLocation;
    private RepeatNode foo;



    private void Start()
    {
        CreateBT();

        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

    private void CreateBT()
    {

        searchForLoction = new FunctionNode(SearchForRandomLocation(radius, ref targetPosition));
        goToLocation = new FunctionNode(MoveToPosition(targetPosition));
        reachedLocation = new FunctionNode(HasReachedLocation(targetPosition, .5f));

        Debug.Log(goToLocation);

        followPlayer = new SequenceNode(new List<Node>
        {
            
        });

        wander = new SequenceNode(new List<Node>
        {
           goToLocation 
        });

        root = new FallbackNode(new List<Node>
        {
            goToLocation
        });

        

        tree = new RootNode(wander);
    }

    void Update()
    {
        tree.Update();
       /* if (Input.GetKeyUp(KeyCode.T))
        {
            SearchForRandomLocation(radius, ref targetPosition);
            GoToLocation(targetPosition);
        }

        if (!HasObjectInSight(playerLocation))
            return;
            
        GoToLocation(playerLocation.position);*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(targetPosition, .75f);
    }

    public Node.State MoveToPosition(Vector2 position)
    {
        GoToLocation(position);
        return Node.State.Success;
    }

}
