using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) 
    {
        if(collision.CompareTag("PlayerAttractor"))
        {
            var _rb = GetComponent<Rigidbody>();
            var _sc = GetComponent<SphereCollider>();
            Destroy(_rb);
            Destroy(_sc);
            var a = 1;
            //PICK UP WEAPONS
            var weapons = collision.transform.parent.GetComponentInChildren<PlayerWeapons>();
            StartCoroutine(Move(collision, weapons, a));
        };
    }

    IEnumerator Move(Collider collision, PlayerWeapons weapons, int a)
    {
        var _pos = collision.transform.position + new Vector3(0,2f,0);
        while(transform.position != _pos)
        {
            a++;
            yield return new WaitForSeconds(0.01f);            
            transform.position = Vector3.MoveTowards(transform.position, _pos, a * Time.deltaTime);
        }
        if(transform.position == _pos)
        {
            GetComponent<IPickUpObject>().OnPickUp(weapons);
            Destroy(transform.parent.gameObject);  
        }
    }
}
