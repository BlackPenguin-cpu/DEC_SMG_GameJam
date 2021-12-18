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

    Animator anim;

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
    public int maxGaugeIndex = 6;

    protected override void Awake()
    {

    }

    void Start()
    {
        anim = GetComponent<Animator>();
        SetRecipeDesc(0);
        InitAllStatus(false);
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
                InitAllStatus(true);
            }
            else
            {
                int rand = Random.Range(1, 5);
                SelectGauge(rand);
            }
        }
    }

    public void InitAllStatus(bool eventActive)
    {
        for (int i = 0; i < recipeGauges.Length; i++)
        {
            recipeGauges[i].color = new Color(1, 1, 1, 1);
            gaugeStatus[i] = GaugeStatus.NONE;
            curGaugeIndex = 0;
        }

        if (eventActive)
            anim.SetBool("IsEvent", true);
    }

    public void EndEvent()
    {
        anim.SetBool("IsEvent", false);
    }

    public void SelectGauge(int state)
    {
        if (curGaugeIndex < maxGaugeIndex)
        {
            recipeGauges[curGaugeIndex].color = gauge_colors[(int)state];
            gaugeStatus[curGaugeIndex] = (GaugeStatus)state;
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
