using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public AudioSource btnSound;
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
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void StargGame()
    {
        btnSound.Play();
        fadeInOut.TryFadeOut();
        startGame = true;
    }

    public void ShowDeveloperPanel()
    {
        btnSound.Play();
        developerPanel.SetActive(true);
    }

    public void HideDeveloperPanel()
    {
        btnSound.Play();
        developerPanel.SetActive(false);
    }

    public void ShowHowToPanel()
    {
        btnSound.Play();
        howToPanel.SetActive(true);
    }

    public void HideHowToPanel()
    {
        btnSound.Play();
        howToPanel.SetActive(false);
    }

    public void ExitGame()
    {
        btnSound.Play();
        Application.Quit();
    }
}
