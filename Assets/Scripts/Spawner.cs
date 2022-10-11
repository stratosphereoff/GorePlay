using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject bigEnemy;
    [SerializeField] private float ENEMY_SPAWN_COOLDOWN;
    private float _timer;
    private bool _working;

    private void Start()
    {
        _timer = ENEMY_SPAWN_COOLDOWN;
        _working = false;
    }
    private void Update()
    {
        if (!_working) {return;}
        _timer -= Time.deltaTime;
        if(_timer < 0)
        {
            if(Random.Range(0,100) < 90)
            {
                Instantiate(enemy, transform.position, Quaternion.identity);
                SetTimer(ENEMY_SPAWN_COOLDOWN);
            }
            else
            {
                Instantiate(bigEnemy, transform.position, Quaternion.identity);
                SetTimer(ENEMY_SPAWN_COOLDOWN);
            }
        }
    }

    public void SetTimer(float timer)
    {
        _timer = timer;
    }

    public void SetCooldown(float cd)
    {
        ENEMY_SPAWN_COOLDOWN = cd;
    }

    public void SetBool(bool working)
    {
        _timer = ENEMY_SPAWN_COOLDOWN;
        _working = working;
    }
}
