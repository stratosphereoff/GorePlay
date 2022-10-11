using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) 
    {
        if(collision.CompareTag("PlayerAttractor"))
        {
            GameObject.FindWithTag("TimerUI").GetComponent<TimerUI>().SetFrozen();
            var _rb = GetComponent<Rigidbody>();
            var _sc = GetComponent<SphereCollider>();
            Destroy(_rb);
            Destroy(_sc);
            var a = 1;
            StartCoroutine(Move(collision, a));
        };
    }

    IEnumerator Move(Collider collision, int a)
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
            print("You won!");
            var player = collision.transform.parent;
            player.GetComponent<PlayerCharacter>().winOverlay.SetActive(true);
            Destroy(player.GetComponent<ThirdPersonController>()); 
        }
    }
}
