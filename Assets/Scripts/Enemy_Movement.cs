using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] private float MinDistance;
    [SerializeField] private Enemy_Behaviour EnemyBehaviour;
    [SerializeField] private Enemy_Animation_Controller AnimController;
    private void Start()
    {
        EnemyBehaviour=GetComponent<Enemy_Behaviour>();
        AnimController=GetComponent<Enemy_Animation_Controller>();
    }

    public void MoveToTarget()
    {
        if (GetDistanceToPlayer()> MinDistance)
        {
            EnemyBehaviour.Agent.isStopped =false;
            EnemyBehaviour.Agent.SetDestination(EnemyBehaviour.Player.position);
            

        }
        else
        {
            //AnimController.SetVelocity(0);
            EnemyBehaviour.Agent.isStopped = true;
            Vector3 targetPosition = EnemyBehaviour.Player.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
        }
        AnimController.SetVelocity(EnemyBehaviour.Agent.velocity.magnitude);
    }
    private float GetDistanceToPlayer()
    {
        return Vector3.Distance(transform.position, EnemyBehaviour.Player.position);
    }

}
