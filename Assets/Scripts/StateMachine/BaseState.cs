using UnityEngine;

namespace StateMachine
{
    public abstract class BaseState : MonoBehaviour
    {
        protected StateBehaviour owner;
        
        public void Initialize(StateBehaviour owner)
        {
            this.owner = owner;
        }
        
        public virtual void OnEnter(){}
        public virtual void OnUpdate(){}
        public virtual void OnFixedUpdate(){}
        public virtual void OnExit(){}
    }
}
