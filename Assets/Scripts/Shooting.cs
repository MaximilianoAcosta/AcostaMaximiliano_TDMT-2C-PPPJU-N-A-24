using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [SerializeField] private string EnemyTag;
    [SerializeField] GameObject PlayerCamera;
    [SerializeField] private ParticleSystem fireMuzzle;
    [SerializeField] private EnemyBleed targetBleed;
    [SerializeField] private float damage;
    [SerializeField] private bool CanShoot = true;
    [SerializeField] float RateOfFire;
    [SerializeField] private RecoilGun recoilGun;
    private RaycastHit hit;

    public void shoot(InputAction.CallbackContext ctx)
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
                    HealthController EnemyHealth;
                    targetBleed.onHit(hit.point);
                    hit.transform.TryGetComponent(out EnemyHealth);
                    if (EnemyHealth != null)
                    {
                        EnemyHealth.takeDamage(damage);
                    }
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

