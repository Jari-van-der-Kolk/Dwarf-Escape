using System.Collections.Generic;
using UnityEngine;

namespace JBehaviourTree
{
    public class ReactiveSequenceNode : CompositeNode
    {
        private int index;

        public ReactiveSequenceNode(List<Node> children)
        {
            this.children = children;
        }
        
        protected override void OnStart()
        {

        }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            bool anyChildRunning = false;
            
            foreach (Node node in children)
            {
                switch (node.Update())
                {
                    case State.Running:
                        anyChildRunning = true;
                        continue;
                    case State.Failure:
                        return State.Failure;
                    case State.Success:
                        continue;
                    default:
                        return State.Success;
                }
            }
            return anyChildRunning ? State.Running : State.Success; 
        }
    }
}