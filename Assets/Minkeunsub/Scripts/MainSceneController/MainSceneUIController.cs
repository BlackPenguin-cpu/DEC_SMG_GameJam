using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    GameInProgress,
    GameOver,
    GameEnd
}

public class MainSceneUIController : Singleton<MainSceneUIController>
{

    public PowderAmount thisPowderAmount;
    public List<GaugeStatus> thisGaugeStatus = new List<GaugeStatus>();
    public bool Packed;

    int point;

    public int[,] recipe =
    {
        {1, 2, 1, 2 },
        {0, 1, 3, 1 },
        {1, 0, 2, 2 },
        {0, 0, 0, 3 },
        {1, 1, 2, 2 },
        {0, 2, 0, 1 },
    };

    public GameState InGameState;

    void Start()
    {
        
    }

    void Update()
    {
        switch (InGameState)
        {
            case GameState.GameInProgress:
                break;
            case GameState.GameOver:
                break;
            case GameState.GameEnd:
                break;
            default:
                break;
        }
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
        point = 0;

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
