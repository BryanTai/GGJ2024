using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformMover : MonoBehaviour
{
    public float moveSpeed = 5;
    public bool isActive = false;

    // this should only be 1 or -1
    private int moveDirection = 1;

    private new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActive) 
        {
            Vector2 currentPos = transform.position;
            rigidbody.MovePosition(currentPos + (Vector2.right * moveSpeed * moveDirection * Time.deltaTime));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            moveDirection *= -1;
        }
    }

    public void SetSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;   
    }
}
