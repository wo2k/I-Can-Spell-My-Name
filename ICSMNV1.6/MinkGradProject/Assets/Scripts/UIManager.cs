using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [Header ("Menu Objects")]
    public GameObject startMenu;
    public GameObject endMenu;
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject confirmSubMenu;
    public GameObject pauseButton;
    public GameObject levelName;
    [HideInInspector]
    public bool gameStart = false;
    public bool inGame = false;

    public static UIManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
		
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
    }
    // Update is called once per frame
    void Update () {
        if (inGame)
        {
            startMenu.SetActive(true);
        }
		
	}
}
