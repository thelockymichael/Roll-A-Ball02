using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject soundControlButton;
    public Sprite audioOffSprite;
    public Sprite audioOnSprite;

    public GameObject InControl;

    public GameObject PauseMenu;
    public GameObject pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        soundControlButton.SetActive(false);
        InControl.SetActive(false);
    }

    public void ResumeGame()
    {
        InControl.SetActive(true);
        pauseButton.SetActive(true);
        soundControlButton.SetActive(true);
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }

    public void SoundControl()
    {
        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
            soundControlButton.GetComponent<Image>().sprite = audioOnSprite;
        }
        else
        {
            AudioListener.pause = true;
            soundControlButton.GetComponent<Image>().sprite = audioOffSprite;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
