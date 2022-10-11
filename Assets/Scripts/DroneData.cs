using UnityEngine;

[CreateAssetMenu(fileName = "DroneData", menuName = "DroneData", order = 1)]
public class DroneData : ScriptableObject
{
    public string Name;
    public int Damage;
    public float AttackSpeed;
    public float ProjSpeed;
    public float AoE;
    public float LifeSpan;
    public float DisappearTime; 
    public GameObject Bullet;
    public GameObject Prefab;
}