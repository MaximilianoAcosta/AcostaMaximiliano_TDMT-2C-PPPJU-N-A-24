using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerAimVisual : MonoBehaviour
{
    [SerializeField] private string EnemyTag;
    [SerializeField] GameObject PlayerCamera;
    [SerializeField] private Image CrossHair;
    [SerializeField] private Color NoTargetColor = Color.green;
    [SerializeField] private Color TargetColor = Color.green;
    private RaycastHit hit;
    private void Update()
    {
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, maxDistance: 1000f))
        {
            if (hit.transform.gameObject.CompareTag(EnemyTag))
            {
                CrossHair.color = TargetColor;

            }
            else
            {
                CrossHair.color = NoTargetColor;

            }
        }
        else
        {
            CrossHair.color = NoTargetColor;

        }
    }
}
