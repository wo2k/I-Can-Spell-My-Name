using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private GameObject currentMenu;
    private GameObject menuToGoTo;

    [Header ("Menu Objects")]
    public GameObject startMenu;
    public GameObject endMenu;
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject confirmSubMenu;
    public GameObject pauseButton;
    public GameObject winScreen;

    public char levelLetter;
    public int levelNum;

    [HideInInspector]
    public GameObject levelName;
    [HideInInspector]
    public bool gameStart = false;
    [HideInInspector]
    public bool inGame = false;

    public static UIManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void StartGame()
    { 
        switch (levelName.name)
        {
            case "Level1-A":
                levelName.GetComponent<Level1A>().PlaceAnswer();
                break;
            case "Level1-B":
                levelName.GetComponent<Level1B>().PlaceAnswer();
                break;
            case "Level1-C":
                levelName.GetComponent<Level1C>().PlaceAnswer();
                break;
            case "Level1-D":
                levelName.GetComponent<Level1D>().PlaceAnswer();
                break;
            case "Level1-E":
                levelName.GetComponent<Level1E>().PlaceAnswer();
                break;
        }
        startMenu.SetActive(false);
        gameStart = true;
        inGame = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        gameStart = false;
    }
    public void UnPauseGame()
    {
        pauseMenu.SetActive(false);
        gameStart = true;
    }

    public void GameOver()
    {
        endMenu.SetActive(true);
        gameStart = false;
    }

    public void WinGame()
    {
        SoundManagement.TriggerEvent("PlayLevelComplete");
        winScreen.SetActive(true);
        gameStart = false;
        GameManager.instance.subLevelPassed1++;
        PlayerPrefs.SetInt("SubLevelPassed", GameManager.instance.subLevelPassed1);
    }

    public void RestartGame()
    {
        switch (levelName.name)
        {
            case "Level1-A":
                levelName.GetComponent<Level1A>().Reset();
                break;
            case "Level1-B":
                levelName.GetComponent<Level1B>().Reset();
                break;
            case "Level1-C":
                levelName.GetComponent<Level1C>().Reset();
                break;
            case "Level1-D":
                levelName.GetComponent<Level1D>().Reset();
                break;
            case "Level1-E":
                levelName.GetComponent<Level1E>().Reset();
                break;
        }

        endMenu.SetActive(false);
        gameStart = true;
    }

    public void GoToMainMenu()
    {
        switch (levelName.name)
        {
            case "Level1-A":
                levelName.GetComponent<Level1A>().Reset();
                break;
            case "Level1-B":
                levelName.GetComponent<Level1B>().Reset();
                break;
            case "Level1-C":
                levelName.GetComponent<Level1C>().Reset();
                break;
            case "Level1-D":
                levelName.GetComponent<Level1D>().Reset();
                break;
            case "Level1-E":
                levelName.GetComponent<Level1E>().Reset();
                break;
        }
        levelName.SetActive(false);
        confirmSubMenu.SetActive(false);
        mainMenu.SetActive(true);
        startMenu.SetActive(true);
        inGame = false;

        if (endMenu)
            endMenu.SetActive(false);
        if (winScreen)
            winScreen.SetActive(false);
    }

    public void NextLevel()
    {
        SoundManagement.TriggerEvent("PlayPop");
        GoToMainMenu();
    //    menuToGoTo.SetActive(true);
      //  currentMenu.SetActive(false);

     /*   inGame = true;
        pauseButton.SetActive(true);
        levelName = menuToGoTo;

        if (endMenu)
            endMenu.SetActive(false);
        if (winScreen)
            winScreen.SetActive(false);*/
    }

    // Update is called once per frame
    void Update () {
        if (inGame)
        {
            startMenu.SetActive(true);
        }
		
	}
}
