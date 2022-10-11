using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<IDamagable>().TakeDamage(1000, false);
        }
        else
        {
            if(collider.gameObject.tag == "Trigger"){return;}
            Destroy(collider.gameObject);
        }
    }
}
