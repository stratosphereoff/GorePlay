using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] private Ball ball;
    private float triggerTime;
    private void Start() 
    {
       StartCoroutine(ball.SetArmed(triggerTime));
    }

    public void SetTriggerTime(float _triggerTime)
    {
        triggerTime = _triggerTime; 
    }
}
