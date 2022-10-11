using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    private bool characterGrounded;

    private void OnTriggerStay(Collider other) 
    {
        if(characterGrounded){return;}
        Collider[] hit = Physics.OverlapSphere(transform.position, 0.5f);
        foreach (Collider c in hit)
        {
            if(c.TryGetComponent<IDamagable>(out var enemy))
            {
                if(c.gameObject.tag == "Player") {return;}
                enemy.TakeDamage(1 + Random.Range(0,10), false);
            }
        }
    }

    public void SetBool(bool grounded)
    {
        characterGrounded = grounded;
    }
}
