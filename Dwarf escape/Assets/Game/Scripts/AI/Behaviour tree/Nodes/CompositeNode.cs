using System.Collections.Generic;

namespace JBehaviourTree
{
    public abstract class CompositeNode : Nodes
    {
        protected List<Nodes> children = new List<Nodes>();
    }
}