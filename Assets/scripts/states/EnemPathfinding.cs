
using System.IO;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


namespace Enemy

{
    public class EnemPathfinding : EnemyState
    {



        // constructor
        public EnemPathfinding(EnemScript enemy, EnemyStateMachine sm1) : base(enemy, sm1)
        {

        }

        public override void Enter()
        {

            base.Enter();
            Debug.Log("Pathfinding");

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


            enemy.CheckForWin();




            Debug.Log("checking for finish line");


        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();


            if (!enemy.navi.pathPending && enemy.navi.remainingDistance < 0.8f)
            {
                if (enemy.points.Length == 0)
                {
                    return;
                }
                enemy.navi.destination = enemy.points[enemy.destPoint].position;
                enemy.destPoint = (enemy.destPoint + 1) % enemy.points.Length;
            }



        }
    }
}