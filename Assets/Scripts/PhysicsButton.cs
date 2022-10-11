using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public Transform c;
    public float x;
    public float y;
    public float z;
    public bool isA;
    public bool isB;
    public AudioSource ps;
    public AudioSource rs;
    public UnityEvent onP;
    public UnityEvent onR;
}
