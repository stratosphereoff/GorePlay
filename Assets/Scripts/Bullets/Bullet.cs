using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject target;
    private Rigidbody rb;
    private DroneData droneSO;

    private bool hitDetected = false;

    private int damage;
    private float currentSpeed;
    private float timerLifeSpan;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        timerLifeSpan -= Time.deltaTime;
        if(timerLifeSpan < 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() 
    {
        if(hitDetected || target == null) return;
        Vector3 diraction = (target.transform.position - transform.position).normalized;
        rb.velocity = diraction * currentSpeed;
        if(Time.frameCount % 6 == 0)
        {
            Collider[] hit = Physics.OverlapSphere(transform.position, 0.5f);
            foreach (Collider c in hit)
            {
                if(c.TryGetComponent<IDamagable>(out var enemy))
                {
                    if(c.gameObject.tag == "Player") {return;}
                    enemy.TakeDamage(damage + Random.Range(0,10), false);
                    hitDetected = true;
                    DestoryGO();
                    break; 
                }
            }
        }
    }

    public void SetTarget(GameObject _target)
    {
        target = _target;
    }

    public void SetData(DroneData droneSO)
    {
        damage = droneSO.Damage;
        currentSpeed = droneSO.ProjSpeed;
        timerLifeSpan = droneSO.LifeSpan;
    }

    private void DestoryGO()
    {
        Destroy(gameObject, 0.2f);
    }
}
