using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character : TextPrint
{
    bool isCriminal;

    int recipe;
    int powder;
    bool package;

    public TextMeshProUGUI TextBar;
    public string[][] Order;
    public string[][] BlackPowder;
    public string[][] Package;

    int point;

    private void Awake()
    {
        Order[0][0] = "ぞしぞしぞ照錠穣";
    }
    private void Start()
    {
        RandSituation();
        StartCoroutine(Chat());
    }

    void Check()
    {
    }

    void RandSituation()
    {
        recipe = Random.Range(0, 6);
        powder = Random.Range(0, 5);
        package = Random.Range(0, 2) == 1 ? true : false;
    }
    IEnumerator Chat()
    {
        yield return StartCoroutine(PrintText(TextBar, Order[recipe][Random.Range(0, Order.Length)], 0.05f));
        yield return new WaitForSeconds(0.1f);
        TextBar.text += "\n";
        yield return StartCoroutine(PrintText(TextBar, BlackPowder[powder][Random.Range(0, BlackPowder.Length)], 0.05f));
        yield return new WaitForSeconds(0.1f);
        TextBar.text += "\n";
        yield return StartCoroutine(PrintText(TextBar, Package[package ? 1:0][Random.Range(0, Package.Length)], 0.05f));
    }

}
