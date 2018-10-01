﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private GameObject currentMenu;
    private GameObject menuToGoTo;

    public GameObject[] hearts;
    public GameObject healthBar;
    public int heartsAmount = 3;

    public GameObject[] subLevels;

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

        DontDestroyOnLoad(instance);
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

        if (healthBar)
            Destroy(healthBar);
        if (heartsAmount != 3)
            heartsAmount = 3;
        healthBar = InstantiatePlayerHealth(FindObjectOfType<UIManager>().transform);
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = healthBar.transform.GetChild(i).gameObject;
        }
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
        LevelManager.instance.subLevelPassed1++;
        PlayerPrefs.SetInt("SubLevelPassed", LevelManager.instance.subLevelPassed1);
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
        if(healthBar)
        Destroy(healthBar);
        healthBar = InstantiatePlayerHealth(FindObjectOfType<UIManager>().transform);
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = healthBar.transform.GetChild(i).gameObject;
        }
        if (heartsAmount != 3)
            heartsAmount = 3;
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
        if (healthBar)
            Destroy(healthBar);
        if (heartsAmount != 3)
            heartsAmount = 3;
    }

    public void NextLevel()
    {
        SoundManagement.TriggerEvent("PlayPop");
        currentMenu = levelName;
        currentMenu.SetActive(false);
        levelName = subLevels[LevelManager.instance.subLevelPassed1];
        menuToGoTo = levelName;
        menuToGoTo.SetActive(true);

        inGame = true;
        pauseButton.SetActive(true);

        if (endMenu)
            endMenu.SetActive(false);
        if (winScreen)
            winScreen.SetActive(false);
        if (healthBar)
            Destroy(healthBar);
        if (heartsAmount != 3)
            heartsAmount = 3;
    }

    public GameObject InstantiatePlayerHealth(Transform hpPlacement)
    {
        GameObject hpHolder = Instantiate(Resources.Load("Prefabs/PlayerHealth"), hpPlacement) as GameObject;
        hpHolder.transform.SetSiblingIndex(0);
        return hpHolder;
    }

    // Update is called once per frame
    void Update () {
        if (inGame)
        {
            startMenu.SetActive(true);
        }
		
	}
}