using System.Collections.Generic;
using UnityEngine;

namespace JBehaviourTree
{
    public class SequenceNode : CompositeNode
    {

        public SequenceNode(List<Node> children)
        {
            this.children = children;
        }
        
        protected override void OnStart()
        {
            index = 0;
        }

        protected override void OnStop()
        {
            index = 0;
        }

        protected override State OnUpdate()
        {

            while (index < children.Count)
            {
                var child = children[index];

                if (child.Update() == State.Success)
                {
                    index++;
                }
                else if (child.Update() == State.Failure || child.Update() == State.Running)
                {
                    return child.Update();
                }
            }

            index = 0;
            return State.Success;

            /*var child = children[index];

            switch (child.Update())
            {
                case State.Running:
                    return State.Running;
                case State.Failure:
                    return State.Failure;
                case State.Success:
                    index++;
                    break;
            }
            return index >= children.Count ? State.Success : State.Running;*/
        }
    }
}