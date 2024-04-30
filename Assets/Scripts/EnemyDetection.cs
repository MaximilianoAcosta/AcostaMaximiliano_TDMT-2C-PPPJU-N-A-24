using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private Enemy_Behaviour enemyBehaviour;
    [SerializeField] private Transform target;
    [SerializeField] private float ChaseDuration;
    [SerializeField] private bool IsChasing;

    [SerializeField] private string PlayerTag;
    private RaycastHit hit;
    private void OnTriggerStay(Collider other)
    {
        if (target == null && other.CompareTag(PlayerTag))
        {
            target = other.transform;
        }
        if (target != null && !IsChasing)
        {
            raycastToPlayer();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            target = null;
        }
    }

    private IEnumerator InitiateChase()
    {
        IsChasing = true;
        enemyBehaviour.Player = target;
        yield return new WaitForSeconds(ChaseDuration);
        IsChasing = false;
        enemyBehaviour.Player = transform;
    }

    private void raycastToPlayer()
    {
        Vector3 Origin = transform.position;
        Origin.y = 0;
        Vector3 objective = target.position;
        objective.y = 0;
        Vector3 direction = objective - Origin;
        if (Physics.Raycast(Origin, direction, out hit, direction.magnitude))
        {
            if (hit.transform.gameObject.CompareTag(PlayerTag))
            {
                float angle = Vector3.Angle(direction, transform.forward);
                if (angle <= 90)
                { 
                    StartCoroutine(InitiateChase());
                }
            }
        }
    }
}

/*float angle = Vector3.Angle(direction, transform.forward);
Debug.Log(angle);
Debug.DrawRay(transform.position, transform.forward, Color.blue);
if (angle <= 90)
{
    Debug.DrawRay(transform.position, direction, Color.green);
    StartCoroutine(InitiateChase());
}
else
{
  Debug.DrawRay(transform.position, direction, Color.red); 
}*/
