using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
    [SerializeField] private Transform bar;
    private GameObject target;

    private void Awake() 
    {
        target = GameObject.FindWithTag("MainCamera");
    }

    public virtual void SetState(int current, int max)
    {
        float state = (float)current;
        state /= max;
        if(state < 0f) {state = 1; }
        bar.transform.localScale = new Vector3(state, 1f, 1f);
    }

    private void Update() 
    {
        transform.LookAt(target.transform);
    }
}
