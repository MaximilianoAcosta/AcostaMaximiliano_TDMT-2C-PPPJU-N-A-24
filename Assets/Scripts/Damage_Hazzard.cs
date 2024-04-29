using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Hazzard : MonoBehaviour
{
    [SerializeField] private string tagToCollide;
    [SerializeField] private float damage;
    [SerializeField] private HealthController PlayerHealth = null;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tagToCollide))
        {
            Debug.Log($"{tagToCollide} hit");
            PlayerHealth = other.GetComponent<HealthController>();
            PlayerHealth.takeDamage(damage);
        }
    }
}
