using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public GameObject developerPanel;
    public GameObject howToPanel;
    public GameObject fadeOutPanel;
    FadeInOut fadeInOut;
    bool startGame = false;

    float timer = 0f;

    private void Awake()
    {
        fadeInOut = fadeOutPanel.GetComponent<FadeInOut>();
    }
    // Start is called before the first frame update
    void Start()
    {
        fadeInOut.TryFadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            while(timer < 5f)
                timer += Time.deltaTime;
            Debug.Log("STARG GAME");
            //¾À ÀÌµ¿
        }
    }

    public void StargGame()
    {
        fadeInOut.TryFadeOut();
        startGame = true;
    }

    public void ShowDeveloperPanel()
    {
        developerPanel.SetActive(true);
    }

    public void HideDeveloperPanel()
    {
        developerPanel.SetActive(false);
    }

    public void ShowHowToPanel()
    {
        howToPanel.SetActive(true);
    }

    public void HideHowToPanel()
    {
        howToPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
