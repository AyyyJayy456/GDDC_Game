using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    float vertical;

    [SerializeField]
    private int speed, sprintSpeed;
    
    private bool isSprinting = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int speedMultiplier = isSprinting ? sprintSpeed : speed;

        rb.linearVelocity = new Vector2(speedMultiplier * horizontal, speedMultiplier * vertical);
    }


    public void Move(InputAction.CallbackContext context)
    {

        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }

    public void Sprint(InputAction.CallbackContext context){
        isSprinting = context.performed;
    }
}
