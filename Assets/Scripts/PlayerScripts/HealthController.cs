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
    public UnityEvent onDeathEvent;


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
        if (Health >= MaxHealth) Health = MaxHealth;
        onDamageTakenEvent?.Invoke();

        CheckIfDead();
    }
    private void CheckIfDead()
    {
        if (Health <= 0)
        {
            onDeathEvent?.Invoke();
        }
    }

   
}
