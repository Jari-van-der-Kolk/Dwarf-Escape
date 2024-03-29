using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JBehaviourTree
{

    public class RandomWaitNode : LeafNode
    {
        private float min;
        private float max;
        private float startTime;
        private float duraction;

        public RandomWaitNode(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        protected override void OnStart()
        {
            duraction = Random.Range(min, max);
            startTime = Time.time;
        }

        internal override void OnStop() { }

        protected override State OnUpdate()
        {
            if (Time.time - startTime > duraction)
            {
                return State.Success;
            }

            return State.Running;
        }
    }

}