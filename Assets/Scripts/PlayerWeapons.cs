using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public static List<GameObject> droneList = new List<GameObject>();
    [SerializeField] private GameObject dronePrefab;
    [SerializeField] private Transform[] slotTransforms;
    private DroneData droneData;

    private void OnEnable()
    {
        PlayerCharacter.OnDeath += OnPlayerDeath;
    }
    
    private void OnDisable()
    {
        PlayerCharacter.OnDeath -= OnPlayerDeath;
        droneList.Clear();
    }

    public void Summon(DroneData droneData)
    {
        if(droneList.Count >= 2) {return;}
        var newDrone = Instantiate(droneData.Prefab, slotTransforms[droneList.Count].position, Quaternion.identity, transform);
        newDrone.GetComponent<Drone>().SetData(droneData);
        droneList.Add(newDrone);
    }

    private void OnPlayerDeath()
    {
        droneList.Clear();
    }
}
