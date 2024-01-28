using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerControls : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private GroundTrigger _groundTrigger;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    public Sprite flyingFace;
    public Sprite groundedFace;
    public SpriteRenderer faceRenderer;

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
        
        if(_groundTrigger.IsGrounded && jumpPressed)
        {
            _rigidBody.AddForce(new Vector2(0f, _jumpForce));
        }
        if(_groundTrigger.IsGrounded)
        {
            faceRenderer.sprite = groundedFace;
        }
        else
        {
            faceRenderer.sprite = flyingFace;
        }
    }
}
