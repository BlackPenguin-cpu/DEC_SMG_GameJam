using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneUIController : MonoBehaviour
{

    public PowderAmount thisPowderAmount;
    public List<GaugeStatus> thisGaugeStatus = new List<GaugeStatus>();
    public bool Packed;

    int point;

    public int[,] recipe =
    {
        {1, 1, 2, 2 },
        {1, 2, 2, 1 },
    };


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SubmitValue(PowderAmount _thisPowder, GaugeStatus[] _thisGauge, bool _Packed)
    {
        thisPowderAmount = _thisPowder;

        thisGaugeStatus.Clear();
        foreach (var item in _thisGauge)
        {
            thisGaugeStatus.Add(item);
        }

        Packed = _Packed;
    }

    public int CheckValue(PowderAmount _checkPowder, GaugeStatus[] _checkGauge, bool _checkPacked)
    {
        if(Packed == _checkPacked)
        {
            point++;
        }

        for (int i = 0; i < _checkGauge.Length; i++)
        {
            if (_checkGauge[i] == thisGaugeStatus[i]) point++;
        }

        if (thisPowderAmount == _checkPowder) point++;

        return point;
    }
}
