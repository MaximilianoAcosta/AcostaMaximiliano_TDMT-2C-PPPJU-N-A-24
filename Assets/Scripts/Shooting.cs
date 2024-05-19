using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    private static IWeapons _Weapon;
    public void Shoot(InputAction.CallbackContext ctx)
    {
        _Weapon.Shoot(ctx);

    }

    public static void SetPlayerWeapon(IWeapons weapon)
    {

        _Weapon = weapon;
        Debug.Log(_Weapon);
    }
}

