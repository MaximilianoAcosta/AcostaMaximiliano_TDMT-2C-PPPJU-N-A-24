using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField]private float sensitivityX,sensitivityY;
    private float usedsensitivityX, usedsensitivityY;
    [SerializeField] private GameObject playerCamera;
    float mouseX, mouseY;

    public float minAngle;
    public float maxAngle;
    public float FinalAngle;

    private void Awake()
    {
        StartCoroutine(EnableMouseMovement());
    }
    public void ReceiveMouseInputX(InputAction.CallbackContext ctx)
    {
        
        mouseX = ctx.ReadValue<float>()* usedsensitivityX;
    }
    public void ReceiveMouseInputY(InputAction.CallbackContext ctx)
    {
        mouseY = ctx.ReadValue<float>()* usedsensitivityY;
    }

    private void Update()
    {
        float angle = playerCamera.transform.localRotation.eulerAngles.x;
        if (angle > 180) 
        {
            angle -= 360;
        }
        FinalAngle = angle;
        if (angle <= maxAngle && mouseY<0 || angle > minAngle && mouseY > 0) 
        {
            playerCamera.transform.Rotate(Vector3.left, mouseY * Time.deltaTime);
        }
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);
    }
    private IEnumerator EnableMouseMovement()
    {
        yield return new WaitForSeconds(1);
        usedsensitivityX = sensitivityX;
        usedsensitivityY = sensitivityY;
    }
}
