using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerControls : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] public GroundTrigger _groundTrigger;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _verticalSpeedLimitForJump;

    private void Awake()
    {
        if(_rigidBody == null)
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }
        if(_groundTrigger == null)
        {
            _groundTrigger = GetComponentInChildren<GroundTrigger>();
        }
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        bool jumpPressed = Input.GetButtonDown("Jump");

        _rigidBody.velocity = new Vector2 (moveHorizontal * _speed, _rigidBody.velocity.y);

        bool isYVelocitySlow = Mathf.Abs(_rigidBody.velocity.y) < _verticalSpeedLimitForJump;
        
        if(_groundTrigger.IsGrounded && jumpPressed && isYVelocitySlow)
        {
            _rigidBody.AddForce(new Vector2(0f, _jumpForce));
        }
    }
}
