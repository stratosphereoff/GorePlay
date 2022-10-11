using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildSpawner : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    void Start()
    {
        spawner.SetBool(true);
    }
}
