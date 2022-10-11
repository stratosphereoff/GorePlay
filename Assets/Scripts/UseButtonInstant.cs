using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseButtonInstant : MonoBehaviour
{       
    private ThirdPersonController playerMove;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag != "Player") {return;}
        playerMove = other.GetComponent<ThirdPersonController>();
        playerMove.SetMoveSpeed(30f);
        playerMove.SetHasted();
        Destroy(gameObject, 0.2f);
    }
}
