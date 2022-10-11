using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCharacter : MonoBehaviour, IDamagable
{
    public static Action OnDeath;
    [SerializeField] private GameObject onDeathExplosion;
    [SerializeField] private GameObject model;
    [SerializeField] private DroneData starterWeapon;
    [SerializeField] private PlayerHealthBarUI hpBar;
    [Header("Overlays")]
    [SerializeField] private GameObject bloodHitOverlay;
    [SerializeField] private GameObject deathOverlay;
    public GameObject winOverlay;

    public static int maxHp { get; private set; }
    public static int currentHp { get; private set; }
    
    private bool isDead = false;
    private PlayerWeapons weapons;
    private ThirdPersonController controller;
    private Rigidbody rb;

    private void Awake()
    {
        weapons = GetComponentInChildren<PlayerWeapons>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start() 
    {
        maxHp = 100;
        currentHp = 100;
        weapons.Summon(starterWeapon);
    }

    public void TakeDamage(int damage, bool isCritical)
    {
        if(isDead) { return; }
        currentHp -= damage;
        StartCoroutine(HitEffect());
        if(currentHp < 0)
        {
            isDead = true;
            OnDeath?.Invoke();
            controller = GetComponent<ThirdPersonController>();
            controller.enabled = false;
            Instantiate(onDeathExplosion, transform.position, Quaternion.identity);
            model.SetActive(false);
            deathOverlay.SetActive(true);
            StartCoroutine("Rebirth");
        }
        hpBar.SetState(currentHp, maxHp);
    }

    private IEnumerator HitEffect()
    {
        bloodHitOverlay.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        bloodHitOverlay.SetActive(false);
    }

    private IEnumerator Rebirth()
    {
        yield return new WaitForSeconds(2f);
        maxHp = 100;
        currentHp = 100;
        isDead = false;
        model.SetActive(true);
        deathOverlay.SetActive(false);
        weapons.Summon(starterWeapon);
        gameObject.transform.position = new Vector3(0,1f,0);
        yield return new WaitForSeconds(0.1f);
        controller.enabled = true;
    }
}
