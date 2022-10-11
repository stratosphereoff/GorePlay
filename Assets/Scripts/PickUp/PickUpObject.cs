using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpObject : MonoBehaviour, IPickUpObject
{
    [SerializeField] private DroneData data;

    public void OnPickUp(PlayerWeapons weapons)
    {
        weapons.Summon(data);
    }
}