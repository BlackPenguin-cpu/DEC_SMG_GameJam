using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class TextPrint : MonoBehaviour
{
    protected virtual IEnumerator PrintText(TextMeshProUGUI Tmp,string text, float speed)
    {
        string realText = Tmp.text;
        string ifstring = (Tmp.text + text);
        int value = 0;
        while (realText != ifstring)
        {
            realText += text[value];
            Tmp.text = realText;
            value++;
            yield return new WaitForSeconds(speed);
        }
    }
}
