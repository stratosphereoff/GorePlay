using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDispencer : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            var item = Instantiate(prefab, transform.position + Vector3.up, Quaternion.identity);
        }
    }
}
