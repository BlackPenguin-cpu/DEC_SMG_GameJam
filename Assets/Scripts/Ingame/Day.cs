using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class Day : Singleton<Day>
{
    public int day;
    public int customer;
    public List<CharacterEnum> customerType;
    public List<CharacterEnum> CustomerList;
    public int customerCount;
    public Character character;
    public TextMeshProUGUI Daytext;
    public Image BlackScreen;
    public TextMeshProUGUI BigDaytext;

    protected override void Awake()
    {

        day = GameManager.Instance.Day;
        Daytext.text = "Day " + day;
        CustomerComing();
    }

    private void Update()
    {
        if (customerCount >= (day + 2 > 7 ? 7 : day + 2))
        {
            StartCoroutine(DaynextDay());
        }
    }
    public IEnumerator DaynextDay()
    {
        //Clear Count
        int clearDay = PlayerPrefs.GetInt("ClearDayCount");
        PlayerPrefs.SetInt("ClearDayCount", clearDay + 1);

        customerCount = 0;
        Time.timeScale = 0;
        while (BlackScreen.color.a < 1)
        {
            BlackScreen.color = new Color(0, 0, 0, BlackScreen.color.a + 0.01f);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        BigDaytext.gameObject.SetActive(true);
        BigDaytext.text = "Day" + (day + 1);
        yield return new WaitForSecondsRealtime(2);
        FindObjectOfType<GaugeController>().curValue = 100;
        BigDaytext.gameObject.SetActive(false);
        while (BlackScreen.color.a > 0)
        {
            BlackScreen.color = new Color(0, 0, 0, BlackScreen.color.a - 0.01f);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        Time.timeScale = 1;
        GameManager.Instance.Day = day;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        CustomerComing();
    }
    public IEnumerator GameOver()
    {
        BigDaytext.gameObject.SetActive(true);
        while (BlackScreen.color.a > 0)
        {
            BlackScreen.color = new Color(1, 1, 1, BlackScreen.color.a - 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        Time.timeScale = 0;
        BigDaytext.text = "GAME OVER...";
        yield return new WaitForSecondsRealtime(2);
        FindObjectOfType<GaugeController>().curValue = 100;
        Time.timeScale = 1;
        BlackScreen.gameObject.SetActive(false);
        SceneManager.LoadScene("EndingScene");

    }
    void CustomerComing()
    {
        day++;
        Daytext.text = "Day " + day;
        if (day + 2 > 7)
        {
            customer = 7;
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
        customerCount = 0;
        CustomerList = customerType.ToList();
        character.RandSituation();
        character.NewsPaperReboot();
    }
}
