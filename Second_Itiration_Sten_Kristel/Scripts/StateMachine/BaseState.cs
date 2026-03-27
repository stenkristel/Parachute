using UnityEngine;
using UnityEngine.Events;

namespace StateMachine
{
    public abstract class BaseState : MonoBehaviour
    {
        protected StateBehaviour owner;
        
        [SerializeField] private UnityEvent onEnter;
        [SerializeField] private UnityEvent onExit;
        
        public void Initialize(StateBehaviour owner)
        {
            this.owner = owner;
        }

        public virtual void OnEnter()
        {
            onEnter?.Invoke();
        }
        public virtual void OnUpdate(){}
        public virtual void OnFixedUpdate(){}

        public virtual void OnExit()
        {
            onExit?.Invoke();
        }
    }
}
