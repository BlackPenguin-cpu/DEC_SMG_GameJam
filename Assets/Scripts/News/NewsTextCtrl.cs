using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsTextCtrl : MonoBehaviour
{
    List<Dictionary<string, object>> data;
    int nowIndex;

    public Text nameTxt;
    public Text scriptTxt;
    public GameObject fadeOutPanel;
    FadeInOut fadeInOut;

    // Start is called before the first frame update

    private void Awake()
    {
        fadeInOut = fadeOutPanel.GetComponent<FadeInOut>();

        data = CSVReader.Read("NewsScript");
        nowIndex = 0;
        nameTxt.text = data[nowIndex]["name"].ToString();
        scriptTxt.text = data[nowIndex]["script"].ToString();
    }
    void Start()
    {
        fadeInOut.TryFadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nowIndex++;
            if (nowIndex < data.Count)
            {
                nameTxt.text = data[nowIndex]["name"].ToString();
                scriptTxt.text = data[nowIndex]["script"].ToString();
            }
            else
            {
                fadeInOut.TryFadeOut();
                Debug.Log("Script End");
            }
        }
    }
}
