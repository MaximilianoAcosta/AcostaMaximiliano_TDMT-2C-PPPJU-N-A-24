using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponChange : MonoBehaviour
{
    [SerializeField] List<GameObject> WeaponObject = new();
    [SerializeField] List<IWeapons> weapons = new();
    private GameObject LastWeapon;
    private void Start()
    {
        foreach (var weapon in WeaponObject)
        {
            if (!weapons.Contains(weapon.GetComponent<IWeapons>()))
            {
                weapons.Add(weapon.GetComponent<IWeapons>());
            }
        }
        //SetDefaultWeapon
        Shooting.SetPlayerWeapon(weapons[0]);
        LastWeapon = WeaponObject[0];
    }
    public void ChangeWeapon(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            int.TryParse(ctx.control.name, out int numKeyValue);
            if( LastWeapon != WeaponObject[numKeyValue - 1])
            {
                LastWeapon.SetActive(false);
                WeaponObject[numKeyValue - 1].SetActive(true);
                Shooting.SetPlayerWeapon(weapons[numKeyValue - 1]);
                LastWeapon = WeaponObject[numKeyValue - 1];
            }
        }

    }
}
