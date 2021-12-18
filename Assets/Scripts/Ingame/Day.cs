using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Day : Singleton<Day>
{
    public int day = 0;
    public int customer;
    public CharacterEnum[] customerType;
    public int customerCount;
    public TextMeshProUGUI TMP;

    void Start()
    {
        CustomerComing();
    }

    void Update()
    {
        if(customerCount >= (day+2 > 8? 8 : day + 2))
        {
            Debug.Log("Clear");
        }
    }
    void CustomerComing()
    {
        day++;
        TMP.text = "Day " + day;
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
            foreach (int value in customerType)
            {
                if (Character == value)
                {
                    i--;
                    goto EXIT;
                }
            }
            customerType[customerType.Length + 1] = (CharacterEnum)customer;
        EXIT:;
        }
    }
}
