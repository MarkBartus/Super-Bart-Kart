
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Enemy
{
    public abstract class EnemyState
    {       
        protected EnemyStateMachine sm1;
        protected EnemScript enemy;

        // base constructor

        protected EnemyState(EnemScript enemy, EnemyStateMachine sm1)
        {
            this.enemy = enemy;
            this.sm1 = sm1;
        }

        // These methods are common to all states
        public virtual void Enter()
        {
            //Debug.Log("This is base.enter");
        }

        public virtual void HandleInput()
        {
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void PhysicsUpdate()
        {
        }

        public virtual void Exit()
        {
        }

    }

}