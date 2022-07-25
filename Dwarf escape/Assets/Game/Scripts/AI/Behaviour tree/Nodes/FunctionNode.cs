using UnityEngine;

namespace JBehaviourTree
{
    public class FunctionNode : LeafNode
    {
        public delegate Nodes.State ActionNodeDelegate();
        private ActionNodeDelegate m_action;

        public FunctionNode(ActionNodeDelegate action) {
            m_action = action;
        }

        protected override void OnStart()
        {
        }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            switch (m_action()) {
                case Nodes.State.Success:
                    state = Nodes.State.Success;
                    return state;
                case Nodes.State.Failure:
                    state = Nodes.State.Failure;
                    return state;
                case Nodes.State.Running:
                    state = State.Running;
                    return state;
                default:
                    state = Nodes.State.Failure;
                    return state;
            }
        } 
    }
}
