using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum CharacterEnum
{
    COLLEGE,
    POPO,
    PEPER,
    BOYHOOD,
    PEACH,
    SCHOOLOLD,
    SCHOOLYOUNG
}
[System.Serializable]
public struct PrintData
{
    [TextArea]
    public string[] Order;
    [TextArea]
    public string[] BlackPowder;
    [TextArea]
    public string[] Package;
    [TextArea]
    public string[] SuccedOrFail;
}
[System.Serializable]
public struct NewText
{
    public string CriminalText;
    public string[] NewsText;
}
public class Character : TextPrint
{
    bool isCriminal;
    bool NewsIssue;
    public CharacterEnum type;
    public CharacterEnum[] Criminal;


    [SerializeField] int recipe;
    [SerializeField] int[] Gaugerecipe = new int[6];
    [SerializeField] PowderAmount powder;
    [SerializeField] bool package;

    public TextMeshProUGUI TextBar;

    public Sprite[] ChracterSprite;
    public Image ChracterBorad;

    public List<PrintData> printData;
    int point;
    public bool canComplte;
    private void Start()
    {
        RandSituation();
        StartCoroutine(Chat());
    }

    void NewsPaperReboot()
    {
        int customer = Day.Instance.customer;

        for (int i = 0; i < customer; i++)
        {
            if (Random.Range(0, customer - 1) == 0)
            {
                Criminal[Criminal.Length + 1] = (CharacterEnum)i;
            }
        }
    }
    public bool SuccedCheck()
    {

        List<int> temp = new List<int>();
        foreach (var item in Gaugerecipe)
        {
            temp.Add((int)item);
        }

        point = MainSceneUIController.Instance.CheckValue(powder, temp.ToArray(), package);
        int checkPoint = 0;
        foreach (int value in Gaugerecipe)
        {
            if (value != 0)
                checkPoint++;
        }
        checkPoint += 2;
        Debug.Log(checkPoint);
        Debug.Log(point);

        if (point != checkPoint)
        {
            return false;
        }
        else
        {
            if (isCriminal)
            {
                NewsIssue = true;
            }
            return true;
        }
    }

    void RandSituation()
    {
        TextBar.text = "";
        while (true)
        {
            type = (CharacterEnum)Random.Range(0, 7);
            foreach (CharacterEnum value in Day.Instance.customerType)
            {
                if (value != type)
                {
                    goto EXIT;
                }
            }
        }
        EXIT:
        ChracterBorad.sprite = ChracterSprite[(int)type];
        recipe = Random.Range(0, 6);
        powder = (PowderAmount)Random.Range(1, 4);
        package = Random.Range(0, 2) == 1 ? true : false;
        for (int i = 0; i < 6; i++)
        {
            Gaugerecipe[i] = MainSceneUIController.recipe[recipe, i];
        }
    }
    IEnumerator Chat()
    {
        yield return StartCoroutine(PrintText(TextBar, printData[(int)type].Order[recipe], 0.05f));
        yield return new WaitForSeconds(0.1f);
        TextBar.text += "\n";
        yield return StartCoroutine(PrintText(TextBar, printData[(int)type].BlackPowder[(int)powder - 1], 0.05f));
        yield return new WaitForSeconds(0.1f);
        TextBar.text += "\n";
        yield return StartCoroutine(PrintText(TextBar, printData[(int)type].Package[package ? 0 : 1], 0.05f));
        canComplte = true;
    }

    public void Complete()
    {
        TextBar.text = printData[(int)type].SuccedOrFail[0];
        StartCoroutine(Evade());
    }
    public void Fail()
    {
        TextBar.text = printData[(int)type].SuccedOrFail[1];
        StartCoroutine(Evade());
    }
    IEnumerator Evade()
    {
        canComplte = false;
        yield return new WaitForSeconds(1);
        while (ChracterBorad.color.a >= 0f)
        {
            ChracterBorad.color = new Color(1, 1, 1, ChracterBorad.color.a - 0.01f);
            yield return new WaitForSeconds(0.02f);
        }
        RandSituation();
        while (ChracterBorad.color.a < 1)
        {
            ChracterBorad.color = new Color(1, 1, 1, ChracterBorad.color.a + 0.01f);
            yield return new WaitForSeconds(0.02f);
        }
        StartCoroutine(Chat());
    }
}
