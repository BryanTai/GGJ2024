using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControls : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _jumpForce = 400f;


    private void Awake()
    {
        if(_rigidBody == null)
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        bool jumpPressed = Input.GetButtonDown("Jump");

        _rigidBody.velocity = new Vector2 (moveHorizontal * _speed, _rigidBody.velocity.y);
        
        if(jumpPressed)
        {
            _rigidBody.AddForce(new Vector2(0f, _jumpForce));
        }
    }
}
