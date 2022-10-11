using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    private GameObject targetGameObject;
    private Transform targetDestination;
    private bool isWandering;

    void Start()
    {
        var player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            SetTarget(player);
        }
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    void FixedUpdate()
    {
        transform.LookAt(targetDestination);
    }
}
