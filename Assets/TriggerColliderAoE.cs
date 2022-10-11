using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColliderAoE : MonoBehaviour
{
    [SerializeField] private Spawner spawner;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            spawner.SetBool(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            spawner.SetBool(false);
        }
    }
}
