using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject onDeathExplosion;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float radius;
    [SerializeField] private float power;
    private Material baseMat;
    private AudioSource audioSource;
    private bool isArmed = false;

    void Awake()
    {
        baseMat = GetComponentInParent<Renderer>().material;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy" && !isArmed)
        {
            StartCoroutine(SetArmed(0));
        }
    }

    private IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(7f);
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                }
            }
            Instantiate(onDeathExplosion, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
    }

    public IEnumerator SetArmed(float amount)
    {
        yield return new WaitForSeconds(amount);
        isArmed = true;
        baseMat.color = Color.red;
        audioSource.PlayOneShot(clip, 10f);
        StartCoroutine(StartCountdown());
    }
}
