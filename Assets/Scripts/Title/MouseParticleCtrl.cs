using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseParticleCtrl : MonoBehaviour
{
    public AudioSource clickSound;
    public GameObject particle;
    Vector3 pos;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (clickSound != null)
                clickSound.Stop();
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            Instantiate(particle, pos, transform.rotation);
            if (clickSound != null)
                clickSound.Play();

        }

    }
}
