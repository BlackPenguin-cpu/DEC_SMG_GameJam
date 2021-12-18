using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character : TextPrint
{
    bool isCriminal;
    public TextMeshProUGUI TextBar;
    public string[] Order;
    public string[] BlackPowder;
    public string[] Package;
    private void Start()
    {
        StartCoroutine(Chat());
    }
    IEnumerator Chat()
    {
        yield return StartCoroutine(PrintText(TextBar, Order[Random.Range(0,Order.Length)], 0.1f));
        TextBar.text += "\n";
        yield return StartCoroutine(PrintText(TextBar, BlackPowder[Random.Range(0,BlackPowder.Length)], 0.1f));
        TextBar.text += "\n";
        yield return StartCoroutine(PrintText(TextBar, Package  [Random.Range(0,Package.Length)], 0.1f));
    }

}
