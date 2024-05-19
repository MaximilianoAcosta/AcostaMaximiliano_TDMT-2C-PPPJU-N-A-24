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
    private bool CanShoot = true;
    private RaycastHit hit;

    private void OnEnable()
    {
        CanShoot = true;
    }
    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.started && CanShoot)
        {
            StartCoroutine(WaitBetweenShots());
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
        }
    }
    private IEnumerator WaitBetweenShots()
    {
        CanShoot = false;
        yield return new WaitForSeconds(RateOfFire);
        CanShoot = true;
    }
}
