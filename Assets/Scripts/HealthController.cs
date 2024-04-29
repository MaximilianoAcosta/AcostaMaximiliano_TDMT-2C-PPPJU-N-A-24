using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    public float Health { get; set; }
    

    public UnityEvent onDamageTakenEvent;


    public void Start()
    {
        Health = MaxHealth;
    }
    private void OnDisable()
    {
        onDamageTakenEvent = null;
    }
    public void takeDamage(float damage)
    {
        Health -= damage;
        onDamageTakenEvent.Invoke();

        CheckIfDead();
    }
    private void CheckIfDead()
    {
        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

   
}
