using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    [SerializeField] private float Health;
    [SerializeField] private Image DamageScreenBorder;
    [SerializeField] private float MaxAlphaScreenBorder;
    [SerializeField] private Image DamageScreen;
    [SerializeField] private float MaxAlphaScreen;
    [SerializeField] private TMP_Text HealthText;
    delegate void TakeDamage();
    TakeDamage onDamageTaken;
    public void Start()
    {
        Health=MaxHealth;
        onDamageTaken += setUIhealthScreen;
        onDamageTaken += setTextHealth;
        onDamageTaken += onDeath;
    }
    private void OnDisable()
    {
        onDamageTaken = null;
    }
    [ContextMenu("Take Damage")]
    public void takedfdamdaage()
    {
        takeDamage(10);
    }
    public void takeDamage(float damage)
    {
        Health -= damage;
        onDamageTaken.Invoke();
    }
    public void onDeath()
    {
        if (Health <= 0)
        {
        gameObject.SetActive(false);
        }
    }
    private void setUIhealthScreen()
    {
        Color FirstTempColor = DamageScreenBorder.color;
        Color SecondTempColor = DamageScreen.color;
        FirstTempColor.a = TransparencyCalculate(MaxAlphaScreenBorder);
        SecondTempColor.a = TransparencyCalculate(MaxAlphaScreen);
        DamageScreenBorder.color = FirstTempColor;
        DamageScreen.color = SecondTempColor;
    }
    private float TransparencyCalculate(float transparencylimit)
    {
        float v = (100 - Health) / transparencylimit;
        Debug.Log(v);
        return v;
    }
    private void setTextHealth()
    {
        HealthText.text = Health.ToString();
    }
}
