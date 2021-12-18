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
    public string[] Order;
    public string[] BlackPowder;
    public string[] Package;
}

public class Character : TextPrint
{
    bool isCriminal;
    bool NewsIssue;
    public CharacterEnum type;

    List<GaugeStatus> recipe;
    PowderAmount powder;
    bool package;

    public TextMeshProUGUI TextBar;

    public List<PrintData> printData;
    int point;
    private void Start()
    {
        StartCoroutine(PrintText(TextBar, printData[0].Order[0], 0.05f));
        RandSituation();
        //StartCoroutine(Chat());
    }

    public bool SuccedCheck()
    {
        point = MainSceneUIController.Instance.CheckValue(powder, recipe.ToArray(), package);
        int checkPoint = 0;
        foreach (GaugeStatus value in recipe)
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
        int randrecipe = Random.Range(0, 6);
        for (int i = 0; i < 4; i++)
        {
            recipe[i] = (GaugeStatus)MainSceneUIController.Instance.recipe[randrecipe, i];
        }
        powder = (PowderAmount)Random.Range(0, 5);
        package = Random.Range(0, 2) == 1 ? true : false;
    }
    //IEnumerator Chat()
    //{
    //    Debug.Log("asdff");
    //    yield return StartCoroutine(PrintText(TextBar, Order[0][0], 0.05f));
    //    Debug.Log("asd");
    //    yield return new WaitForSeconds(0.1f);
    //    TextBar.text += "\n";
    //    yield return StartCoroutine(PrintText(TextBar, BlackPowder[(int)powder][Random.Range(0, BlackPowder.Length)], 0.05f));
    //    yield return new WaitForSeconds(0.1f);
    //    TextBar.text += "\n";
    //    yield return StartCoroutine(PrintText(TextBar, Package[package ? 1 : 0][Random.Range(0, Package.Length)], 0.05f));
    //}

}
