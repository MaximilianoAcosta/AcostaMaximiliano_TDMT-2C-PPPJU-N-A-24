using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunFire : MonoBehaviour, IWeapons
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
    [SerializeField] private int volume;
    private bool CanShoot = true;
    private RaycastHit hit;

    private void OnEnable()
    {
        CanShoot = true;
    }
    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.started && CanShoot && PlayerBullets.GetAmmo(AmmoType) > 0)
        {
            StartCoroutine(WaitBetweenShots());
            PlayerBullets.SpendAmmo(AmmoType);
            recoilGun.TriggerRecoil();
            fireMuzzle.Play();
            AudioSource.PlayOneShot(AudioSource.clip, AudioSource.volume);
            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, maxDistance: 1000f))
            {
                if (hit.transform.gameObject.CompareTag(EnemyTag))
                {
                    targetBleed.onHit(hit.point);
                    hit.transform.TryGetComponent(out HealthController EnemyHealth);
                    if (EnemyHealth != null) EnemyHealth.takeDamage(damage);
                    hit.transform.TryGetComponent(out EnemyMovement movement );
                    movement.LookAtPlayer();
                }
            }
        }
    }
    private IEnumerator WaitBetweenShots()
    {
        CanShoot = false;
        yield return new WaitForSeconds(RateOfFire);
        CanShoot = true;
    }
}
