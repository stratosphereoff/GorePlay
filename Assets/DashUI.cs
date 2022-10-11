using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashUI : MonoBehaviour
{
    [SerializeField] private Image[] charges;

    public virtual void SetState(int slot, int on)
    {
        if(on == 1)
        {
            charges[slot].color = new Color32(75,255,200,100);            
        }
        else
        {
            charges[slot].color = new Color32(75,255,200,10); 
        }
    }
}
