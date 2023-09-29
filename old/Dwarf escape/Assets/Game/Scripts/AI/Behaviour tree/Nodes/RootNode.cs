using System.Net.Mail;
using System.Collections;
using UnityEngine;


namespace JBehaviourTree
{

    public class RootNode
    {
        public Node rootNode;
        public Node.State treeState = Node.State.Running;

        public RootNode(Node rootNode)
        {
            this.rootNode = rootNode;
        }
        
        public void Update()
        {
            //if(treeState == Node.State.Running)
                treeState = rootNode.Update();
        }
    }

}