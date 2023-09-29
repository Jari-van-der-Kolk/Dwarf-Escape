using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JBehaviourTree
{

    public class RepeatOverTimeNode : DecoratorNode
    {
        public float duraction = 1;
        private float startTime;

        public RepeatOverTimeNode(Node child, float duraction)
        {
            this.child = child;
            this.duraction = duraction;
        }

        protected override void OnStart()
        {
            startTime = Time.time;
        }

        internal override void OnStop() 
        {
            
        }

        protected override State OnUpdate()
        {
            if (Time.time - startTime > duraction)
            {
                return State.Success;
            }

            child.Update();
            return State.Running;
        }


    }

}