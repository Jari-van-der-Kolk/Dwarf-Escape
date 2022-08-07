using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JBehaviourTree;

public class BTTesting : Actor
{
    private RootNode root;
    private FallbackNode fallbackNode;
    private DebugLogNode debugLogNode1;
    private DebugLogNode debugLogNode2;
    private DebugLogNode debugLogNode3;
    private FunctionNode functionNode;

    bool foo;

    void Start()
    {
        debugLogNode1 = new DebugLogNode(" 1"); 
        debugLogNode2 = new DebugLogNode(" 2");
        debugLogNode3 = new DebugLogNode(" 3");
        functionNode = new FunctionNode(ReturnFailure);

        fallbackNode = new FallbackNode(new List<Node>
        {
             debugLogNode2, functionNode, debugLogNode3
        });

        root = new RootNode(fallbackNode);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            foo = !foo;
            functionNode = new FunctionNode(ReturnFailure);
        }

        root.Update();
    }

    private Node.State ReturnFailure()
    {
        if(foo)
        {
            return Node.State.Success;
        }
        return Node.State.Failure;
    }
}
