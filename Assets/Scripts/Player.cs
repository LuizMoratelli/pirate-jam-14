using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10;
    Rigidbody2D _rigidBody;
    PlayerInput _input;
    Vector2 _movementDirection;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        _movementDirection = context.ReadValue<Vector2>();

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = _movementDirection * speed * Time.fixedDeltaTime * 60;
    }
}
