using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingCtrl : MonoBehaviour
{
    public GameObject[] EndingImgs;
    public GameObject fadeOutPanel;
    FadeInOut fadeInOut;

    private void Awake()
    {
        fadeInOut = fadeOutPanel.GetComponent<FadeInOut>();

        int clearDayCount = PlayerPrefs.GetInt("ClearDayCount");
        if(clearDayCount <= 7)
        {
            EndingImgs[0].SetActive(true);
        }
        else if (clearDayCount <= 14)
        {
            EndingImgs[1].SetActive(true);
        }
        else if (clearDayCount <= 24)
        {
            EndingImgs[2].SetActive(true);
        }
        else if (clearDayCount <= 25)
        {
            EndingImgs[3].SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        fadeInOut.TryFadeIn();
        //엔딩사진 설정
        StartCoroutine(Waiting(false));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //fadeInOut.TryFadeOut();
            StartCoroutine(Waiting(true));
        }


        //test
        if (Input.GetKeyDown(KeyCode.A))
        {
            EndingImgs[0].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            EndingImgs[1].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            EndingImgs[2].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            EndingImgs[3].SetActive(true);
        }
    }

    IEnumerator Waiting(bool moveTitle)
    {
        yield return new WaitForSeconds(2f);
        if (moveTitle)
            SceneManager.LoadScene("TitleScene");

    }
}
