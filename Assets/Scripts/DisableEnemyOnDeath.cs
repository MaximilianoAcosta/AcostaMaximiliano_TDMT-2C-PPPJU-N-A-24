using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnemyOnDeath : MonoBehaviour
{
    [SerializeField] private float disabledelay;
 
    public void DisableOnDeath()
    {
        
        StartCoroutine(DisableAfterTime());
    }
    private IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(disabledelay);
        gameObject.SetActive(false);
    }
}
