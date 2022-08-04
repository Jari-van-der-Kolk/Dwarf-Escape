using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JBehaviourTree
{

    public class CheckNode : DecoratorNode
    {
        bool check;
        
        public CheckNode(Node child, bool check)
        {
            this.child = child;
            this.check = check;
        }

        protected override void OnStart() 
        {
            
        }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            child.Update();


            if (check == true) 
                return State.Success;
            else
                return State.Failure;
        }
    }

}