using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject[] hearts;
    public GameObject healthBar;
    public int heartsAmount = 3;

    public GameObject[] subLevels;
    public enum subLevels1 {Level1A, Level1B, Level1C, Level1D, Level1E, None};
    public subLevels1 mode;
    public bool[] hasWonAlready = { false, false, false, false, false };
    public int hasWonIndex; 

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

    public string levelName;
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
    public void CloseApplication()
    {
        if (LevelManager.instance.m_Console == LevelManager.AppPlatform.Windows)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor)
                UnityEditor.EditorApplication.isPlaying = false;
            if(Application.platform == RuntimePlatform.WindowsPlayer)
                Application.Quit();
        }

        if (LevelManager.instance.m_Console == LevelManager.AppPlatform.MacOS)
        {
            if (Application.platform == RuntimePlatform.OSXEditor)
                UnityEditor.EditorApplication.isPlaying = false;
            if (Application.platform == RuntimePlatform.OSXPlayer)
                Application.Quit();
        }
    }

    public void StartGame()
    {
        LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
        switch (levelName)
        {
            case "Level1A":
                GameObject.FindGameObjectWithTag("Level1A").GetComponent<Level1A>().PlaceAnswer();
                break;
            case "Level1B":
                FindObjectOfType<Level1B>().PlaceAnswer();
                break;
            case "Level1C":
                FindObjectOfType<Level1C>().PlaceAnswer();
                break;
            case "Level1D":
                FindObjectOfType<Level1D>().PlaceAnswer();
                break;
            case "Level1E":
                FindObjectOfType<Level1E>().PlaceAnswer();
                break;
        }
        ResetGameStats();

    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        gameStart = false;
        LevelManager.instance.m_Mode = LevelManager.LevelType.Menus;
        Time.timeScale = 0;    
    }
    public void UnPauseGame()
    {
        pauseMenu.SetActive(false);
        gameStart = true;
        LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        endMenu.SetActive(true);
        gameStart = false;
        Time.timeScale = 0;
    }

    public int BoolToInt(bool value)
    {
        if (value)
            return 1;
        else
            return 0;
    }

    public bool IntToBool(int value)
    {
        if (value != 0)
            return true;
        else
            return false;
    }


    public void WinGame()
    {
        SoundManagement.TriggerEvent("PlayLevelComplete");
        winScreen.SetActive(true);
        gameStart = false;
        hasWonIndex = (int)mode;
        Time.timeScale = 0;
        switch (mode)
        {
            case subLevels1.Level1A:
                if (!hasWonAlready[hasWonIndex])
                {
                    hasWonAlready[hasWonIndex] = true;
                    LevelManager.instance.subLevelPassed1++;
                    PlayerPrefs.SetInt("SubLevelPassed", LevelManager.instance.subLevelPassed1);
                    PlayerPrefs.SetInt("HasWonAlready", BoolToInt(hasWonAlready[hasWonIndex]));
                }
                else
                    return;
                break;
            case subLevels1.Level1B:
                if (!hasWonAlready[hasWonIndex])
                {
                    hasWonAlready[hasWonIndex] = true;
                    LevelManager.instance.subLevelPassed1++;
                    PlayerPrefs.SetInt("SubLevelPassed", LevelManager.instance.subLevelPassed1);
                    PlayerPrefs.SetInt("HasWonAlready", BoolToInt(hasWonAlready[hasWonIndex]));
                }
                else
                    return;
                break;
            case subLevels1.Level1C:
                if (!hasWonAlready[hasWonIndex])
                {
                    hasWonAlready[hasWonIndex] = true;
                    LevelManager.instance.subLevelPassed1++;
                    PlayerPrefs.SetInt("SubLevelPassed", LevelManager.instance.subLevelPassed1);
                    PlayerPrefs.SetInt("HasWonAlready", BoolToInt(hasWonAlready[hasWonIndex]));
                }
                else
                    return;
                break;
            case subLevels1.Level1D:
                if (!hasWonAlready[hasWonIndex])
                {
                    hasWonAlready[hasWonIndex] = true;
                    LevelManager.instance.subLevelPassed1++;
                    PlayerPrefs.SetInt("SubLevelPassed", LevelManager.instance.subLevelPassed1);
                    PlayerPrefs.SetInt("HasWonAlready", BoolToInt(hasWonAlready[hasWonIndex]));
                }
                else
                    return;
                break;
            case subLevels1.Level1E:
                if (!hasWonAlready[hasWonIndex])
                {
                    hasWonAlready[hasWonIndex] = true;
                    LevelManager.instance.subLevelPassed1++;
                    PlayerPrefs.SetInt("SubLevelPassed", LevelManager.instance.subLevelPassed1);
                    PlayerPrefs.SetInt("HasWonAlready", BoolToInt(hasWonAlready[hasWonIndex]));
                }
                else
                    return;
                break;
        }
       
    }

    public void RestartGame()
    {
        LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
        switch (levelName)
        {
            case "Level1A":
                FindObjectOfType<Level1A>().Reset();
                break;
            case "Level1B":
                FindObjectOfType<Level1B>().Reset();
                break;
            case "Level1C":
                FindObjectOfType<Level1C>().Reset();
                break;
            case "Level1D":
                FindObjectOfType<Level1D>().Reset();
                break;
            case "Level1E":
                FindObjectOfType<Level1E>().Reset();
                break;
        }
        ResetGameStats();
     
    }

    public void GoToMainMenu()
    {
        LevelManager.instance.m_Mode = LevelManager.LevelType.Menus;
        switch (levelName)
        {
            case "Level1A":
                FindObjectOfType<Level1A>().Reset();
                break;
            case "Level1B":
                FindObjectOfType<Level1B>().Reset();
                break;
            case "Level1C":
                FindObjectOfType<Level1C>().Reset();
                break;
            case "Level1D":
                FindObjectOfType<Level1D>().Reset();
                break;
            case "Level1E":
                FindObjectOfType<Level1E>().Reset();
                break;
        }
        ResetGameStats();
        
    }

    public void NextLevel()
    {
        SoundManagement.TriggerEvent("PlayPop");
        LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
        switch (mode)
        {
            case subLevels1.Level1A:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                levelName = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).ToString();
                break;
            case subLevels1.Level1B:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                levelName = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).ToString();
                break;
            case subLevels1.Level1C:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                levelName = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).ToString();
                break;
            case subLevels1.Level1D:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                levelName = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).ToString();
                break;
            case subLevels1.Level1E:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                levelName = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).ToString();
                break;
        }
        ResetGameStats();
        
    }
    public void ResetGameStats()
    {
        Time.timeScale = 1;
        switch (LevelManager.instance.m_Mode)
        {
            case LevelManager.LevelType.GameMode:
                               
                inGame = true;
                gameStart = true;
                                
                pauseButton.SetActive(true);
                if (startMenu)
                    startMenu.SetActive(false);
                if (endMenu)
                    endMenu.SetActive(false);
                if (winScreen)
                    winScreen.SetActive(false);
                if (healthBar)
                    Destroy(healthBar);

                healthBar = InstantiatePlayerHealth(FindObjectOfType<UIManager>().transform);

                for (int i = 0; i < hearts.Length; i++)
                {
                    hearts[i] = healthBar.transform.GetChild(i).gameObject;
                }

                if (heartsAmount != 3)
                    heartsAmount = 3;

                LevelManager.instance.correctAnswerPoints = 0;
         
                break;
                
            case LevelManager.LevelType.Menus:

                pauseButton.SetActive(false);
                confirmSubMenu.SetActive(false);

                inGame = false;
                SceneManager.LoadScene("MainMenu");
                if (endMenu)
                    endMenu.SetActive(false);
                if (winScreen)
                    winScreen.SetActive(false);
                if (healthBar)
                    Destroy(healthBar);
                if (heartsAmount != 3)
                    heartsAmount = 3;
                break;
        }
    }


    public GameObject InstantiatePlayerHealth(Transform hpPlacement)
    {
        GameObject hpHolder = Instantiate(Resources.Load("Prefabs/PlayerHealth"), hpPlacement) as GameObject;
        hpHolder.transform.SetSiblingIndex(0);
        return hpHolder;
    }

    // Update is called once per frame
    void Update () {
       // if (inGame)
      //  {
      //      startMenu.SetActive(true);
       // }
		
	}
}
