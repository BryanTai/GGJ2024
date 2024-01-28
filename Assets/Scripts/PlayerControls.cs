using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerControls : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [HideInInspector] public bool IsGrounded = false;

    private void Awake()
    {
        if(_rigidBody == null)
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        bool jumpPressed = Input.GetButtonDown("Jump");

        _rigidBody.velocity = new Vector2 (moveHorizontal * _speed, _rigidBody.velocity.y);
        
        if(IsGrounded && jumpPressed)
        {
            _rigidBody.AddForce(new Vector2(0f, _jumpForce));
            IsGrounded = false;
        }
    }
}
