using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Day : Singleton<Day>
{
    public int day = 0;
    public int customer;
    public List<CharacterEnum> customerType;
    public int customerCount;
    public Character character;
    public TextMeshProUGUI Daytext;
    public Image BlackScreen;
    public TextMeshProUGUI BigDaytext;

    void Start()
    {
        CustomerComing();
    }

    private void Update()
    {
        if (customerCount >= (day + 2 > 8 ? 8 : day + 2))
        {
            StartCoroutine(DaynextDay());
        }
    }
    IEnumerator DaynextDay()
    {

        Debug.Log("Clear");
        BigDaytext.gameObject.SetActive(true);
        while (BlackScreen.color.a > 0)
        {
            BlackScreen.color = new Color(1, 1, 1, BlackScreen.color.a - 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        BigDaytext.text = "Day" + day;
        yield return new WaitForSeconds(1);
        while (BlackScreen.color.a < 1)
        {
            BlackScreen.color = new Color(1, 1, 1, BlackScreen.color.a + 0.01f);
            yield return new WaitForSeconds(0.01f);
        }

    }
    void CustomerComing()
    {
        day++;
        Daytext.text = "Day " + day;
        if (day + 2 > 8)
        {
            customer = 8;
        }
        else
        {
            customer = day + 2;
        }
        for (int i = 0; i < customer; i++)
        {
            int Character = Random.Range(0, 7);

            if (!customerType.Contains((CharacterEnum)Character))
            {
                customerType.Add((CharacterEnum)Character);
            }
            else
            {
                i--;
            }
        }
        character.RandSituation();
    }
}
