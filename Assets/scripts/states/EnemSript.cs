using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;



namespace Enemy
{

    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class EnemScript : MonoBehaviour
    {

        public Transform[] points;       
        public int destPoint;
        public NavMeshAgent navi;

        [SerializeField] private Rigidbody _rigidbody;
        
        [SerializeField] public Animator _animator;

        [SerializeField] private float moveSpeed;

        public Sprite[] animationforcar;
        public SpriteRenderer sr;
        public GameObject Enemy1;


        // variables holding the different player states
        public EnemIdle enemIdle;
        public EnemPathfinding enempathfinding;




        public EnemyStateMachine sm1;
        
        private float startVelocity;
        private float degAngle;

        // Start is called before the first frame update
        void Start()
        {
            
            navi = GetComponent<NavMeshAgent>();
            sr = GetComponent<SpriteRenderer>();
            sm1 = gameObject.AddComponent<EnemyStateMachine>();
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody>();

            enemIdle = new EnemIdle(this, sm1);
            enempathfinding = new EnemPathfinding(this, sm1);
           

            // add new states here



            // initialise the statemachine with the default state
            sm1.Init(enempathfinding);
        }

        // Update is called once per frame
        public void Update()
        {
            sm1.CurrentState.LogicUpdate();

            rotation();
            
            
        }
        public void CheckForPath()
        {
            if (navi.velocity != Vector3.zero)
            {
                sm1.ChangeState(enempathfinding);
                Debug.Log("pathfinding");
                return;
            }


        }
        public void CheckForWin()
        {

        }
        public void CheckForIdle()
        {
            if ((!navi.pathPending && navi.remainingDistance < 0.5f))
            {
                sm1.ChangeState(enempathfinding);
            }
            else
            {
                Debug.Log("idleState");
                sm1.ChangeState(enemIdle);

            }

        }

        void FixedUpdate()
        {
            sm1.CurrentState.PhysicsUpdate();

        }
        private void rotation()
        {
            var radAngle = degAngle * Mathf.Deg2Rad;
            print(radAngle);
            _rigidbody.linearVelocity = new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle) * startVelocity);
        }
    }
}