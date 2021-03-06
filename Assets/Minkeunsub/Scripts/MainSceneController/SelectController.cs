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
    public Character NPC_Info;

    public bool Packing;

    void Start()
    {

    }

    void Update()
    {

    }

    public void SelectPacking()
    {
        SoundManager.Instance.PlaySound("포장");
        Packing = !Packing;

        PackingButton.image.color = Packing ? new Color(0, 0, 0, 1) : new Color(1, 1, 1, 1);
    }

    public void SelectPowderAmount(int n)
    {
        SoundManager.Instance.PlaySound("화약");
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
        if (NPC_Info.canComplte)
        {
            SoundManager.Instance.PlaySound("성공");
            List<int> temp = new List<int>();
            foreach (var item in RecipeController.Instance.gaugeStatus)
            {
                temp.Add((int)item);
            }

            MainSceneUIController.Instance.SubmitValue(curPowderAmount, temp.ToArray(), Packing);


            Packing = false;
            InitializeButtons();
            PackingButton.image.color = Packing ? new Color(0, 0, 0, 1) : new Color(1, 1, 1, 1);
            RecipeController.Instance.InitAllStatus(false);
            // npc 조건과 비교

            if (NPC_Info.SuccedCheck() /*|| NPC_Info.Criminal.Contains(NPC_Info.type)*/)
            {
                NPC_Info.Complete();
                Debug.Log("compelete");
            }
            else
            {
                NPC_Info.Fail();
                Debug.Log("Fail");
            }
        }
    }


}
