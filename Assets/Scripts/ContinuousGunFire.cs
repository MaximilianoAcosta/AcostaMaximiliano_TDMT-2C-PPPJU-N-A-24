using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ContinuousGunFire : MonoBehaviour, IWeapons
{
    [SerializeField] private string EnemyTag;
    [SerializeField] GameObject PlayerCamera;
    [SerializeField] private ParticleSystem fireMuzzle;
    [SerializeField] private EnemyBleed targetBleed;
    [SerializeField] private float damage;
    [SerializeField] float RateOfFire;
    [SerializeField] private RecoilGun recoilGun;
    private bool CanShoot = false;
    private RaycastHit hit;

    private void Update()
    {
        if (CanShoot)
        {
            StartCoroutine(WaitBetweenShots());
        }
    }
    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            CanShoot = true;
        }
        if (ctx.canceled)
        {
            StopAllCoroutines();
            CanShoot = false;
        }
    }
    private IEnumerator WaitBetweenShots()
    {
        CanShoot = false;
        recoilGun.TriggerRecoil();
        fireMuzzle.Play();
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, maxDistance: 1000f))
        {
            if (hit.transform.gameObject.CompareTag(EnemyTag))
            {
                targetBleed.onHit(hit.point);
                hit.transform.TryGetComponent(out HealthController EnemyHealth);
                if (EnemyHealth != null) EnemyHealth.takeDamage(damage);

            }
        }
        yield return new WaitForSeconds(RateOfFire);
        CanShoot = true;
    }
}
