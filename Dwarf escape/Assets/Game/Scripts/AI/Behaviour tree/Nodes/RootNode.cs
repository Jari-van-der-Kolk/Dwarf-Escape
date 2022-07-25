using System.Net.Mail;
using JBehaviourTree;

    public class RootNode
    {
        public Nodes rootNode;
        public Nodes.State treeState = Nodes.State.Running;

        public RootNode(Nodes rootNode)
        {
            this.rootNode = rootNode;
        }
        
        public void Update()
        {
            if(rootNode.state == Nodes.State.Running)
                treeState = rootNode.Update();
        }
    }
