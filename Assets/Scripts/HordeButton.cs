using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeButton : MonoBehaviour
{
    private bool HordeModeOn;
    private Material baseMat;
    private PlayerWeapons playerWeapons;
    private Vector3 initPos;
    private ThirdPersonController playerMove;

    private void Start() 
    {
        baseMat = GetComponentInParent<Renderer>().material;
        baseMat.color = Color.white; 
        HordeModeOn = false;
        initPos = transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag != "Player") {return;}
        if(!HordeModeOn)
        {
            playerMove = other.GetComponent<ThirdPersonController>();
            playerMove.SetMoveSpeed(30f);
            playerMove.SetHasted();
            baseMat.color = Color.blue;
            HordeModeOn = true;
            StartCoroutine(EndMode());
        }
    }

    private IEnumerator EndMode()
    {
        transform.position += new Vector3(0,-0.15f,0);
        yield return new WaitForSeconds(1f);
        TurnOff();
        transform.position = initPos;
    }

    private void TurnOff()
    {
        baseMat.color = Color.white;
        transform.position = initPos;
        HordeModeOn = false;
    }
}
