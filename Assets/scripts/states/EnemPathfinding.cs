
using System.IO;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UIElements.UxmlAttributeDescription;


namespace Enemy

{
    public class EnemPathfinding : EnemyState
    {

        Vector3 oldPosition;
        Vector3 direction;
        public Transform target;

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
           // Debug.Log("checking for finish line");


            direction = enemy.navi.destination - oldPosition;

           // Debug.Log("xz=" + direction.x + "  " + direction.z);

            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float angle = (360 + Mathf.Atan2(direction.x, direction.z) * (180 / Mathf.PI)) % 360;
            
           // Debug.Log("enemgy angle1: " +angle);

            
            if (direction.x < 0)
            {
                angle = 360 - angle;
            }
            
            float spriteAngle = (angle / 360) * 22;
            int frame = (int)spriteAngle;

           // Debug.Log("angle= " + angle + " sprite frame = " + spriteAngle);

            enemy.sr.sprite = (enemy.animationforcar[frame % 22]);
            
           // Debug.Log("act frame" + frame);
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

                oldPosition = enemy.navi.destination;
                enemy.navi.destination = enemy.points[enemy.destPoint].position;
                enemy.destPoint = (enemy.destPoint + 1) % enemy.points.Length;

                
                
            }



        }
    }
}