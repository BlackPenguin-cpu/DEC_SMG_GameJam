using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    bool isFadeIn = false;
    bool isPlaying = false;

    public Image blackImg;

    public void TryFadeIn()
    {
        StartCoroutine("FadeIn");
    }

    public void TryFadeOut()
    {
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeIn()
    {
        if (isFadeIn || isPlaying)
            yield return null;
        isFadeIn = true;
        isPlaying = true;

        Color color = blackImg.color;
        while (color.a > 0f)
        {
            color.a -= 0.05f;
            blackImg.color = color;
            yield return new WaitForSeconds(0.05f);
        }
        color.a = 0;
        blackImg.color = color;
        isPlaying = false;
        blackImg.transform.gameObject.SetActive(false);
    }

    IEnumerator FadeOut()
    {
        if (!isFadeIn || isPlaying)
            yield return null;
        blackImg.transform.gameObject.SetActive(true);
        isFadeIn = false;
        isPlaying = true;

        Color color = blackImg.color;
        while (color.a < 1f)
        {
            color.a += 0.05f;
            blackImg.color = color;
            yield return new WaitForSeconds(0.05f);
        }
        color.a = 1f;
        blackImg.color = color;
        isPlaying = false;
        
    }
}
