using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : Singleton<GaugeController>
{

    public Image Gauge;
    public float maxValue = 100;
    public float curValue;

    public float delay = 0;
    
    void Start()
    {
        curValue = maxValue;
    }

    void Update()
    {
        TimeGaugeLogic();
        Gauge.fillAmount = curValue / maxValue;
    }

    public void TimeGaugeLogic()
    {
        if(MainSceneUIController.Instance.InGameState == GameState.GameInProgress)
        {
            if (delay >= 1)
            {
                DecreaseValue(1);
                delay = 0;
            }
            delay += Time.deltaTime;
        }

        if(curValue <= 0)
        {
            MainSceneUIController.Instance.InGameState = GameState.GameOver;
        }
    }

    public void DecreaseValue(float _value)
    {
        curValue -= _value;
    }
}
