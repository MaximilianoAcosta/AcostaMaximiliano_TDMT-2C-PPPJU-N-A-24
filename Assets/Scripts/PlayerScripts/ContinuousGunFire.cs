using System.Collections;
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
    [SerializeField] private string AmmoType;
    [SerializeField] private AudioSource AudioSource;
    private bool CanShoot = false;
    private RaycastHit hit;

    private void Update()
    {
        if (CanShoot && PlayerBullets.GetAmmo(AmmoType) > 0)
        {
            StartCoroutine(WaitBetweenShots());
        }
    }
    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && PlayerBullets.GetAmmo(AmmoType) > 0)
        {
            AudioSource.Play();
            CanShoot = true;
        }
        if (ctx.canceled)
        {
            StopAllCoroutines();
            CanShoot = false;
            if (AudioSource.isPlaying) { AudioSource.Stop(); } 
        }
    }
    private IEnumerator WaitBetweenShots()
    {
        CanShoot = false;
        recoilGun.TriggerRecoil();
        PlayerBullets.SpendAmmo(AmmoType);
        fireMuzzle.Play();
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, maxDistance: 1000f))
        {
            if (hit.transform.gameObject.CompareTag(EnemyTag))
            {
                targetBleed.onHit(hit.point);
                hit.transform.TryGetComponent(out HealthController EnemyHealth);
                if (EnemyHealth != null) EnemyHealth.takeDamage(damage);
                hit.transform.TryGetComponent(out EnemyMovement movement);
                movement.LookAtPlayer();
            }
        }
        yield return new WaitForSeconds(RateOfFire);
        CanShoot = true;
    }
}
