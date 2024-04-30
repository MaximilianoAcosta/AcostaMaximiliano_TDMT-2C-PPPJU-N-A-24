using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy_Behaviour : MonoBehaviour
{
    [SerializeField] private Enemy_Attack EnemyAttack;
    [SerializeField] private Enemy_Movement EnemyMovement;
    [SerializeField] private EnemyDetection EnemyDetection;
    [SerializeField] private string PlayerTag;
    public bool CanAttack { get; set; }
    public bool IsAttacking { get; set; }

    [SerializeField] public Transform Player;
    public NavMeshAgent Agent;


    private void Start()
    {
        CanAttack = true;
        Player = transform;
        Agent = GetComponent<NavMeshAgent>();
        EnemyAttack = GetComponent<Enemy_Attack>();
        EnemyMovement = GetComponent<Enemy_Movement>();
    }
    void Update()
    {

        if (Player.CompareTag(PlayerTag))
        {
            ChasePlayer();
        }
        else
        {
            EnemyMovement.MoveToTarget();
            //free roam
        }
    }
    private void ChasePlayer()
    {
        if (Agent.isStopped && CanAttack && !IsAttacking)
        {
            EnemyAttack.Attack();
        }
        else
        {
            EnemyMovement.MoveToTarget();
        }
    }

    public Transform GetPlayer()
    {
        return Player;
    }
}
