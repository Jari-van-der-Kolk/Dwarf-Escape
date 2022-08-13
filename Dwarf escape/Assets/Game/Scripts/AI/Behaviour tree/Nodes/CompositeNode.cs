using System.Collections.Generic;

namespace JBehaviourTree
{
    public abstract class CompositeNode : Node
    {
        protected List<Node> children = new List<Node>();
        public int index;

        internal void HaltChildren()
        {
            for (int i = 0; i < children.Count; i++)
            {
                children[i].OnStop();
            }
        }
    }
}