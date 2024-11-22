
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditorInternal.VersionControl.ListControl;

namespace Enemy
{
    public class EnemIdle : EnemyState
    {


        public EnemIdle(EnemScript enemy, EnemyStateMachine sm1) : base(enemy, sm1)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("IDLING");

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


            sm1.ChangeState(enemy.enempathfinding);
            



        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

    }
}