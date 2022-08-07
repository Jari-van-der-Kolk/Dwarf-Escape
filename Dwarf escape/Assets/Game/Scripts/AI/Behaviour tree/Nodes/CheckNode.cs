using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JBehaviourTree
{

    public class CheckNode : DecoratorNode
    {
        public bool check;
        
        public CheckNode(Node child, bool check)
        {
            this.child = child;
            this.check = check;
        }

        protected override void OnStart() { }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {

            if (child.Update() == State.Failure)
                return State.Failure;

            if (check == true)
            {
                child.Update();
                return State.Running;
            } 
            else
                return State.Failure;
            
            
        }
    }

}