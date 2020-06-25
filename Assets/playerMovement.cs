using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class playerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 2;

    Vector2 inputValue;
    Vector2 desiredVelocity;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMovement(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>();
        Debug.Log(inputValue);
    }

    private void FixedUpdate()
    {
        desiredVelocity = inputValue * speed;
        rb.velocity = desiredVelocity;
    }
}
