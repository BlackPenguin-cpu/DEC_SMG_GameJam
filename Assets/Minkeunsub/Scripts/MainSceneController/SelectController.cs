using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowderAmount
{
    NONE,
    LESS,
    MUCH,
    FULL
}

public class SelectController : MonoBehaviour
{
    public PowderAmount curPowderAmount;
    public bool Packing;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SelectPowderAmount(int n)
    {
        curPowderAmount = (PowderAmount)n;
    }
}
