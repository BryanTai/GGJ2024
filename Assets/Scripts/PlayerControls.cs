using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerControls : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _isGrounded = false;

    private int _groundMask;

    private void Awake()
    {
        if(_collider == null)
        {
            _collider = GetComponent<Collider2D>();
        }

        if(_rigidBody == null)
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        _groundMask = LayerMask.GetMask("Platform");
    }

    // Update is called once per frame
    private void Update()
    {
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        bool jumpPressed = Input.GetButtonDown("Jump");

        _rigidBody.velocity = new Vector2 (moveHorizontal * _speed, _rigidBody.velocity.y);
        
        if(_isGrounded && jumpPressed)
        {
            _rigidBody.AddForce(new Vector2(0f, _jumpForce));
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        int layerMask = 1 << col.gameObject.layer; 
        if(layerMask == _groundMask)
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        int layerMask = 1 << other.gameObject.layer;
        if (layerMask == _groundMask)
        {
            _isGrounded = false;
        }
    }
}
