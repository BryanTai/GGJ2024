using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private Collider2D _groundCollider;
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private float _verticalSpeedLimitForGrounded;

    public bool IsGrounded = false;

    private int _groundMask;

    private void Awake()
    {
        if(_groundCollider == null)
        {
            _groundCollider = GetComponent<Collider2D>();
        }

        if(_playerRigidbody == null)
        {
            _playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        }

        _groundCollider.isTrigger = true;
        _groundMask = LayerMask.GetMask("Platform");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        int layerMask = 1 << other.gameObject.layer;
        bool isYVelocitySlow = Mathf.Abs(_playerRigidbody.velocity.y) < _verticalSpeedLimitForGrounded;
        if (layerMask == _groundMask && isYVelocitySlow)
        {
            IsGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        int layerMask = 1 << other.gameObject.layer;
        if (layerMask == _groundMask)
        {
            IsGrounded = false;
        }
    }
}
