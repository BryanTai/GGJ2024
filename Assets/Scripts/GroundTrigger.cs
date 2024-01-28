using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private Collider2D _groundCollider;
    [SerializeField] private PlayerControls _playerControls;

    private int _groundMask;

    private void Awake()
    {
        if(_groundCollider == null)
        {
            _groundCollider = GetComponent<Collider2D>();
        }
        if(_playerControls == null)
        {
            Debug.LogError("MISSING PLAYER CONTROLS");
        }

        _groundCollider.isTrigger = true;
        _groundMask = LayerMask.GetMask("Platform");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        int layerMask = 1 << other.gameObject.layer;
        if(layerMask == _groundMask)
        {
            _playerControls.IsGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        int layerMask = 1 << other.gameObject.layer;
        if (layerMask == _groundMask)
        {
            _playerControls.IsGrounded = false;
        }
    }
}
