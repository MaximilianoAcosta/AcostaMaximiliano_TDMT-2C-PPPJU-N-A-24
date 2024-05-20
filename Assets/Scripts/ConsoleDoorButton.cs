using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Events;

public class ConsoleDoorButton : MonoBehaviour
{
    public static int ButtonsPressed;

    [SerializeField] bool ThisButtonPressed;
    [SerializeField] SpriteRenderer screen;

    public UnityEvent OnButtonPressed;
    private void OnCollisionEnter(Collision collision)
    {
        if (!ThisButtonPressed)
        {
            screen.color = Color.green;
            ThisButtonPressed = true;
            ButtonsPressed++;
            OnButtonPressed.Invoke();
        }
    }
}
