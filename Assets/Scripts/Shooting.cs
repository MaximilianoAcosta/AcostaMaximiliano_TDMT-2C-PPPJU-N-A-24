using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField] private LayerMask enemies;
    [SerializeField] GameObject PlayerCamera;
    [SerializeField] private GameObject Crosshair;
    [SerializeField] private Color NoTargetColor = Color.green;
    [SerializeField] private Color TargetColor= Color.green;
    [SerializeField] private ParticleSystem fireMuzzle;
    [SerializeField] private EnemyBleed targetBleed;
    private RaycastHit hit;
    public void shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            fireMuzzle.Play();
            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, maxDistance: 1000f, enemies))
            {
                targetBleed.onHit(hit.transform.position);
                hit.transform.gameObject.SetActive(false);
            }
        }
    }
    private void Update()
    {
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, maxDistance: 1000f, enemies))
        {
            Crosshair.GetComponent<Image>().color = TargetColor;
        }
        else
        {
            Crosshair.GetComponent<Image>().color = NoTargetColor;
        }
    }
}

