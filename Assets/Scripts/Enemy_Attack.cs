using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Attack : MonoBehaviour
{

    [SerializeField] private Enemy_Behaviour EnemyBehaviour;
    [SerializeField] private Enemy_Animation_Controller AnimController;
    [SerializeField] private Collider Collider;
    [SerializeField] private float AttackWindup;
    [SerializeField] private float AttackDuration;
    [SerializeField] private float AttackCoolDown;
    private void Start()
    {
        EnemyBehaviour = GetComponent<Enemy_Behaviour>();
    }

    public void Attack()
    {
        
            Debug.Log("Attacked");
            StartCoroutine(ActivateAttackHitBox());
        
        
    }
    private IEnumerator ActivateAttackHitBox()
    {
        EnemyBehaviour.CanAttack = false;
        AnimController.SetIsAttacking(true);
        yield return new WaitForSeconds(AttackWindup);
        Collider.gameObject.SetActive(true);
        yield return new WaitForSeconds(AttackDuration);
        AnimController.SetIsAttacking(false);
        Collider.gameObject.SetActive(false);
        StartCoroutine(WaitBetWeenAttacks());
    }
    private IEnumerator WaitBetWeenAttacks()
    {
        yield return new WaitForSeconds(AttackCoolDown);
        EnemyBehaviour.CanAttack = true;
    }
}
