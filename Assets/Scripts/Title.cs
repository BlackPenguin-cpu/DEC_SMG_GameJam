using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public GameObject developerPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StargGame()
    {
        Debug.Log("STARG GAME");
    }

    public void ShowDeveloperPanel()
    {
        developerPanel.SetActive(true);
    }

    public void HideDeveloperPanel()
    {
        developerPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
