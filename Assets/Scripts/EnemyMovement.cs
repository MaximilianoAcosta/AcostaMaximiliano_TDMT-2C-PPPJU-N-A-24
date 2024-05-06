using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float MinDistance;
    [SerializeField] private EnemyBehaviour EnemyBehaviour;
    [SerializeField] private Enemy_Animation_Controller AnimController;
    [SerializeField] private float StunDuration;
    
    private void Start()
    {
        EnemyBehaviour = GetComponent<EnemyBehaviour>();
        AnimController = GetComponent<Enemy_Animation_Controller>();
    }

    public void MoveToTarget()
    {

        if (CheckIfTargetIsFar())
        {
            
            EnemyBehaviour.Agent.isStopped = false;

            EnemyBehaviour.Agent.SetDestination(EnemyBehaviour.GetPlayer().position);

        }
        else
        {
            
            LookAtPlayer();
        }
        AnimController.SetVelocity(EnemyBehaviour.Agent.velocity.magnitude);

    }
    private float GetDistanceToPlayer()
    {
        return Vector3.Distance(transform.position, EnemyBehaviour.Player.position);
    }
    public bool CheckIfTargetIsFar()
    {
        return GetDistanceToPlayer() > MinDistance;
    }
    private void LookAtPlayer()
    {
        EnemyBehaviour.Agent.isStopped = true;
        Vector3 targetPosition = EnemyBehaviour.Player.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
    }
    public void GetStun()
    {
        StartCoroutine(StunForDuration());
    }
    private IEnumerator StunForDuration()
    {
        EnemyBehaviour.Agent.speed = 0;
        yield return new WaitForSeconds(StunDuration);
        EnemyBehaviour.Agent.speed = 4.5f;
    }
}
