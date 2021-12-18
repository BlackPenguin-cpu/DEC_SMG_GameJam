using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GaugeStatus
{
    NONE,
    A_YELLOW,
    B_GREEN,
    C_BLUE,
    D_RED
}

public class RecipeController : Singleton<RecipeController>
{
    [Header("Gameobjects")]
    public Button[] recipeButtons;
    public Image[] recipeDesces;
    public Image[] recipeGauges;

    [Header("Sprites")]
    public Sprite[] idleSprite;
    public Sprite[] selectedSprite;

    [Header("Gauge")]
    public Color[] gauge_colors = new Color[4];
    public GaugeStatus[] gaugeStatus = new GaugeStatus[5];
    public int curGaugeIndex = 0;
    public int maxGaugeIndex = 5;

    protected override void Awake()
    {

    }

    void Start()
    {
        SetRecipeDesc(0);
        InitAllStatus();
    }

    void Update()
    {
        //UpdateDebug();
    }

    void UpdateDebug()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (curGaugeIndex == maxGaugeIndex)
            {
                InitAllStatus();
            }
            else
            {
                int rand = Random.Range(1, 5);
                SelectGauge(rand);
            }
        }
    }

    public void InitAllStatus()
    {
        for (int i = 0; i < recipeGauges.Length; i++)
        {
            recipeGauges[i].color = new Color(1, 1, 1, 1);
            gaugeStatus[i] = GaugeStatus.NONE;
            curGaugeIndex = 0;
        }
    }

    public void SelectGauge(int state)
    {
        if (curGaugeIndex < maxGaugeIndex)
        {
            recipeGauges[curGaugeIndex].color = gauge_colors[(int)state];

            switch (state)
            {
                case 0:
                    gaugeStatus[curGaugeIndex] = GaugeStatus.A_YELLOW;
                    break;
                case 1:
                    gaugeStatus[curGaugeIndex] = GaugeStatus.B_GREEN;
                    break;
                case 2:
                    gaugeStatus[curGaugeIndex] = GaugeStatus.C_BLUE;
                    break;
                case 3:
                    gaugeStatus[curGaugeIndex] = GaugeStatus.D_RED;
                    break;
                default:
                    break;
            }
            curGaugeIndex++;
        }
    }

    public void SetRecipeDesc(int n)
    {
        for (int i = 0; i < recipeDesces.Length; i++)
        {
            recipeButtons[i].image.sprite = idleSprite[i];
            recipeDesces[i].gameObject.SetActive(false);
        }

        recipeButtons[n].image.sprite = selectedSprite[n];
        recipeDesces[n].gameObject.SetActive(true);
    }
}
