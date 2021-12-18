using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day : Singleton<Day>
{
    public int day;
    public int customer;


    void Start()
    {

    }

    void Update()
    {

    }
    void CustomerComing()
    {
        if (day + 2 > 8)
        {
            customer = 8;
        }
        else customer = day + 2;
    }
}
