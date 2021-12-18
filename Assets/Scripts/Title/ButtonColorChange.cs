using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour
{
    Image btnImg;

    public Sprite mouseOn;
    public Sprite mouseOff;
    // Start is called before the first frame update
    void Start()
    {
        btnImg = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnMouseEnter()
    {
        btnImg.sprite = mouseOn;
    }

    public void OnMouseExit()
    {
        btnImg.sprite = mouseOff;
    }
}
