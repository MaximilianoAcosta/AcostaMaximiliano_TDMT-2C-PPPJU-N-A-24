using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Hazzard : MonoBehaviour
{
    [SerializeField] private string TagToCollide;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(TagToCollide))
        {
            Debug.Log($"{TagToCollide} hit");
        }
    }
}
