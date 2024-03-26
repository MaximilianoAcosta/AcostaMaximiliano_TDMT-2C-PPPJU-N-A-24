using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementnt : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private EntityMovement characterMover;
    private Vector2 HorizontalInput;
    public void getHorizontalInput(InputAction.CallbackContext ctx)
    {   
        HorizontalInput = ctx.ReadValue<Vector2>();
        MovePlayer(HorizontalInput);
    }
    public void moveOnturn(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            MovePlayer(HorizontalInput);
        }
    }

    private void MovePlayer(Vector2 direction)
    {
        Vector3 HorizontalMovement = (transform.right * direction.x + transform.forward * direction.y) * speed * Time.fixedDeltaTime;
        characterMover.SetDirection(HorizontalMovement);
    }

   
}
