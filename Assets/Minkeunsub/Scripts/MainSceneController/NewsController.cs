using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsController : MonoBehaviour
{
    Animator anim;
    public List<Sprite> NewsSprite = new List<Sprite>();
    public List<string> NewsText = new List<string>();
    public List<string> CriminalText = new List<string>();
    public int curIdx;

    public List<CharacterEnum> CurCharacters = new List<CharacterEnum>();
    public List<Sprite> NowUseSprite = new List<Sprite>();
    public List<string> NowUseText = new List<string>();

    public Character character;

    [Header("Next")]
    public Image nextImg;
    public Text nextTxt;

    [Header("Cur")]
    public Image curImg;
    public Text curTxt;

    void Start()
    {
        anim = GetComponent<Animator>();
        SetNextSibling();
        SetNewCharacters();
        InitializeNews();
    }

    void Update()
    {
        //AnimationDebug();
    }

    void AnimationDebug()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("IsPass", true);
        }
    }

    public void SetNewCharacters()
    {
        CurCharacters.Clear();
        NowUseSprite.Clear();

        foreach (var item in Day.Instance.CustomerList)
        {
            CurCharacters.Add(item);
        }

        for (int i = 0; i < CurCharacters.Count; i++)
        {
            switch (CurCharacters[i])
            {
                case CharacterEnum.COLLEGE:
                    NowUseSprite.Add(NewsSprite[0]);
                    NowUseText.Add(NewsText[0]);
                    break;
                case CharacterEnum.POPO:
                    NowUseSprite.Add(NewsSprite[1]);
                    NowUseText.Add(NewsText[1]);
                    break;
                case CharacterEnum.PEPER:
                    NowUseSprite.Add(NewsSprite[2]);
                    NowUseText.Add(NewsText[2]);
                    break;
                case CharacterEnum.BOYHOOD:
                    NowUseSprite.Add(NewsSprite[3]);
                    NowUseText.Add(NewsText[3]);
                    break;
                case CharacterEnum.PEACH:
                    NowUseSprite.Add(NewsSprite[4]);
                    NowUseText.Add(NewsText[4]);
                    break;
                case CharacterEnum.SCHOOLOLD:
                    NowUseSprite.Add(NewsSprite[5]);
                    NowUseText.Add(NewsText[5]);
                    break;
                case CharacterEnum.SCHOOLYOUNG:
                    NowUseSprite.Add(NewsSprite[6]);
                    NowUseText.Add(NewsText[6]);
                    break;
                default:
                    break;
            }
        }

        for (int i = 0; i < character.Criminal.Count; i++)
        {
            switch (character.Criminal[i])
            {
                case CharacterEnum.COLLEGE:
                    NowUseText[0] = CriminalText[0];
                    break;
                case CharacterEnum.POPO:
                    NowUseText[1] = CriminalText[1];
                    break;
                case CharacterEnum.PEPER:
                    NowUseText[2] = CriminalText[2];
                    break;
                case CharacterEnum.BOYHOOD:
                    NowUseText[3] = CriminalText[3];
                    break;
                case CharacterEnum.PEACH:
                    NowUseText[4] = CriminalText[4];
                    break;
                case CharacterEnum.SCHOOLOLD:
                    NowUseText[5] = CriminalText[5];
                    break;
                case CharacterEnum.SCHOOLYOUNG:
                    NowUseText[6] = CriminalText[6];
                    break;
                default:
                    break;
            }
        }
    }

    public void NextNews()
    {
        SoundManager.Instance.PlaySound("½Å¹®");
        anim.SetBool("IsPass", true);
    }

    public void InitializeNews()
    {

        if(curIdx > NowUseSprite.Count - 1)
        {
            curIdx = 0;
        }

        curImg.sprite = NowUseSprite[curIdx];
        curTxt.text = NowUseText[curIdx];

        if(curIdx + 1 > NowUseSprite.Count - 1)
        {
            nextImg.sprite = NowUseSprite[0];
            nextTxt.text = NowUseText[0];
        }
        else
        {
            nextImg.sprite = NowUseSprite[curIdx + 1];
            nextTxt.text = NowUseText[curIdx + 1];
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
