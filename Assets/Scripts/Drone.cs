using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private GameObject bullet;
    private DroneData droneSO;
    public GameObject target;
    private float disarmTimer;
    private float attackTimer;
    private int damage;

    private void OnEnable()
    {
        PlayerCharacter.OnDeath += OnPlayerDeath;
    }
    
    private void OnDisable()
    {
        PlayerCharacter.OnDeath -= OnPlayerDeath;
    }

    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            target = collider.gameObject;
            transform.LookAt(target.transform);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            target = null;
        }
    }
    private void Update() 
    {
        attackTimer -= Time.deltaTime;
        if(attackTimer < 0 && target != null)
        {
            var newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            if(newBullet.TryGetComponent(out Bullet _bullet))
            {
                _bullet.SetData(droneSO);
                _bullet.SetTarget(target);

            }
            if(newBullet.TryGetComponent(out Granade _granade))
            {
                _granade.SetTriggerTime(0.5f);
            }

            SetAttackTimer();
        }
        disarmTimer -= Time.deltaTime;
        if(disarmTimer > 0) {return;}
        transform.rotation = transform.parent.parent.rotation;
        disarmTimer = droneSO.AttackSpeed * 10f;
    }

    private void SetAttackTimer()
    {
        attackTimer = droneSO.AttackSpeed;
    }

    public void SetData(DroneData _droneSO)
    {
        droneSO = _droneSO;
        bullet = _droneSO.Bullet;
    }

    private void OnPlayerDeath()
    {
        Destroy(gameObject);
    }
}
