using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Health_Visual : MonoBehaviour
{
    [SerializeField] private Image DamageScreenBorder;
    [SerializeField] private float MaxAlphaScreenBorder;
    [SerializeField] private Image DamageScreen;
    [SerializeField] private float MaxAlphaScreen;
    [SerializeField] private TMP_Text HealthText;
    [SerializeField] private HealthController PlayerHealth;

    private void Reset()
    {
        PlayerHealth.onDamageTakenEvent.AddListener(setUIhealthScreen);
        PlayerHealth.onDamageTakenEvent.AddListener(setTextHealth);
    }
    public void setUIhealthScreen()
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
        float v = (100 - PlayerHealth.Health) / transparencylimit;
        return v;
    }
    public void setTextHealth()
    {
        HealthText.text = PlayerHealth.Health.ToString();
    }
}
