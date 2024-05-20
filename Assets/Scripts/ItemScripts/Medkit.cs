using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] string PlayerTag;
    [SerializeField] float Heal;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            other.GetComponent<HealthController>().takeDamage(Heal * (-1));

            Destroy(gameObject);
        }
    }
}
