using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject highScoresMenu;

    public Text hiscoreText;

    public Text hiscoreText1;
    public Text hiscoreText2;
    public Text hiscoreText3;
    public Text hiscoreText4;
    public Text hiscoreText5;


    // Start is called before the first frame update
    void Start()
    {

        hiscoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

        hiscoreText1.text = "1. " + PlayerPrefs.GetInt("HighScore").ToString();
        hiscoreText2.text = "2. " + PlayerPrefs.GetInt("HighScore0").ToString();

        //PlayerPrefs.GetInt("HighScore");
        //hiscoreText.text =  GameManager.HighScore.ToString();
        // HighScore.GetComponent<Text>().text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        settingsMenu.SetActive(false);
        highScoresMenu.SetActive(false);

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("game");
    }

    public void GotToHighScores()
    {
        highScoresMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void GotToSettings()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void ResumeToMainMenuFromHighScores()
    {
        mainMenu.SetActive(true);
        highScoresMenu.SetActive(false);

    }

    public void ResumeToMainMenuFromSettings()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
