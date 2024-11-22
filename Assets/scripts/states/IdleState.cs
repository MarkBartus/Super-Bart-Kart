
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditorInternal.VersionControl.ListControl;

namespace Player
{
    public class IdleState : State
    {


        // constructor
        public IdleState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();

            
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
           
           
            base.LogicUpdate();

            //if ((!enemy.path.pathPending && enemy.path.remainingDistance < 0.5f))
            //{
            //    sm.ChangeState(enemy.enempathfinding);
            //}

            //enemy.CheckForPath();

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

    }
}