using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    CircleCollider2D circleCollider;
    Vector2 direction;
    public float speed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        rigidbody.gravityScale = 0;
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction = direction.normalized;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = direction * speed * Time.fixedDeltaTime;
    }


}
