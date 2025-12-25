using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Rigidbody2D rigidbody = null;
    private SpriteRenderer background = null;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        rigidbody.linearVelocity = new Vector2(xInput, yInput) * speed;

        float maxY = Camera.main.orthographicSize;
        float maxX = maxY * Camera.main.aspect;

        float x = Mathf.Clamp(transform.position.x, -maxX, maxX);
        float y = Mathf.Clamp(transform.position.y, -maxY, maxY);

        transform.position = new Vector2(x, y);
    }

    void Update()
    {
        Move();
    }
}
