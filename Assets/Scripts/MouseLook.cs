using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField]private float sensitivityX,sensitivityY;
    [SerializeField] private GameObject playerCamera;
    float mouseX, mouseY;

    public void ReceiveMouseInputX(InputAction.CallbackContext ctx)
    {
        
        mouseX = ctx.ReadValue<float>()* sensitivityX;
    }
    public void ReceiveMouseInputY(InputAction.CallbackContext ctx)
    {
        mouseY = ctx.ReadValue<float>()* sensitivityY;
    }

    private void Update()
    {
        playerCamera.transform.Rotate(Vector3.left, mouseY * Time.deltaTime);
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);
    }
}
