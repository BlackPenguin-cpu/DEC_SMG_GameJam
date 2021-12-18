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
    public List<int> thisGaugeStatus = new List<int>();
    public bool Packed;

    int point;

    public static int[,] recipe =
{
        {1, 2, 2, 3, 4, 4 },
        {2, 3, 3, 3, 4, 0 },
        {1, 3, 3, 4, 4, 0 },
        {4, 4, 4, 0, 0, 0 },
        {1, 2, 3, 3, 4, 4 },
        {2, 2, 4, 0, 0, 0 },
    };

    public GameState InGameState;

    protected override void Awake()
    {
        
    }

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
                Day.Instance.StartCoroutine(Day.Instance.GameOver());
                break;
            case GameState.GameEnd:
                GameEndEvent();
                break;
            default:
                break;
        }
    }

    public void GameEndEvent()
    {
        Day.Instance.StartCoroutine(Day.Instance.DaynextDay());
        // 뉴스나 뭐시기들
    }

    public void SubmitValue(PowderAmount _thisPowder, int[] _thisGauge, bool _Packed)
    {
        thisPowderAmount = _thisPowder;

        thisGaugeStatus.Clear();
        foreach (var item in _thisGauge)
        {
            thisGaugeStatus.Add(item);
        }

        Packed = _Packed;
    }

    public int CheckValue(PowderAmount _checkPowder, int[] _checkGauge, bool _checkPacked)
    {
        point = 0;

        if(Packed == _checkPacked)
        {
            point++;
        }

        for (int i = 0; i < _checkGauge.Length; i++)
        {
            if (_checkGauge[i] == thisGaugeStatus[i] &&  _checkGauge[i] != 0)
            {
                point++;
            }
        }

        if (thisPowderAmount == _checkPowder) point++;
        return point;
    }
}
