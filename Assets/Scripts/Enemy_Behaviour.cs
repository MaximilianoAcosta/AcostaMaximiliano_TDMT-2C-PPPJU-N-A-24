using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Behaviour : MonoBehaviour
{
    [SerializeField] private Enemy_Attack EnemyAttack;
    [SerializeField] private Enemy_Movement EnemyMovement;  
    public bool CanAttack;
    public Transform Player;
    public NavMeshAgent Agent ;

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        EnemyAttack = GetComponent<Enemy_Attack>();
        EnemyMovement = GetComponent<Enemy_Movement>();
    }
    void Update()
    {
        EnemyMovement.MoveToTarget();
        if (Agent.isStopped && CanAttack)
        {
            EnemyAttack.Attack();
        }
    }

}
