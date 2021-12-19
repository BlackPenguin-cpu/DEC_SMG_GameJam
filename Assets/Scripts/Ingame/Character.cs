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
    public List<CharacterEnum> Criminal;


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
        SoundManager.Instance.Playbgm("¿Œ∞‘¿”");
        StartCoroutine(Chat());
    }

    public void NewsPaperReboot()
    {
        int customer = Day.Instance.customer;

        for (int i = 0; i < customer; i++)
        {
            if (Random.Range(0, customer - 1) == 0)
            {
                Criminal.Add((CharacterEnum)i);
            }
        }
    }
    public bool SuccedCheck()
    {

        point = MainSceneUIController.Instance.CheckValue(powder, Gaugerecipe, package);
        int checkPoint = 8;

        /*foreach (int value in Gaugerecipe)
        {
            if (value != 0)
                checkPoint++;
        }
        checkPoint += 2;*/

        if (Criminal.Contains(type) && powder != FindObjectOfType<SelectController>().curPowderAmount)
        {

            NewsIssue = true;
        }
        if (point != checkPoint)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void RandSituation()
    {
        TextBar.text = "";
        while (true)
        {
            type = (CharacterEnum)Random.Range(0, 7);
            if (Day.Instance.customerType.Count != 0)
            {
                if (Day.Instance.customerType.Contains(type))
                {
                    ChracterBorad.sprite = ChracterSprite[(int)type];
                    Day.Instance.customerType.Remove(type);
                    break;
                }
            }
            else break;
        }
        recipe = Random.Range(0, 6);
        if (Criminal.Contains(type))
        {
            powder = PowderAmount.NONE;
        }
        else powder = (PowderAmount)Random.Range(1, 4);

        if (Criminal.Contains(type))
        {
            package = true;
        }
        else
            package = Random.Range(0, 2) == 1 ? true : false;
        for (int i = 0; i < 6; i++)
        {
            Gaugerecipe[i] = MainSceneUIController.recipe[recipe, i];
        }
    }
    IEnumerator Chat()
    {
        yield return StartCoroutine(PrintText(TextBar, printData[(int)type].Order[recipe], 0.025f));
        yield return new WaitForSeconds(0.1f);
        TextBar.text += "\n";
        if (Criminal.Contains(type))
        {
            yield return StartCoroutine(PrintText(TextBar, printData[(int)type].BlackPowder[Random.Range(1, 4)], 0.025f));
        }
        else
            yield return StartCoroutine(PrintText(TextBar, printData[(int)type].BlackPowder[(int)powder - 1], 0.025f));
        yield return new WaitForSeconds(0.1f);
        TextBar.text += "\n";
        yield return StartCoroutine(PrintText(TextBar, printData[(int)type].Package[package ? 0 : 1], 0.025f));
        canComplte = true;
    }

    public void Complete()
    {
        if (GaugeController.Instance.curValue +10 > 100)
        {
            GaugeController.Instance.curValue = 100; 
        }
        else
        GaugeController.Instance.curValue += 10;
        TextBar.text = printData[(int)type].SuccedOrFail[0];
        StartCoroutine(Evade());
    }
    public void Fail()
    {
        GaugeController.Instance.curValue -= 15;
        if (Criminal.Contains(type))
        {
            TextBar.text = printData[(int)type].SuccedOrFail[0];
        }
        else
        {
            TextBar.text = printData[(int)type].SuccedOrFail[1];
        }
        StartCoroutine(Evade());
    }
    IEnumerator Evade()
    {
        canComplte = false;
        yield return new WaitForSeconds(1);
        while (ChracterBorad.color.a > 0f)
        {
            ChracterBorad.color = new Color(1, 1, 1, ChracterBorad.color.a - 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        Day.Instance.customerCount++;
        RandSituation();
        while (ChracterBorad.color.a < 1)
        {
            ChracterBorad.color = new Color(1, 1, 1, ChracterBorad.color.a + 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(Chat());
    }
}
