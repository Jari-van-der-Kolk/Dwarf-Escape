using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JBehaviourTree
{

    public class FallbackStarNode : CompositeNode
    {

        bool debug;
        public FallbackStarNode(List<Node> children)
        {
            this.children = children;     
        } 
        public FallbackStarNode(List<Node> children, bool debug)
        {
            this.children = children;   
            this.debug = debug;
        }

        protected override void OnStart()
        {
            index = 0;
        }

        internal override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (debug)
            {
                Debug.Log(index);
            }
            var child = children[index];
            switch (child.Update())
            {
                case State.Running:
                    return State.Running;
                case State.Failure:
                    index++;
                    break;
                case State.Success:
                    return State.Running;
                default:
                    break;
            }

          
            return index >= children.Count ? State.Success : State.Running;

            /*while (index < children.Count)
            {
                var child = children[index];

                if (child.Update() == State.Running)
                {
                    return State.Running;
                }
                else if (child.Update() == State.Failure)
                {
                    index++;
                }
                else if (child.Update() == State.Success)
                {
                    return State.Success;
                }

            }*/

        }

      
    }
}
