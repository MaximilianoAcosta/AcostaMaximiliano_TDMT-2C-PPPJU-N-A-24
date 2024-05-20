using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBullets : MonoBehaviour
{
    static Dictionary<string,int> AmmoType = new(); 
    public static List<string> AmmoNames = new();
    private static TMP_Text RvrAmmoText;
    private static TMP_Text SmgAmmoText;

    [SerializeField] string RvrAmmoName;
    [SerializeField] string SmgAmmoName;
    private void Start()
    {
        RvrAmmoText = GameObject.Find(RvrAmmoName).GetComponent<TMP_Text>();
        SmgAmmoText = GameObject.Find(SmgAmmoName).GetComponent<TMP_Text>();
        AmmoNames.Add(RvrAmmoName);
        AmmoNames.Add(SmgAmmoName);
        AmmoType.Add(RvrAmmoName, 30);
        AmmoType.Add(SmgAmmoName, 0);
       
        RvrAmmoText.SetText(AmmoType[RvrAmmoName].ToString());
        SmgAmmoText.SetText(AmmoType[SmgAmmoName].ToString());
    }
    private void OnDisable()
    {
        AmmoType.Clear();
        AmmoNames.Clear();
    }

    public static int GetAmmo(string type)
    {
        AmmoType.TryGetValue(type, out int value);
        return value; 
    }

    public static void SpendAmmo(string type)
    {
  
        AmmoType[type]--;
        SetAmmoText(type);
    }
    public static void AddBullets(string type, int ammount)
    {
        AmmoType[type] += ammount;
        SetAmmoText(type);
    }
    private static void SetAmmoText(string type)
    {
        switch (type)
        {
            case "RevAmmo":
                RvrAmmoText.SetText(AmmoType["RevAmmo"].ToString());
                break;
            case "SmgAmmo":
                SmgAmmoText.SetText(AmmoType["SmgAmmo"].ToString());
                break;
            default:
                break;
        }
    }
}
