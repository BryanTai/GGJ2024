using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformMover : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float chanceToMove;
    public float moveSpeed = 6;
    public float moveVariation = 3;

    // this should only be 1 or -1
    private int moveDirection = 1;

    private new Rigidbody2D rigidbody;

    void Awake()
    {
        if (Random.Range(0f, 1f) > chanceToMove)
        {
            Destroy(this); return;
        }

        rigidbody = GetComponent<Rigidbody2D>();
        moveSpeed += Random.Range(-moveVariation, moveVariation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            Vector2 currentPos = transform.position;
            rigidbody.MovePosition(currentPos + (Vector2.right * moveSpeed * moveDirection * Time.deltaTime));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            moveDirection *= -1;
        }
    }

    public void SetSpeed()
    {
        
    }
}
