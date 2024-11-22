
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditorInternal.VersionControl.ListControl;

namespace Player
{
    public class movement : State
    {


        // constructor
        public movement(PlayerScript player, StateMachine sm) : base(player, sm)
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

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }


    }
}