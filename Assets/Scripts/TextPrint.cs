using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public abstract class TextPrint : MonoBehaviour
{
    TextMeshProUGUI Tmp;
    private void Start()
    {
        Tmp = GetComponent<TextMeshProUGUI>();
    }
    protected virtual IEnumerator PrintText(string text, float speed)
    {
        string realText = null;
        int value = 0;
        while (realText != text)
        {
            realText += text[value];
            Tmp.text = realText;
            value++;
            yield return new WaitForSeconds(speed);
        }
    }
}
