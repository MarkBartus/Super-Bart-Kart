using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

namespace Player
{

    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class PlayerScript : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] public FixedJoystick _joystick;
        [SerializeField] public Animator _animator;

        [SerializeField] public float moveSpeed;

        public Sprite[] animationforcar;
        public SpriteRenderer sr;


        // variables holding the different player states


        public IdleState idleState;


        public StateMachine sm;

        // Start is called before the first frame update
        void Start()
        {

            sr = GetComponent<SpriteRenderer>();
            sm = gameObject.AddComponent<StateMachine>();
            _animator = GetComponent<Animator>();

            

            //anim = GetComponent<Animator>();

            // add new states here

            idleState = new IdleState(this, sm);

            // initialise the statemachine with the default state
            sm.Init(idleState);
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();

            //output debug info to the canvas
            string s;
            s = string.Format("last state={0}\ncurrent state={1}", sm.LastState, sm.CurrentState);

            Vector2 targetDir = new Vector2(_joystick.Direction.x, _joystick.Direction.y);
            float angle = Vector2.Angle(targetDir, transform.up);

            if (_joystick.Direction.x < 0)
            {
                angle = 360 - angle;
            }

            //print(angle);

            float spriteAngle = (angle/360)*22;
            int frame = (int)spriteAngle;

            //print("angle= " + angle + " sprite frame = " + spriteAngle);

            sr.sprite = (animationforcar[frame%22]);


        }



        void FixedUpdate()
        {
            _rigidbody.linearVelocity = new Vector3(_joystick.Horizontal * moveSpeed, _rigidbody.linearVelocity.y, _joystick.Vertical * moveSpeed);
            sm.CurrentState.PhysicsUpdate();
     
        }

    }
}