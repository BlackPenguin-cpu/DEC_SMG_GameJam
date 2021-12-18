using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningCtrl : MonoBehaviour
{
    public Image[] WhiteImg = new Image[3];

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ShowOpening");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowOpening()
    {
        Color color;
        for(int i = 0; i < 3; i++)
        {
            color = WhiteImg[i].color;
            while (color.a > 0f)
            {
                color.a -= 0.05f;
                WhiteImg[i].color = color;
                yield return new WaitForSeconds(0.1f);
            }
            color.a = 0f;
            WhiteImg[i].color = color;
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("TitleScene");
        yield return null;
    }
}
