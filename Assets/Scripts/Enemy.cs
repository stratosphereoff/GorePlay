using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private StatusBar hpBar;
    [SerializeField] private GameObject onDeathExplosion;
    private GameObject targetGameObject;
    private Transform targetDestination;
    private Rigidbody rb;
    private PlayerCharacter targetCharacter;

    private bool isWandering;
    private bool isMoving;
    private bool isDead;

    private float attackCooldownTimer;

    public float currentSpeed = 4f;
    public float attackCooldown = 2f;
    public int maxHp = 60;
    public int currentHp = 60;
    public int attackDamage = 5;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        var player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            isWandering = false;
            SetTarget(player);
        }
        else
        {
            isWandering = true;
        }
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
        isMoving = true;
    }
    void Update()
    {
        if(isWandering){return;}
        attackCooldownTimer -= Time.deltaTime;
    }

    private void FixedUpdate() 
    {
        if(targetDestination == null || !isMoving) return;
        Vector3 pos = Vector3.MoveTowards(transform.position, targetDestination.position, currentSpeed * Time.fixedDeltaTime);
        rb.MovePosition(pos);
        transform.LookAt(pos);
    }

    private void OnCollisionStay(Collision collision) 
    {
        if(collision.gameObject == targetGameObject)
        {
            isMoving = false;
            if (attackCooldownTimer < 0)
            {
                Attack();
            }
        }
    }

    private void OnCollisionExit(Collision collision) 
    {
        if(collision.gameObject == targetGameObject)
        {
            isMoving = true;
        }
    }

    private void Attack()
    {
        attackCooldownTimer = attackCooldown;
        
        if(targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<PlayerCharacter>();
        }
        
        targetCharacter.TakeDamage(attackDamage, false);
    }

    // private IEnumerator DamageDelay(float sceconds)
    // {
    //     yield return new WaitForSeconds(sceconds);
    //     targetCharacter.TakeDamage(attackDamage, false);
    // }

    public void TakeDamage(int damage, bool isCritical)
    {
        if (isDead) return;

        // var trueDamage = damage * multiplier;
        currentHp -= damage;

        // if (multiplier > 1)
        // {
        //     _isCriticalHit = true;
        // }
        // else
        // {
        //     _isCriticalHit = false;
        // }

        // FloatingTextPoints.Create(transform.position, trueDamage, _isCriticalHit);

        if(currentHp < 1)
        {
            isDead = true;
            // targetGameObject.GetComponent<Level>().AddExperience(experienceReward);
            // _dropOnDestroy.CheckDrop();

            // Instantiate(GameAssets.i.onDeathEffect, transform.position, Quaternion.identity);
            
            // if(_animate != null)
            // {
            //     _animate.animator.SetTrigger("onDeath");
            //     speed = 0;
            //     Destroy(gameObject, 0.4f);
            // }
            // else
            // {
            //     Destroy(gameObject);               
            // }

            Instantiate(onDeathExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);  

            // EnemyCount.enemyList.Remove(this);
            // OnDeath?.Invoke();

            // if(EnemyCount.enemyList.Count == 0)
            // {
            //     OnDeathLast?.Invoke();
            //     EnemyCount.GetEnemyList().Clear();
            // }            
        }

        // if(maxHp > 25000 && currentHp < 20000)
        // {
        //     if(!_enraged)
        //     {
        //         _enraged = true;
        //         SetEnraged();
        //     }
        // }
        
        hpBar.SetState(currentHp, maxHp);
    }
}
