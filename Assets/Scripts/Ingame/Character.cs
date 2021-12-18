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
    public CharacterEnum Criminal;


    int recipe;
    List<GaugeStatus> Gaugerecipe;
    PowderAmount powder;
    bool package;

    public TextMeshProUGUI TextBar;

    Sprite[] ChracterSprite;
    SpriteRenderer ChracterBorad;

    public List<PrintData> printData;
    int point;
    private void Start()
    {
        RandSituation();
        StartCoroutine(Chat());
    }

    string NewsPaperReboot()
    {
        int customer = Day.Instance.customer;

        return "asd";
    }
    public bool SuccedCheck()
    {
        point = MainSceneUIController.Instance.CheckValue(powder, Gaugerecipe.ToArray(), package);
        int checkPoint = 0;
        foreach (GaugeStatus value in Gaugerecipe)
        {
            checkPoint += (int)value;
        }
        checkPoint += 2;
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
        type = (CharacterEnum)Random.Range(0, 7);
        int recipe = Random.Range(0, 6);
        for (int i = 0; i < 4; i++)
        {
            Gaugerecipe[i] = (GaugeStatus)MainSceneUIController.Instance.recipe[recipe, i];
        }
        powder = (PowderAmount)Random.Range(0, 5);
        package = Random.Range(0, 2) == 1 ? true : false;
    }
    IEnumerator Chat()
    {
        Debug.Log("asdff");
        yield return StartCoroutine(PrintText(TextBar, printData[(int)type].Order[recipe], 0.05f));
        Debug.Log("asd");
        yield return new WaitForSeconds(0.1f);
        TextBar.text += "\n";
        yield return StartCoroutine(PrintText(TextBar, printData[(int)type].BlackPowder[(int)powder], 0.05f));
        yield return new WaitForSeconds(0.1f);
        TextBar.text += "\n";
        yield return StartCoroutine(PrintText(TextBar, printData[(int)type].Package[package ? 1 : 0], 0.05f));
    }

}
