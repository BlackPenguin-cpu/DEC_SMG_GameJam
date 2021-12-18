using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsController : MonoBehaviour
{
    Animator anim;
    public List<Sprite> NewsSprite = new List<Sprite>();
    public List<string> NewsText = new List<string>();
    public int curIdx;

    [Header("Next")]
    public Image nextImg;
    public Text nextTxt;

    [Header("Cur")]
    public Image curImg;
    public Text curTxt;

    void Start()
    {
        SetNextSibling();
        InitializeNews();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        AnimationDebug();
    }

    void AnimationDebug()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("IsPass", true);
        }
    }

    public void InitializeNews()
    {

        if(curIdx > NewsSprite.Count - 1)
        {
            curIdx = 0;
        }

        curImg.sprite = NewsSprite[curIdx];
        curTxt.text = NewsText[curIdx];

        if(curIdx + 1 > NewsSprite.Count - 1)
        {
            nextImg.sprite = NewsSprite[0];
            nextTxt.text = NewsText[0];
        }
        else
        {
            nextImg.sprite = NewsSprite[curIdx + 1];
            nextTxt.text = NewsText[curIdx + 1];
        }

    }

    public void SetNextSibling()
    {
        nextImg.transform.SetAsFirstSibling();
    }

    public void SetCurSibling()
    {
        curImg.transform.SetAsFirstSibling();
    }

    public void PassNextNews()
    {
        SetCurSibling();
    }

    public void EndNextNews()
    {
        SetNextSibling();

        curIdx++;
        InitializeNews();

        anim.SetBool("IsPass", false);
    }
}
