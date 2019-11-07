using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    CircleCollider2D circleCollider;
    public Vector2 direction;
    public float speed;
    public FloatingJoystick joystick;
    private Teleporter[] teleporters;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        rigidbody.gravityScale = 0;
        transform.position = new Vector3(-3.5f,-4.5f,0.0f);
        if (teleporters == null)
        {
            teleporters = FindObjectsOfType<Teleporter>();
        }
        for (int i = 0; i < teleporters.Length; i++)
        {
            teleporters[i].gameObject.SetActive(true);
        }
    }

    void Update()
    {
#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        direction = new Vector2(joystick.Horizontal, joystick.Vertical);
#elif UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
#endif
        direction = direction.normalized;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = direction * speed * Time.fixedDeltaTime;
    }
}
