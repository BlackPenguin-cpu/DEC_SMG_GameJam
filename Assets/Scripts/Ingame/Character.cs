using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character : TextPrint
{
    bool isCriminal;
    bool NewsIssue;


    List<GaugeStatus> recipe;
    PowderAmount powder;
    bool package;

    public TextMeshProUGUI TextBar;
    public string[] Order;
    public string[][] BlackPowder;
    public string[][] Package;

    int point;

    private void Start()
    {
        RandSituation();
        StartCoroutine(Chat());
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
    IEnumerator Chat()
    {
        yield return StartCoroutine(PrintText(TextBar, Order[Random.Range(0, Order.Length)], 0.05f));
        yield return new WaitForSeconds(0.1f);
        TextBar.text += "\n";
        yield return StartCoroutine(PrintText(TextBar, BlackPowder[(int)powder][Random.Range(0, BlackPowder.Length)], 0.05f));
        yield return new WaitForSeconds(0.1f);
        TextBar.text += "\n";
        yield return StartCoroutine(PrintText(TextBar, Package[package ? 1 : 0][Random.Range(0, Package.Length)], 0.05f));
    }

}
