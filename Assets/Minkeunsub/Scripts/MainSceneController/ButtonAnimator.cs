using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimator : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StartTouch()
    {
        anim.SetBool("IsTouch", true);
    }

    public void EndTouch()
    {
        anim.SetBool("IsTouch", false);
    }
}
