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
    public CharacterEnum Criminal;


    [SerializeField] int recipe;
    [SerializeField] int[] Gaugerecipe = new int[6];
    [SerializeField] PowderAmount powder;
    [SerializeField] bool package;

    public TextMeshProUGUI TextBar;

    public Sprite[] ChracterSprite;
    public Image ChracterBorad;

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
        type = (CharacterEnum)Random.Range(0, 7);
        ChracterBorad.sprite = ChracterSprite[(int)type];
        recipe = Random.Range(0, 6);
        powder = (PowderAmount)Random.Range(1, 5);
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
        yield return StartCoroutine(PrintText(TextBar, printData[(int)type].BlackPowder[(int)powder-1], 0.05f));
        yield return new WaitForSeconds(0.1f);
        TextBar.text += "\n";
        yield return StartCoroutine(PrintText(TextBar, printData[(int)type].Package[package ? 1 : 0], 0.05f));
    }

    public void Complete()
    {
        Debug.Log("�ͼ��ߴ�!");
        TextBar.text = "��! �����ߴ�!";
    }
    public void Fail()
    {
        Debug.Log("���ƴϾ�");
        TextBar.text = "�� �ƴϾ�";
    }
}
