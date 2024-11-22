using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof ( BoxCollider))]  
public class player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;

    [SerializeField] private float moveSpeed;

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = new Vector3(_joystick.Horizontal * moveSpeed, _rigidbody.linearVelocity.y, _joystick.Vertical * moveSpeed);

        if (_joystick.Horizontal <=0.2 ) 
        {
            _animator.Play("mario right", 0, 0);
            Debug.Log("right");
        }
        else
        {
            _animator.Play("idle mario");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_joystick.Horizontal);
    }
}
