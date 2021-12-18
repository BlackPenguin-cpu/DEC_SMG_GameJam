using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PowderAmount
{
    NONE,
    LESS,
    MUCH,
    FULL
}

public class SelectController : Singleton<SelectController>
{
    public PowderAmount curPowderAmount;
    public Button[] powderAmountSelect;
    public Button PackingButton;

    public bool Packing;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SelectPacking()
    {
        Packing = !Packing;

        PackingButton.image.color = Packing ? new Color(0, 0, 0, 1) : new Color(1, 1, 1, 1);
    }

    public void SelectPowderAmount(int n)
    {
        InitializeButtons();

        powderAmountSelect[n].image.color = new Color(0, 0, 0, 1);
        curPowderAmount = (PowderAmount)n;
    }

    public void InitializeButtons()
    {
        for (int i = 0; i < powderAmountSelect.Length; i++)
        {
            powderAmountSelect[i].image.color = new Color(1, 1, 1, 1);
        }
    }

    public void Compelete()
    {



        Packing = false;
        InitializeButtons();
        PackingButton.image.color = Packing ? new Color(0, 0, 0, 1) : new Color(1, 1, 1, 1);
        RecipeController.Instance.InitAllStatus(false);
        // npc 조건과 비교
    }

    
}
