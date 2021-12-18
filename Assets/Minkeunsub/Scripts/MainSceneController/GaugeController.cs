using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{

    public Image Gauge;
    public int maxValue = 100;
    public int curValue;

    public float delay = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        TimeGaugeLogic();
        Gauge.fillAmount = curValue / maxValue;
    }

    public void TimeGaugeLogic()
    {
        if(delay >= 1)
        {
            DecreaseValue(1);
            delay = 0;
        }
        delay += Time.deltaTime;
    }

    public void DecreaseValue(int _value)
    {
        curValue -= _value;
    }
}
