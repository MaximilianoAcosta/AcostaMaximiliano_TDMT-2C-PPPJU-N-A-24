using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    
    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction=dir;
    }
    private void FixedUpdate()
    {
        transform.position += direction;
    }
}
